using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IProductCategoryRepository : IRepositoryBase<ProductCategory>
    {
        Task<ProductCategory?> GetProductCategoryByIdAsync(Guid productCategoryId, bool trackChanges, string? include = default);
        Task<PagedList<ProductCategory>> GetProductCategoriesAsync(ProductCategoryParameters productCategoryParameters, bool trackChanges, string? include = default);

        Task CreateProductCategoryAsync(ProductCategory productCategory);
        void UpdateProductCategoryAsync(ProductCategory productCategory);
    }
}
