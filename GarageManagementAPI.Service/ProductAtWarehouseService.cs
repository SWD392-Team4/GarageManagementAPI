using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Service.Extension;
using GarageManagementAPI.Shared.DataTransferObjects.ProductAtWarehouse;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;
using System.Dynamic;

namespace GarageManagementAPI.Service
{
    public class ProductAtWarehouseService : IProductAtWarehouseService
    {
        public readonly IRepositoryManager _repository;
        public readonly IMapper _mapper;
        public readonly IDataShaperManager _dataShaper;
        public ProductAtWarehouseService(IRepositoryManager repository, IMapper mapper, IDataShaperManager dataShaper)
        {
            _repository = repository;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }
      

        public async Task<Result<ExpandoObject>> GetProductAtWarehouse(Guid productId, bool trackChanges, string? include = null)
        {
            var productAtWarehouseResult = await this.GetAndCheckProductAtWarehouseIsExist(productId, trackChanges, include);
            if (!productAtWarehouseResult.IsSuccess) return Result<ExpandoObject>.Failure(productAtWarehouseResult.StatusCode, productAtWarehouseResult.Errors!);
            var productEntity = productAtWarehouseResult.GetValue<ProductAtWarehouse>();
            var productAtWarehouseDto = _mapper.Map<ProductAtWarehouseDto>(productEntity);
            var productAtWarehouseShaper = _dataShaper.ProductAtWarehouse.ShapeData(productAtWarehouseDto, null);
            return Result<ExpandoObject>.Ok(productAtWarehouseShaper);
        }

        public async Task<Result<IEnumerable<ExpandoObject>>> GetProductAtWarehouses(ProductAtWarehouseParameters productAtWarehouseParameters, bool trackChanges, string? include = null)
        {
            var productAtWarehousesWithMetadata = await _repository.ProductAtWarehouse.GetProductAtWarehouses(productAtWarehouseParameters, trackChanges, include);
            var productAtWarehouseDtos = _mapper.Map<IEnumerable<ProductAtWarehouseDto>>(productAtWarehousesWithMetadata);
            var productsShapper = _dataShaper.ProductAtWarehouse.ShapeData(productAtWarehouseDtos, productAtWarehouseParameters.Fields);
            return Result<IEnumerable<ExpandoObject>>.Ok(productsShapper, productAtWarehousesWithMetadata.MetaData);
        }

        public async Task<Result> UpdateProductAtWareHouse(Guid productAtWarehouseId, ProductAtWarehouseDtoForUpdate productAtWarehouseDtoForUpdate, bool trackChanges)
        {
            var productAtWarehouseReuslt = await this.GetAndCheckProductAtWarehouseIsExist(productAtWarehouseId, trackChanges);
            if (!productAtWarehouseReuslt.IsSuccess) return Result<ProductAtWarehouse>.Failure(productAtWarehouseReuslt.StatusCode, productAtWarehouseReuslt.Errors!);

            var productAtWarehouseEntity = productAtWarehouseReuslt.GetValue<ProductAtWarehouse>();
            _mapper.Map(productAtWarehouseDtoForUpdate, productAtWarehouseEntity);
            productAtWarehouseEntity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            await _repository.SaveAsync();
            return Result.NoContent();
        }

        public async Task<Result<ProductAtWarehouse>> GetAndCheckProductAtWarehouseIsExist(Guid productId, bool trackChanges, string? include = null)
        {
            var productAtWarehouse = await _repository.ProductAtWarehouse.GetProductAtWarehouse(productId, trackChanges, include);
            if (productAtWarehouse == null) return productAtWarehouse.NotFoundResult(productId);
            return productAtWarehouse.OkResult();
        }
        public async Task<bool> GetAndCheckGoodsReceivedDetailIsExist(Guid goodsReicevedId)
        {
            var goodsReeceived = await _repository.GoodsReceivedDetail.GetGoodsReceivedDetailAsync(goodsReicevedId, false);
            if (goodsReeceived == null) return false;
            return true;
        }
    }
}
