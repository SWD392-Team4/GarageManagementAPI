using AutoMapper;
using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Service.Extension;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.DataTransferObjects.Product;
using GarageManagementAPI.Shared.ErrorsConstant.Product;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;
using System.Dynamic;
using GarageManagementAPI.Shared.Enums.SystemStatuss;

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

            var productDtoToReturn = _mapper.Map<ProductDto>(productEntity);

            return productDtoToReturn.CreatedResult();
        }

        public async Task<Result<ExpandoObject>> GetProductByIdAsync(Guid productId, ProductParameters productParameters, bool trackChanges, string? include = null)
        {
            var productResult = await GetAndCheckIfProductExist(productId, trackChanges, include);

            if (!productResult.IsSuccess)
                return Result<ExpandoObject>.NotFound(productResult.Errors!);

            var productEntity = productResult.GetValue<ProductDtoWithPrice>();

            var productsDto = _mapper.Map<ProductDtoWithPrice>(productEntity);

            var userShaped = _dataShaper.Product.ShapeData(productsDto, productParameters.Fields);

            return Result<ExpandoObject>.Ok(userShaped);
        }

        public async Task<Result<ExpandoObject>> GetProductByBarcodeAsync(string barcode, ProductParameters productParameters, bool trackChanges, string? include = null)
        {
            var productResult = await GetAndCheckIfProductByBarCodeExist(barcode, trackChanges, include);

            if (!productResult.IsSuccess)
                return Result<ExpandoObject>.NotFound(productResult.Errors!);

            var productEntity = productResult.GetValue<ProductDtoWithPrice>();

            var productsDto = _mapper.Map<ProductDtoWithPrice>(productEntity);

            var productShaped = _dataShaper.Product.ShapeData(productsDto, productParameters.Fields);

            return Result<ExpandoObject>.Ok(productShaped);
        }

        public async Task<Result<ProductDtoForUpdate>> GetProductForPartiallyUpdate(Guid productId, bool trackChanges, string? include =null)
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

            var productsDto = _mapper.Map<IEnumerable<ProductDtoWithPrice>>(productsWithMetadata);

            var productsShaped = _dataShaper.Product.ShapeData(productsDto, productParameters.Fields);

            return Result<IEnumerable<ExpandoObject>>.Ok(productsShaped, productsWithMetadata.MetaData);
        }

        public async Task<Result> UpdateProduct(Guid productId, ProductDtoForUpdate productDtoForUpdate, bool trackChanges, string? include = null)
        {
            var productResult = await GetAndCheckIfProductExist(productId, trackChanges, include);
            var check = await CheckIfProductExistByNameAndBrandOrBarCodeForUpdate(productDtoForUpdate, productId);
            if (check)
                return Result<ProductDto>.BadRequest([ProductErrors.GetProductNameUpdateAlreadyExistError(productDtoForUpdate)]);
            if (!productResult.IsSuccess)
                return Result<ProductDto>.Failure(productResult.StatusCode, productResult.Errors!);
            var productEntity = productResult.GetValue<Product>();

            _mapper.Map(productDtoForUpdate, productEntity);

            productEntity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            await _repoManager.SaveAsync();

            return Result.NoContent();
        }

        private async Task<bool> CheckIfProductExistByNameAndBrandOrBarCode(ProductDtoForCreation productDtoForCreation)
        {
            var brandId = productDtoForCreation.BrandId;
            var barcode = productDtoForCreation.ProductBarcode!.Trim();
            var name = productDtoForCreation.ProductName!.Trim();

            var exists = await _repoManager.Product.FindByCondition(p =>
                p.BrandId.Equals(brandId) &&
                 p.ProductName.Trim().Equals(name) ||
                 p.ProductBarcode.Trim().Equals(barcode),
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

        private async Task<Result<ProductDtoWithPrice>> GetAndCheckIfProductExist(Guid productId, bool trackChanges, string include)
        {
            var product = await _repoManager.Product.GetProductByIdAsync(productId, trackChanges, include);
            if (product == null)
                return product.NotFoundWithPriceId(productId);

            return product.OkResultWithPrice();
        }

        private async Task<Result<ProductDtoWithPrice>> GetAndCheckIfProductByBarCodeExist(string barcode, bool trackChanges, string? include)
        {
            var product = await _repoManager.Product.GetProductByBarCodeAsync(barcode, trackChanges, include);
            if (product == null)
                return product.NotFoundBarCode(barcode);

            return product.OkResultWithPrice();
        }
    }
}
