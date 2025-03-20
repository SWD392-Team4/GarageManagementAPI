using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IProductAtWarehouseRepository
    {
        Task<ProductAtWarehouse?> GetProductAtWarehouse(Guid productAtWarehouseId, bool trackChanges, string? include = null);
        Task<PagedList<ProductAtWarehouse>> GetProductAtWarehouses(Guid warehourseId, ProductAtWarehouseParameters productAtWarehouseParameters, bool trackChanges, string? include = null);
        public Task<List<(Guid ProductAtWarehouseId, int DeductedQuantity)>> DeductProductQuantityFromWarehouseAsync(
        Guid productId, Guid warehouseId, int quantity);
        public Task<Dictionary<Guid, int>> GetTotalStockByProductIdsAsync(List<Guid> productIds, Guid warehouseId);

        Task<int> GetTotalStockForProduct(Guid productId, Guid warehouseId);
        Task CreateProductAtWarehouse(ProductAtWarehouse productAtWarehouse);
        void UpdateProductAtWarehouse(ProductAtWarehouse productAtWarehouse);
    }
}
