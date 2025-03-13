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
using GarageManagementAPI.Shared.DataTransferObjects.Product;

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
            var productNameAndBarCodeResult = await CheckIfProductExistByNameAndBrandOrBarCode(productDtoForCreation);
            if (productNameAndBarCodeResult)
                return Result<ProductDto>.BadRequest([ProductErrors.GetProductNameAlreadyExistError(productDtoForCreation)]);

            var brandResult = await GetAndCheckIfBrandIsExist(productDtoForCreation.BrandId);
            if (brandResult)
                return Result<ProductDto>.BadRequest([ProductErrors.GetBrandIsNotFound(productDtoForCreation.BrandId)]);

            var productCategoryResult = await GetAndCheckIfProductCategoryIsExist(productDtoForCreation.ProductCategoryId);
            if (productCategoryResult)
                return Result<ProductDto>.BadRequest([ProductErrors.GetProductCategoryIsNotFound(productDtoForCreation.ProductCategoryId)]);

            var productEntity = _mapper.Map<Product>(productDtoForCreation);

            productEntity.Status = ProductStatus.Inactive;

            if (string.IsNullOrWhiteSpace(productEntity.ProductBarcode)) productEntity.ProductBarcode = this.GenerateBarcode();

            await _repoManager.Product.CreateAsync(productEntity);
            await CreateProductHistoryAsync(productEntity);

            await _repoManager.SaveAsync();


            var productDtoToReturn = _mapper.Map<ProductDto>(productEntity);

            return productDtoToReturn.CreatedResult();
        }

        public async Task<Result> UpdateProduct(Guid productId, ProductDtoForUpdate productDtoForUpdate, bool trackChanges, string? include = null)
        {
            var productResult = await GetAndCheckIfProductExist(productId, trackChanges);
            if (!productResult.IsSuccess)
                return Result<ProductDtoForUpdate>.Failure(productResult.StatusCode, productResult.Errors!);

            var brandResult = await GetAndCheckIfBrandIsExist(productDtoForUpdate.BrandId);
            if (brandResult)
                return Result<ProductDto>.BadRequest([ProductErrors.GetBrandIsNotFound(productDtoForUpdate.BrandId)]);

            var productCategoryResult = await GetAndCheckIfProductCategoryIsExist(productDtoForUpdate.ProductCategoryId);
            if (productCategoryResult)
                return Result<ProductDto>.BadRequest([ProductErrors.GetProductCategoryIsNotFound(productDtoForUpdate.ProductCategoryId)]);

            var productCategoryResult = await GetAndCheckIfProductCategoryIsExist(productDtoForUpdate.ProductCategoryId);
            if (productCategoryResult)
                return Result<ProductDto>.BadRequest([ProductErrors.GetProductCategoryIsNotFound(productDtoForUpdate.ProductCategoryId)]);

            var productEntity = productResult.GetValue<Product>();

            if (!productEntity.ProductPrice.Equals(productDtoForUpdate.ProductPrice))
            {
                _mapper.Map(productDtoForUpdate, productEntity);
                await CreateProductHistoryAsync(productEntity);

            }
            else
                _mapper.Map(productDtoForUpdate, productEntity);

            productEntity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            //Create Product History

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

        public async Task<IEnumerable<ProductWithQuantityDto>> GetProductsByWarehouseIdWithQuantityAsync(
      Guid warehouseId, bool trackChanges, string? include = null)
        {
            var productsPagedList = await _repoManager.Product.GetProductsByWarehouseIdAsync(warehouseId, false);

            var productIds = productsPagedList.Select(p => p.Id).ToList();

            var productQuantities = await _repoManager.ProductAtWarehouse.GetTotalStockByProductIdsAsync(productIds, warehouseId);

            var productsWithQuantities = productsPagedList
                .Select(product => new ProductWithQuantityDto
                {
                    Id = product.Id,
                    ProductName = product.ProductName,
                    ProductBarcode = product.ProductBarcode,
                    ProductCategoryId = product.ProductCategoryId,
                    BrandId = product.BrandId,
                    ProductPrice = product.ProductPrice,
                    ProductDescription = product.ProductDescription,
                    Status = product.Status,
                    CreatedAt = product.CreatedAt,
                    UpdatedAt = product.UpdatedAt,
                    TotalQuantity = productQuantities.ContainsKey(product.Id) ? productQuantities[product.Id] : 0
                })
                .ToList();

            return productsWithQuantities;
        }


        private async Task<bool> CheckIfProductExistByNameAndBrandOrBarCode(ProductDtoForCreation productDtoForCreation)
        {
            var brandId = productDtoForCreation.BrandId;
            var productCategoryId = productDtoForCreation.ProductCategoryId;
            var name = productDtoForCreation.ProductName!.ToLower();

            var exists = await _repoManager.Product.FindByCondition(p =>
                p.BrandId.Equals(brandId) && p.ProductCategoryId.Equals(productCategoryId) &&
                 p.ProductName.ToLower().Equals(name),
                false).AnyAsync();

            return exists;
        }

        private async Task<bool> GetAndCheckIfBrandIsExist(Guid brandId)
        {
            var brand = await _repoManager.Brand.GetBrandByIdAsync(brandId, false);
            if (brand == null) return true;
            return false;

        }
        private async Task<bool> GetAndCheckIfProductCategoryIsExist(Guid productCategoryId)
        {
            var productCategory = await _repoManager.ProductCategory.GetProductCategoryByIdAsync(productCategoryId, false);
            if (productCategory == null) return true;
            return false;
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

        private async Task CreateProductHistoryAsync(Product product)
        {
            var productHistory = _mapper.Map<ProductHistory>(product);

            await _repoManager.ProductHistory.CreateAsync(productHistory);
        }

        private string GenerateBarcode()
        {
            return $"GID-{Guid.NewGuid().ToString().Substring(0, 8)}";
        }
    }
}
