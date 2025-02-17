using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.Product;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        Task<Product?> GetProductByIdAsync(Guid productId, bool trackChanges, string? include = default);
        Task<ProductDtoFull?> GetProductFullByIdAsync(Guid productId, bool trackChanges, string? include = default);

        Task<ProductDtoFull?> GetProductFulllByBarCodeAsync(string barcode, bool trackChanges, string? include = default);
        Task<PagedList<ProductDtoFull>> GetProductsAsync(ProductParameters productParameters, bool trackChanges, string? include = default);

        Task CreateProductAsync(Product product);
        void UpdateProductAsync(Product product);
    }
}
