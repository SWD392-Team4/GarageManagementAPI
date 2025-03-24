using AutoMapper;

using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Service.DataShaping;
using GarageManagementAPI.Service.Extension;
using GarageManagementAPI.Shared.DataTransferObjects.ProductAtGarage;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.ErrorsConstant.Workplace;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;

using System.Dynamic;

namespace GarageManagementAPI.Service
{
    public class ProductAtGarageService : IProductAtGarageService
    {
        private readonly IRepositoryManager _repoManager;
        private readonly IMapper _mapper;
        private readonly IDataShaperManager _dataShapper;

        public ProductAtGarageService(IRepositoryManager repoManager, IMapper mapper, IDataShaperManager dataShapper)
        {
            _repoManager = repoManager;
            _mapper = mapper;
            _dataShapper = dataShapper;
        }

        public async Task<Result<ExpandoObject>> GetProductAtGarage(Guid productAtGarageid, bool trackChanges, string? include = null)
        {
            var productAtWarehouse = await this.GetAndCheckProductAtGarage(productAtGarageid, trackChanges, include);
            if (!productAtWarehouse.IsSuccess) return Result<ExpandoObject>.Failure(productAtWarehouse);
            var productEntity = productAtWarehouse.GetValue<ProductAtGarage>();
            var productAtHouseDto = _mapper.Map<ProductAtGarageDto>(productEntity);
            var productAtHouseShapper = _dataShapper.ProductAtGarage.ShapeData(productAtHouseDto, null);
            return Result<ExpandoObject>.Ok(productAtHouseShapper);
        }

        public async Task<Result<IEnumerable<ExpandoObject>>> GetProductAtGarages(ProductAtGarageParameters productAtGarageParameters, bool trackChanges, string? include = null)
        {
            var productsWithMetadata = await _repoManager.ProductAtGarage.GetProductAtGarages(productAtGarageParameters, trackChanges, include);

            var productIds = productsWithMetadata.Select(p => p.Id).ToList();

            var productAtHouseDto = _mapper.Map<IEnumerable<ProductAtGarageDto>>(productsWithMetadata);

            var productQuantities = await _repoManager.ProductAtGarage.GetTotalQuantityByProductIdAsync();

            foreach (var productDto in productAtHouseDto)
            {
                productDto.Quantity = productQuantities.ContainsKey(productDto.ProductId) ? productQuantities[productDto.ProductId] : 0;
            }

            var productAtHouseShapper = _dataShapper.ProductAtGarage.ShapeData(productAtHouseDto, productAtGarageParameters.Fields);
            return Result<IEnumerable<ExpandoObject>>.Ok(productAtHouseShapper, productsWithMetadata.MetaData);
        }

        private async Task<Result<ProductAtGarage>> GetAndCheckProductAtGarage(Guid productAtGarageId, bool trackChanges, string? include = null)
        {
            var productAtGarage = await _repoManager.ProductAtGarage.GetProductAtGarage(productAtGarageId, trackChanges, include);
            if (productAtGarage == null) return productAtGarage.NotFound(productAtGarageId);
            return productAtGarage.OkResukt();
        }

        public async Task<Result<IEnumerable<ExpandoObject>>> GetProductsAtGarage(Guid garageId, ProductAtGarageParameters productAtGarageParameters, bool trackChanges, string? include = null)
        {

            var garage = await _repoManager.Workplace.GetWorkplaceByIdAsync(garageId, trackChanges);
            if (garage is null || !garage.WorkplaceType.Equals(WorkplaceType.Garage))
                return Result<IEnumerable<ExpandoObject>>.NotFound(WorkplaceErrors.GetGarageNotFound(garageId));

            var productQuantities = await _repoManager.ProductAtGarage.GetTotalQuantityByProductIdAsync(garageId);

            var productAtGarages = await _repoManager.ProductAtGarage.GetProductAtGarages(garageId, productAtGarageParameters, trackChanges, include);

            var productAtGaragesDto = _mapper.Map<IEnumerable<ProductAtGarageDto>>(productAtGarages);

            foreach (var productDto in productAtGaragesDto)
            {
                productDto.Quantity = productQuantities.ContainsKey(productDto.ProductId) ? productQuantities[productDto.ProductId] : 0;
            }

            var productAtHouseShapper = _dataShapper.ProductAtGarage.ShapeData(productAtGaragesDto, productAtGarageParameters.Fields);

            return Result<IEnumerable<ExpandoObject>>.Ok(productAtHouseShapper, productAtGarages.MetaData);
        }

        public async Task<Result<ExpandoObject>> GetProductByBarcodeByProductAtGarageAsync(string barcode, Guid garageId, ProductParameters productParameters, bool trackChanges, string? include = null)
        {
            var productResult = await this.GetAndCheckIfProductByBarCodeGarageExist(barcode, trackChanges, include);

            if (!productResult.IsSuccess)
                return Result<ExpandoObject>.NotFound(productResult.Errors!);

            var productEntity = productResult.GetValue<ProductAtGarage>();

            var quantity = await _repoManager.ProductAtGarage.GetTotalStockForProduct(productEntity.ProductId, garageId);

            var productsDto = _mapper.Map<ProductAtGarageDto>(productEntity);
            productsDto.Quantity = quantity;

            var productShaped = _dataShapper.ProductAtGarage.ShapeData(productsDto, productParameters.Fields);

            return Result<ExpandoObject>.Ok(productShaped);
        }

        private async Task<Result<ProductAtGarage>> GetAndCheckIfProductByBarCodeGarageExist(string barcode, bool trackChanges, string? include)
        {
            var product = await _repoManager.ProductAtGarage.GetProductAtGarage(barcode, false, include);
            if (product == null)
                return product.NotFoundBarcode(barcode);

            return product.OkResult();
        }

    }
}
