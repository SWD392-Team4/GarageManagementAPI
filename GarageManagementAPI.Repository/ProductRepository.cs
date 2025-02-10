using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Repository.Extensions;

namespace GarageManagementAPI.Repository
{
    internal class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
        public async Task CreateProductAsync(Product product)
        {
            await base.CreateAsync(product);
        }

        public async Task<Product?> GetProductByBarCodeAsync(string barcode, bool trackChanges, string? include = null)
        {
            var product = include is null ?
           await FindByCondition(p => p.ProductBarcode.Equals(barcode), trackChanges).SingleOrDefaultAsync() :
           await FindByCondition(p => p.ProductBarcode.Equals(barcode), trackChanges).Include(include).SingleOrDefaultAsync();

            return product;
        }

        public async Task<Product?> GetProductByIdAsync(Guid productId, bool trackChanges, string? include = null)
        {
            var product = include is null ?
           await FindByCondition(p => p.Id.Equals(productId), trackChanges).SingleOrDefaultAsync() :
           await FindByCondition(p => p.Id.Equals(productId), trackChanges).Include(include).SingleOrDefaultAsync();

            return product;
        }

        public async Task<PagedList<Product>> GetProductsAsync(ProductParameters productParameters, bool trackChanges, string? include = null)
        {
            // Lọc và sắp xếp danh sách products theo các điều kiện
            var productsQuery = FindByCondition(b =>
                    (string.IsNullOrEmpty(productParameters.ProductName) || b.ProductName.Contains(productParameters.ProductName)),
                    trackChanges)
                .SearchByName(productParameters.ProductName) // Tìm kiếm theo tên sản phẩm
                .SearchByStatus(productParameters.Status)
                .Sort(productParameters.OrderBy)
                .IsInclude(include)
                .AsQueryable();

            // Lấy danh sách sản phẩm sau khi phân trang
            var products = await productsQuery
                .Skip((productParameters.PageNumber - 1) * productParameters.PageSize)
                .Take(productParameters.PageSize)
                .ToListAsync();

            // Lấy tổng số bản ghi để tính toán tổng số trang
            var count = await productsQuery.CountAsync();

            // Trả về kết quả dưới dạng PagedList
            return new PagedList<Product>(
                products,
                count,
                productParameters.PageNumber,
                productParameters.PageSize
            );
        }

        public void UpdateProductAsync(Product product)
        {
            base.Update(product);
        }
    }
}