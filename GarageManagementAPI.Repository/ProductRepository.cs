using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.DataTransferObjects.Product;

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

        public void UpdateProductAsync(Product product)
        {
            base.Update(product);
        }

        public async Task<Product?> GetProductByBarCodeAsync(string barcode, bool trackChanges, string? include = null)
        {
            var product = include is null ?
           await FindByCondition(p => p.ProductBarcode.Equals(barcode), trackChanges).SingleOrDefaultAsync() :
           await FindByCondition(p => p.ProductBarcode.Equals(barcode), trackChanges).IsInclude(include).SingleOrDefaultAsync();
 
            return product;
        }

        public async Task<Product?> GetProductByIdAsync(Guid productId, bool trackChanges, string? include = null)
        {
            var product = include is null ?
            await FindByCondition(p => p.Id.Equals(productId), trackChanges).SingleOrDefaultAsync() :
            await FindByCondition(p => p.Id.Equals(productId), trackChanges).IsInclude(include).SingleOrDefaultAsync();

            return product;
        }

        public async Task<PagedList<Product>> GetProductsAsync(ProductParameters productParameters, bool trackChanges, string? include = null)
        {
            // Lọc và sắp xếp danh sách sản phẩm theo các điều kiện từ productParameters
            var productsQuery = FindByCondition(p =>
                    (string.IsNullOrEmpty(productParameters.ProductName) || p.ProductName.Contains(productParameters.ProductName)),
                    trackChanges)
                .SearchByName(productParameters.ProductName) // Tìm kiếm theo tên sản phẩm
                .SearchByStatus(productParameters.Status)
                .Sort(productParameters.OrderBy)
                .IsInclude(include)
                .AsQueryable();

            // Phân trang dữ liệu sản phẩm
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
    }
}