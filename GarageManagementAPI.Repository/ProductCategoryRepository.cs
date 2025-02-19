using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Repository.Extensions;

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
            Console.WriteLine(include);
            var productCategory = include is null ?
            await FindByCondition(u => u.Id.Equals(productCategoryId), trackChanges).SingleOrDefaultAsync() :
            await FindByCondition(u => u.Id.Equals(productCategoryId), trackChanges).IsInclude(include).SingleOrDefaultAsync();

            return productCategory;
        }

        public async Task<PagedList<ProductCategory>> GetProductCategoriesAsync(ProductCategoryParameters productCategoryParameters, bool trackChanges, string? include = null)
        {
            // Lọc và sắp xếp danh sách ProductCategorys theo các điều kiện
            var productCategoriesQuery = FindByCondition(b =>
                    (string.IsNullOrEmpty(productCategoryParameters.Category) || b.Category.Contains(productCategoryParameters.Category)),
                    trackChanges)
                .SearchByName(productCategoryParameters.Category) // Tìm kiếm theo tên sản phẩm
                .SearchByDate(productCategoryParameters.CreatedAt)
                .SearchByDate(productCategoryParameters.UpdatedAt)
                .SearchByStatus(productCategoryParameters.Status)
                .Sort(productCategoryParameters.OrderBy)
                .IsInclude(include)
                .AsQueryable();

            // Lấy danh sách sản phẩm sau khi phân trang
            var productCategories = await productCategoriesQuery
                .Skip((productCategoryParameters.PageNumber - 1) * productCategoryParameters.PageSize)
                .Take(productCategoryParameters.PageSize)
                .ToListAsync();

            // Lấy tổng số bản ghi để tính toán tổng số trang
            var count = await productCategoriesQuery.CountAsync();

            // Trả về kết quả dưới dạng PagedList
            return new PagedList<ProductCategory>(
                productCategories,
                count,
                productCategoryParameters.PageNumber,
                productCategoryParameters.PageSize
            );
        }

    }
}
