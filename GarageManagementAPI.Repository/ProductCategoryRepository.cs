using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository
{
    public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public async Task CreateProductCategoryAsync(ProductCategory productCategory)
        {
            await base.CreateAsync(productCategory);
        }


        public void UpdateProductCategoryAsync(ProductCategory productCategory)
        {
            base.Update(productCategory);
        }

        public async Task<ProductCategory?> GetProductCategoryByIdAsync(Guid productCategoryId, bool trackChanges, string? include = null)
        {
            var productCategory = include is null ?
            await FindByCondition(u => u.Id.Equals(productCategoryId), trackChanges).SingleOrDefaultAsync() :
            await FindByCondition(u => u.Id.Equals(productCategoryId), trackChanges).IsInclude(include).SingleOrDefaultAsync();

            return productCategory;
        }
        public async Task<ProductCategory?> GetProductByIdAndNameAsync(string name, Guid? productCatrgoryId, bool trackChanges)
        {
            var productCatrgory = productCatrgoryId is null ?
            await FindByCondition(p => p.Id.Equals(productCatrgoryId), trackChanges).SingleOrDefaultAsync() :
            await FindByCondition(p => !p.Id.Equals(productCatrgoryId) && p.Category.ToLower().Equals(name.ToLower()), trackChanges).SingleOrDefaultAsync();
            return productCatrgory;
        }
        public async Task<PagedList<ProductCategory>> GetProductCategoriesAsync(ProductCategoryParameters productCategoryParameters, bool trackChanges, string? include = null)
        {
            // Lọc và sắp xếp danh sách ProductCategorys theo các điều kiện
            var productCategories = await FindByCondition(b =>
                    (string.IsNullOrEmpty(productCategoryParameters.Category) || b.Category.Contains(productCategoryParameters.Category)),
                    trackChanges)
                .SearchByName(productCategoryParameters.Category) // Tìm kiếm theo tên sản phẩm
                .SearchByDate(productCategoryParameters.CreatedAt)
                .SearchByDate(productCategoryParameters.UpdatedAt)
                .SearchByStatus(productCategoryParameters.Status)
                .Sort(productCategoryParameters.OrderBy)
                .IsInclude(include)
                .ToListAsync();


            // Trả về kết quả dưới dạng PagedList
            return PagedList<ProductCategory>.ToPagedList(
                productCategories,
                productCategoryParameters.PageNumber,
                productCategoryParameters.PageSize
            );
        }
    }
}
