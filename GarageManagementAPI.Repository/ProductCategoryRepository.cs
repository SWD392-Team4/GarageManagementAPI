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
            var productCategory = include is null ?
            await FindByCondition(u => u.Id.Equals(productCategoryId), trackChanges).SingleOrDefaultAsync() :
            await FindByCondition(u => u.Id.Equals(productCategoryId), trackChanges).Include(include).SingleOrDefaultAsync();

            return productCategory;
        }


        public async Task<PagedList<Product>> GetProductByIdAsync(Guid productCategoryId, bool trackChanges, string? include = null)
        {
            {
                // Lọc và sắp xếp danh sách ProductCategorys theo các điều kiện
                var productCategoryQuery = FindByCondition(pc =>
                        pc.Id.Equals(productCategoryId),
                        trackChanges)
                    .IsInclude(include)
                    .AsQueryable();

                var productCategory = await productCategoryQuery.SingleOrDefaultAsync();
                Console.WriteLine(include);
                if (productCategory == null) {
                    return new PagedList<Product>(new List<Product>(), 0, 1, 1);
                }
                //get products
                var products = productCategory.Products
                    .Select(p => new Product
                    {
                        Id = p.Id,
                        ProductName = p.ProductName,
                        ProductBarcode = p.ProductBarcode,
                        Status = p.Status,
                        CreatedAt = p.CreatedAt,
                        UpdatedAt = p.UpdatedAt
                    }).ToList();

                foreach(var product in products)
                {
                    Console.WriteLine("product: " + product);
                }

                var count = products.Count();

                Console.WriteLine(count);

                // Trả về kết quả dưới dạng PagedList
                return new PagedList<Product>(
                    products,
                    count,
                    1,
                    1
                );
            }
        }

        public async Task<PagedList<ProductCategory>> GetProductCategoriesAsync(ProductCategoryParameters productCategoryParameters, bool trackChanges, string? include = null)
        {
            // Lọc và sắp xếp danh sách ProductCategorys theo các điều kiện
            var productCategoriesQuery = FindByCondition(b =>
                    (string.IsNullOrEmpty(productCategoryParameters.Category) || b.Category.Contains(productCategoryParameters.Category)),
                    trackChanges)
                .SearchByName(productCategoryParameters.Category) // Tìm kiếm theo tên sản phẩm
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
