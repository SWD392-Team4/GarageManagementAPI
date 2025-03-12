using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IProductAtWarehouseRepository
    {
        Task<ProductAtWarehouse?> GetProductAtWarehouse(Guid productAtWarehouseId, bool trackChanges, string? include = null);
        Task<PagedList<ProductAtWarehouse>> GetProductAtWarehouses(ProductAtWarehouseParameters productAtWarehouseParameters, bool trackChanges, string? include = null);
        public Task<List<(Guid ProductAtWarehouseId, int DeductedQuantity)>> DeductProductQuantityFromWarehouseAsync(
        Guid productId, Guid warehouseId, int quantity);
        Task<int> GetTotalStockForProduct(Guid productId, Guid warehouseId);
        Task CreateProductAtWarehouse(ProductAtWarehouse productAtWarehouse);
        void UpdateProductAtWarehouse(ProductAtWarehouse productAtWarehouse);
    }
}
