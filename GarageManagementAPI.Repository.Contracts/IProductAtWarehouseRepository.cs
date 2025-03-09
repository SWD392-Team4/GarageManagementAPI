using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IProductAtWarehouseRepository
    {
        Task<ProductAtWarehouse?> GetProductAtWarehouse(Guid productId, bool trackChanges, string? include = null);
        Task<PagedList<ProductAtWarehouse>> GetProductAtWarehouses(ProductAtWarehouseParameters productAtWarehouseParameters, bool trackChanges, string? include = null);
        Task CreateProductAtWarehouse(ProductAtWarehouse productAtWarehouse);
        void UpdateProductAtWarehouse(ProductAtWarehouse productAtWarehouse);
    }
}
