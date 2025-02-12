using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.Product;
using GarageManagementAPI.Shared.DataTransferObjects.ProductHistory;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        Task<ProductDtoWithPrice> GetProductByIdAsync(Guid productId, bool trackChanges, string? include = default);

        Task<Product?> GetProductByBarCodeAsync(string barcode, bool trackChanges, string? include = default);
        Task<PagedList<ProductDtoWithPrice>> GetProductsAsync(ProductParameters productParameters, bool trackChanges, string? include = default);

        Task CreateProductAsync(Product product);
        void UpdateProductAsync(Product product);
    }
}
