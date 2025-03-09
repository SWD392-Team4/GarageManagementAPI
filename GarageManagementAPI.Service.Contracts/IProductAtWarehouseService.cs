using GarageManagementAPI.Shared.DataTransferObjects.ProductAtWarehouse;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;
using System.Dynamic;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IProductAtWarehouseService
    {
        public Task<Result<ExpandoObject>> GetProductAtWarehouse(Guid productId, bool trackChanges, string? include = null);
        public Task<Result<IEnumerable<ExpandoObject>>> GetProductAtWarehouses(ProductAtWarehouseParameters productAtWarehouseParameters, bool trackChanges, string? include = null);
        public Task<Result<ProductAtWarehouseDto>> CreateProductAtWareHouse(ProductAtWarehouseDtoForCreation productAtWarehouseDtoForCreation);
        public Task<Result> UpdateProductAtWareHouse(Guid productIdAtWarehouse,ProductAtWarehouseDtoForUpdate productAtWarehouseDtoForUpdate, bool trackChanges);
    }
}
