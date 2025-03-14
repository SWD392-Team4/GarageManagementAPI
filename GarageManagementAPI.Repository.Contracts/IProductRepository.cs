using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        Task<Product?> GetProductByIdAsync(Guid productId, bool trackChanges, string? include = default);
        Task<Product?> GetProductByBarCodeAsync(string barcode, bool trackChanges, string? include = default);
        Task<PagedList<Product>> GetProductsAsync(ProductParameters productParameters, bool trackChanges, string? include = default);
        public Task<Product?> GetProductWitMaxPrice(bool trackChanges, string? inlude = null);
        Task<IEnumerable<Product>> GetProductsAsync(IEnumerable<Guid> productIds, bool trackChanges);
        public Task<IEnumerable<Product>> GetProductsByWarehouseIdAsync(Guid warehouseId, bool trackChanges, string? include = default);
        public Task<IEnumerable<Product>> GetProductsByCarModelAndPart(Guid carModelId, Guid carPartId, bool trackChanges, string? include = default);
    }
}
