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
using GarageManagementAPI.Shared.ErrorsConstant.CarPart;
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

            if (string.IsNullOrWhiteSpace(productEntity.ProductBarcode))
                productEntity.ProductBarcode = this.GenerateBarcode();

            if (productDtoForCreation.CarPartIds != null && productDtoForCreation.CarPartIds.Any())
            {
                var carparts = await _repoManager.CarPart.GetCarPartsAsync(productDtoForCreation.CarPartIds!, true);
                if (carparts.Count() != productDtoForCreation.CarPartIds.Count())
                {
                    Result<ProductDto>.BadRequest([CarPartErrors.GetCarPartFoundNotMatchWithIdsError(productDtoForCreation.CarPartIds)]);
                }
                productEntity.CarParts = [.. carparts];
            }


            if (productDtoForCreation.CarModelIds != null && productDtoForCreation.CarModelIds.Any())
            {
                var carModels = await _repoManager.CarModel.GetModelsAsync(productDtoForCreation.CarModelIds!, true);
                if (carModels.Count() != productDtoForCreation.CarModelIds!.Count())
                {
                    Result<ProductDto>.BadRequest([CarPartErrors.GetCarModelFoundNotMatchWithIdsError(productDtoForCreation.CarModelIds)]);
                }
                productEntity.CarModels = [.. carModels];
            }

            await _repoManager.Product.CreateAsync(productEntity);
            await CreateProductHistoryAsync(productEntity);

            await _repoManager.SaveAsync();


            var productDtoToReturn = _mapper.Map<ProductDto>(productEntity);

            return productDtoToReturn.CreatedResult();
        }

        public async Task<Result> UpdateProduct(Guid productId, ProductDtoForUpdate productDtoForUpdate, bool trackChanges, string? include = null)
        {
            var productResult = await GetAndCheckIfProductExist(productId, trackChanges, "CarModels,CarParts");
            if (!productResult.IsSuccess)
                return Result<ProductDtoForUpdate>.Failure(productResult.StatusCode, productResult.Errors!);

            var brandResult = await GetAndCheckIfBrandIsExist(productDtoForUpdate.BrandId);
            if (brandResult)
                return Result<ProductDto>.BadRequest([ProductErrors.GetBrandIsNotFound(productDtoForUpdate.BrandId)]);

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

            if (productDtoForUpdate.CarPartIds != null && productDtoForUpdate.CarPartIds.Any())
            {
                var existingCarParts = productEntity.CarParts.ToList();

                var newCarParts = await _repoManager.CarPart.GetCarPartsAsync(productDtoForUpdate.CarPartIds!, true);

                if (newCarParts.Count() != productDtoForUpdate.CarPartIds.Count())
                {
                    return Result<ProductDto>.BadRequest([CarPartErrors.GetCarPartFoundNotMatchWithIdsError(productDtoForUpdate.CarPartIds)]);
                }

                var carPartsToRemove = existingCarParts.Where(cp => !productDtoForUpdate.CarPartIds.Contains(cp.Id)).ToList();
                foreach (var carPart in carPartsToRemove)
                {
                    productEntity.CarParts.Remove(carPart);
                }

                var carPartsToAdd = newCarParts
                                   .Where(cp => !existingCarParts.Any(e => e.Id == cp.Id))
                                   .ToList();
                foreach (var carPart in carPartsToAdd)
                {
                    productEntity.CarParts.Add(carPart);
                }

            }


            if (productDtoForUpdate.CarModelIds != null && productDtoForUpdate.CarModelIds.Any())
            {
                var existingModels = productEntity.CarModels.ToList();

                var carModels = await _repoManager.CarModel.GetModelsAsync(productDtoForUpdate.CarModelIds!, true);

                if (carModels.Count() != productDtoForUpdate.CarModelIds!.Count())
                {
                    return Result<ProductDto>.BadRequest([CarPartErrors.GetCarModelFoundNotMatchWithIdsError(productDtoForUpdate.CarModelIds!)]);
                }

                var carModelsToRemove = existingModels
                    .Where(cm => !productDtoForUpdate.CarModelIds!.Contains(cm.Id))
                    .ToList();

                foreach (var carModel in carModelsToRemove)
                {
                    productEntity.CarModels.Remove(carModel);
                }

                var carModelsToAdd = carModels
                                    .Where(cm => !existingModels.Any(e => e.Id == cm.Id))
                                    .ToList();

                foreach (var carModel in carModelsToAdd)
                {
                    productEntity.CarModels.Add(carModel);
                }
            }

            productEntity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();

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

        public async Task<Result<ExpandoObject>> GetProductByIdAsync(Guid productId, Guid garageId,bool trackChanges, string? include = null)
        {
            var productResult = await GetAndCheckIfProductExist(productId, trackChanges, include);

            if (!productResult.IsSuccess)
                return Result<ExpandoObject>.NotFound(productResult.Errors!);

            var productsEntity = productResult.GetValue<Product>();

            var quantity = await _repoManager.ProductAtGarage.GetTotalStockForProduct(productId, garageId);

            var productDto = _mapper.Map<ProductDto>(productsEntity);

            productDto.TotalQuantity = quantity;

            var productShaped = _dataShaper.Product.ShapeData(productDto, null);

            return Result<ExpandoObject>.Ok(productShaped);
        }

        public async Task<Result<ExpandoObject>> GetProductAsync(bool trackChanges, string? include = null)
        {
            var productResult = await _repoManager.Product.GetProductWitMaxPrice(trackChanges, include);

            var productDto = _mapper.Map<ProductDto>(productResult);

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

        public async Task<Result<ExpandoObject>> GetProductByBarcodeByProductAtGarageAsync(string barcode, Guid garageId, ProductParameters productParameters, bool trackChanges, string? include = null)
        {
            var productResult = await this.GetAndCheckIfProductByBarCodeGarageExist(barcode, trackChanges, include);

            if (!productResult.IsSuccess)
                return Result<ExpandoObject>.NotFound(productResult.Errors!);

            var productEntity = productResult.GetValue<Product>();

            var quantity = await _repoManager.ProductAtGarage.GetTotalStockForProduct(productEntity.Id, garageId);

            var productsDto = _mapper.Map<ProductDto>(productEntity);

            productsDto.TotalQuantity = quantity;

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

        public async Task<Result<IEnumerable<ExpandoObject>>> GetProductsByWarehouseIdWithQuantityAsync(
      Guid warehouseId, ProductParameters productParameters, bool trackChanges, string? include = null)
        {
            var productsWithMetadata = await _repoManager.Product.GetProductsByWarehouseIdAsync(warehouseId, productParameters, false, include);

            var productIds = productsWithMetadata.Select(p => p.Id).ToList();

            var productQuantities = await _repoManager.ProductAtWarehouse.GetTotalStockByProductIdsAsync(productIds, warehouseId);

            var productsWithQuantities = _mapper.Map<IEnumerable<ProductDto>>(productsWithMetadata);

            foreach (var productDto in productsWithQuantities)
            {
                productDto.TotalQuantity = productQuantities.ContainsKey(productDto.Id) ? productQuantities[productDto.Id] : 0;
            }
            var productsShaped = _dataShaper.Product.ShapeData(productsWithQuantities, productParameters.Fields);
            return Result<IEnumerable<ExpandoObject>>.Ok(productsShaped, productsWithMetadata.MetaData);
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
            private async Task<Result<Product>> GetAndCheckIfProductByBarCodeGarageExist(string barcode, bool trackChanges, string? include)
            {
                var product = await _repoManager.ProductAtGarage.GetProductAtGarage(barcode, false); 
                if (product == null)
                    return product.NotFoundBarcode(barcode);

                return product.OkResult();
            }

            public async Task<Result<IEnumerable<ProductDto>>> GetProductsByCarModelAndPart(Guid carModelId, Guid carPartId, Guid userId, bool trackChanges, string? include = null)
        {
            var user = await _repoManager.User.GetUserByIdAsync(userId, false, "EmployeeInfo");

            var garageId = user!.EmployeeInfo!.WorkplaceId ?? throw new Exception("GarageId cannot be null.");

            var productsAtGarage = await _repoManager.ProductAtGarage.GetProductAtGarages(garageId, trackChanges, include);

            var products = await _repoManager.Product.GetProductsByCarModelAndPart(carModelId, carPartId, trackChanges, include);

            var commonProducts = products.IntersectBy(productsAtGarage.Select(p => p.ProductId), p => p.Id).ToList();

            var productDtos = _mapper.Map<IEnumerable<ProductDto>>(commonProducts);

            foreach (var productDto in productDtos)
            {
                var quantity = await _repoManager.ProductAtGarage.GetTotalStockForProduct(productDto.Id, garageId);
                productDto.TotalQuantity = quantity;
            }

            return Result<IEnumerable<ProductDto>>.Success(productDtos, System.Net.HttpStatusCode.OK);
        }


        public async Task<Result<IEnumerable<ProductDto>>> GetProductsByCarModelAndPartGarage(Guid carModelId, Guid carPartId, Guid garageId, bool trackChanges, string? include = null)
        {
            var productsAtGarage = await _repoManager.ProductAtGarage.GetProductAtGarages(garageId, trackChanges, include);

            var products = await _repoManager.Product.GetProductsByCarModelAndPart(carModelId, carPartId, trackChanges, include);

            var commonProducts = products.IntersectBy(productsAtGarage.Select(p => p.ProductId), p => p.Id).ToList();

            var productDtos = _mapper.Map<IEnumerable<ProductDto>>(commonProducts);

            foreach (var productDto in productDtos)
            {
                var quantity = await _repoManager.ProductAtGarage.GetTotalStockForProduct(productDto.Id, garageId);
                productDto.TotalQuantity = quantity;
            }

            return Result<IEnumerable<ProductDto>>.Success(productDtos, System.Net.HttpStatusCode.OK);
        }


        private async Task CreateProductHistoryAsync(Product product)
        {
            var productHistory = _mapper.Map<ProductHistory>(product);

            await _repoManager.ProductHistory.CreateAsync(productHistory);
        }

        private string GenerateBarcode()
        {
            return $"{DateTime.UtcNow:yyyyMMddHHmmss}";
        }




        //Dashboard 

        public async Task<IEnumerable<ProductDto>> GetLowStockProducts(int threshold, Guid? warehouseId, bool trackChanges)
        {
            var productResult = await _repoManager.GoodsReceivedDetail.GetLowStockProducts(threshold, warehouseId, trackChanges);
            var productDto = _mapper.Map<IEnumerable<ProductDto>>(productResult);
            return productDto;
        }

    }
}
