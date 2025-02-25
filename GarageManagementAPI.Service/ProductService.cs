using AutoMapper;
using System.Dynamic;
using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Service.Extension;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.ErrorsConstant.Product;
using GarageManagementAPI.Shared.ErrorsConstant.ProductImg;
using GarageManagementAPI.Shared.DataTransferObjects.Product;
using GarageManagementAPI.Shared.ErrorsConstant.ProductHistory;
using GarageManagementAPI.Shared.DataTransferObjects.ProductImage;
using GarageManagementAPI.Shared.DataTransferObjects.ProductHistory;

namespace GarageManagementAPI.Service
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryManager _repoManager;
        private readonly IMapper _mapper;
        private readonly IDataShaperManager _dataShaper;

        public ProductService(IRepositoryManager repoManager, IMapper mapper, IDataShaperManager dataShaper)
        {
            _repoManager = repoManager;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }

        public async Task<Result<ProductDto>> CreateProductAsync(ProductDtoForCreation productDtoForCreation)
        {
            var check = await CheckIfProductExistByNameAndBrandOrBarCode(productDtoForCreation);
            if (check)
                return Result<ProductDto>.BadRequest([ProductErrors.GetProductNameAlreadyExistError(productDtoForCreation)]);

            var productEntity = _mapper.Map<Product>(productDtoForCreation);

            productEntity.CreatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            productEntity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            productEntity.Status = ProductStatus.Inactive;


            await _repoManager.Product.CreateProductAsync(productEntity);
            await _repoManager.SaveAsync();

            //Create Product History
            await CreateProductHistoryAsync(productEntity.Id, productDtoForCreation.ProductPrice);
            //Create Product Image
            if (productDtoForCreation.Link != null)
            {
                await CreateProductImageAsync(productEntity.Id, productDtoForCreation.Link);
            }

            var productDtoToReturn = _mapper.Map<ProductDto>(productEntity);

            return productDtoToReturn.CreatedResult();
        }

        public async Task<Result> UpdateProduct(Guid productId, ProductDtoForUpdate productDtoForUpdate, bool trackChanges, string? include = null)
        {
            var productResult = await GetAndCheckIfProductExist(productId, trackChanges);
            var check = await CheckIfProductExistByNameAndBrandOrBarCodeForUpdate(productDtoForUpdate, productId);
            if (check)
                return Result<ProductDtoForUpdate>.BadRequest([ProductErrors.GetProductNameUpdateAlreadyExistError(productDtoForUpdate)]);
            if (!productResult.IsSuccess)
                return Result<ProductDtoForUpdate>.Failure(productResult.StatusCode, productResult.Errors!);
            var productEntity = productResult.GetValue<Product>();

            _mapper.Map(productDtoForUpdate, productEntity);

            productEntity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            //Create Product History
            await CreateProductHistoryAsync(productId, productDtoForUpdate.ProductPrice);
            //Create Product Image
            if (productDtoForUpdate.Link != null)
            {
                await CreateProductImageAsync(productId, productDtoForUpdate.Link);
            }

            await _repoManager.SaveAsync();

            return Result.NoContent();
        }


        public async Task<Result<ExpandoObject>> GetProductByIdAsync(Guid productId, bool trackChanges, string? include = null)
        {
            var productResult = await GetAndCheckIfProductExist(productId, trackChanges, include);

            if (!productResult.IsSuccess)
                return Result<ExpandoObject>.NotFound(productResult.Errors!);

            var productsEntity = productResult.GetValue<Product>();

            var productDto = _mapper.Map<ProductDto>(productsEntity);

            var productShaped = _dataShaper.Product.ShapeData(productDto, null);

            return Result<ExpandoObject>.Ok(productShaped);
        }

        public async Task<Result<ExpandoObject>> GetProductByBarcodeAsync(string barcode, ProductParameters productParameters, bool trackChanges, string? include = null)
        {
            var productResult = await GetAndCheckIfProductByBarCodeExist(barcode, trackChanges, include);

            if (!productResult.IsSuccess)
                return Result<ExpandoObject>.NotFound(productResult.Errors!);

            var productEntity = productResult.GetValue<Product>();

            var productsDto = _mapper.Map<ProductDto>(productEntity);

            var productShaped = _dataShaper.Product.ShapeData(productsDto, productParameters.Fields);

            return Result<ExpandoObject>.Ok(productShaped);
        }

        public async Task<Result<ProductDtoForUpdate>> GetProductForPartiallyUpdate(Guid productId, bool trackChanges, string? include = null)
        {
            var productResult = await GetAndCheckIfProductExist(productId, trackChanges, include);
            if (!productResult.IsSuccess)
                return Result<ProductDtoForUpdate>.Failure(productResult.StatusCode, productResult.Errors!);

            var productEntity = productResult.GetValue<Product>();

            var productDtoForUpdate = _mapper.Map<ProductDtoForUpdate>(productEntity);

            return Result<ProductDtoForUpdate>.Ok(productDtoForUpdate);
        }

        public async Task<Result<IEnumerable<ExpandoObject>>> GetProductsAsync(ProductParameters productParameters, bool trackChanges, string? include = null)
        {
            var productsWithMetadata = await _repoManager.Product.GetProductsAsync(productParameters, trackChanges, include);

            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(productsWithMetadata);

            var productsShaped = _dataShaper.Product.ShapeData(productsDto, productParameters.Fields);

            return Result<IEnumerable<ExpandoObject>>.Ok(productsShaped, productsWithMetadata.MetaData);
        }

        private async Task<bool> CheckIfProductExistByNameAndBrandOrBarCode(ProductDtoForCreation productDtoForCreation)
        {
            var brandId = productDtoForCreation.BrandId;
            var productCategoryId = productDtoForCreation.ProductCategoryId;
            var barcode = productDtoForCreation.ProductBarcode!.ToLower();
            var name = productDtoForCreation.ProductName!.ToLower();

            var exists = await _repoManager.Product.FindByCondition(p =>
                p.BrandId.Equals(brandId) && p.ProductCategoryId.Equals(productCategoryId) &&
                 p.ProductName.ToLower().Equals(name) ||
                 p.ProductBarcode.Equals(barcode),
                false).AnyAsync();

            return exists;
        }

        private async Task<bool> CheckIfProductExistByNameAndBrandOrBarCodeForUpdate(ProductDtoForUpdate productDtoForUpdate, Guid productId)
        {
            var brandId = productDtoForUpdate.BrandId;
            var barcode = productDtoForUpdate.ProductBarcode!.Trim();
            var name = productDtoForUpdate.ProductName!.Trim();

            var exists = await _repoManager.Product.FindByCondition(p =>
            !p.Id.Equals(productId) &&
               (p.BrandId.Equals(brandId) &&
                 p.ProductName.Trim().Equals(name) ||
                 p.ProductBarcode.Trim().Equals(barcode)),
                false).AnyAsync();

            return exists;
        }


        private async Task<Result<Product>> GetAndCheckIfProductExist(Guid productId, bool trackChanges, string? include = null)
        {
            var product = await _repoManager.Product.GetProductByIdAsync(productId, trackChanges, include);
            if (product == null)
                return product.NotFoundId(productId);

            return product.OkResult();
        }


        private async Task<Result<Product>> GetAndCheckIfProductByBarCodeExist(string barcode, bool trackChanges, string? include)
        {
            var product = await _repoManager.Product.GetProductByBarCodeAsync(barcode, trackChanges, include);
            if (product == null)
                return product.NotFoundBarcode(barcode);

            return product.OkResult();
        }

        private async Task<Result<ProductImageDto>> CreateProductImageAsync(Guid productId, string link)
        {
            var checkLink = await GetAndCheckIfProductImgByIdAndLink(productId, link);

            if (checkLink)
                return Result<ProductImageDto>.BadRequest([ProductImgErrors.GetProductImageLinkAlreadyExistError(link)]);
            // Gọi UpdateStatusImage 
            await UpdateStatusProductImage(productId);

            var productImgEntity = new ProductImage
            {
                ProductId = productId,
                Link = link,
                Status = ProductImageStatus.Active,
                CreatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime(),
                UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime()
            };

            await _repoManager.ProductImage.CreateProductImgAsync(productImgEntity);
            await _repoManager.SaveAsync();

            var productImgDtoToReturn = _mapper.Map<ProductImageDto>(productImgEntity);

            return productImgDtoToReturn.CreatedResult();
        }

        public async Task<Result<ProductHistoryDto>> CreateProductHistoryAsync(Guid productId, decimal price)
        {
            var checkPrice = await CheckIfProductHistoryByIdAndPrice(productId, price);
            if (checkPrice)
                return Result<ProductHistoryDto>.BadRequest([ProductHistoryErrors.GetProductHistoryPriceAlreadyExistError(price)]);
            var date = DateTimeOffset.UtcNow.SEAsiaStandardTime();

            await UpdateStatusProductHistory(productId);

            var productEntity = new ProductHistory
            {
                ProductId = productId,
                ProductPrice = price,
                Status = ProductHistoryStatus.Active,
                CreatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime(),
                UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime(),
            };

            await _repoManager.ProductHistory.CreateProductHisotoryAsync(productEntity);
            await _repoManager.SaveAsync();

            var productHistoryDtoToReturn = _mapper.Map<ProductHistoryDto>(productEntity);

            return productHistoryDtoToReturn.CreatedResult();
        }


        private async Task UpdateStatusProductImage(Guid productId)
        {
            var productEntity = await _repoManager.ProductImage
                                      .FindByCondition(p => p.Status == ProductImageStatus.Active && p.ProductId == productId, false).OrderByDescending(p => p.UpdatedAt)
                                      .FirstOrDefaultAsync();
            if (productEntity != null)
            {
                productEntity.Status = ProductImageStatus.Inactive;
                productEntity.UpdatedAt = DateTimeOffset.UtcNow;
                _repoManager.ProductImage.UpdateProductImg(productEntity);
                await _repoManager.SaveAsync();
            }
        }


        private async Task UpdateStatusProductHistory(Guid productId)
        {
            var productEntity = await _repoManager.ProductHistory
     .FindByCondition(p => p.Status == ProductHistoryStatus.Active && p.ProductId == productId, false).OrderByDescending(p => p.UpdatedAt)
     .FirstOrDefaultAsync();
            if (productEntity != null)
            {
                productEntity.Status = ProductHistoryStatus.Inactive;
                productEntity.UpdatedAt = DateTimeOffset.UtcNow;
                _repoManager.ProductHistory.UpdateProductHistory(productEntity);
                await _repoManager.SaveAsync();
            }
        }


        private async Task<bool> GetAndCheckIfProductImgByIdAndLink(Guid productId, string link)
        {
            // Lấy bản ghi Product Img có UpdatedAt lớn nhất cho ProductId
            var latestProductImg = await _repoManager.ProductImage
                .FindByCondition(p => p.ProductId.Equals(productId), false)
                .OrderByDescending(p => p.UpdatedAt)
                .FirstOrDefaultAsync();

            if (latestProductImg != null && latestProductImg.Link.Equals(link))
            {
                return true;
            }
            return false;
        }

        private async Task<bool> CheckIfProductHistoryByIdAndPrice(Guid productId, decimal price)
        {

            // Lấy bản ghi ProductHistory có UpdatedAt lớn nhất cho ProductId
            var latestProductHistory = await _repoManager.ProductHistory
                .FindByCondition(p => p.ProductId.Equals(productId), false)
                .OrderByDescending(p => p.UpdatedAt)
                .FirstOrDefaultAsync();

            if (latestProductHistory != null && latestProductHistory.ProductPrice.Equals(price))
            {
                return true;
            }
            return false;
        }
    }
}
