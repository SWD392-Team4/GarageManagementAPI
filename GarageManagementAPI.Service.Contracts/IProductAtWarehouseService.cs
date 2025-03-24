using GarageManagementAPI.Shared.DataTransferObjects.ProductAtWarehouse;
using System.Dynamic;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IProductAtWarehouseService
    {
        public Task<Result<ExpandoObject>> GetProductAtWarehouse(Guid productId, bool trackChanges, string? include = null);
        public Task<Result<IEnumerable<ExpandoObject>>> GetProductAtWarehouses(Guid warehourseId, ProductAtWarehouseParameters productAtWarehouseParameters, bool trackChanges, string? include = null);
        public Task<Result> UpdateProductAtWareHouse(Guid productIdAtWarehouse,ProductAtWarehouseDtoForUpdate productAtWarehouseDtoForUpdate, bool trackChanges);

        Task<Result<ExpandoObject>> GetProductAtWarehouses(Guid warehourseId, string barcode, ProductAtWarehouseParameters productAtWarehouseParameters, bool trackChanges, string? include = null);
    }
}
