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

        public async Task<ProductDtoWithPrice?> GetProductByBarCodeAsync(string barcode, bool trackChanges, string? include = null)
        {
            var product = include is null ?
           await FindByCondition(p => p.ProductBarcode.Equals(barcode), trackChanges).SingleOrDefaultAsync() :
           await FindByCondition(p => p.ProductBarcode.Equals(barcode), trackChanges).Include(include).SingleOrDefaultAsync();

            var price = product?.ProductHistories
                .Where(ph => ph.Status == ProductHistoryStatus.Active)
                .OrderByDescending(ph => ph.CreatedAt)
                .Select(ph => ph.ProductPrice)
                .FirstOrDefault();

            // Tạo và trả về DTO với thông tin về sản phẩm và giá
            var productDtoWithPrice = new ProductDtoWithPrice
            {
                Id = product.Id,
                ProductName = product.ProductName,
                ProductPrice = price ?? 0,
                Status = product.Status,
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt
            };
            return productDtoWithPrice;
        }

        public async Task<ProductDtoWithPrice?> GetProductByIdAsync(Guid productId, bool trackChanges, string? include = null)
        {
            var product = include is null ?
            await FindByCondition(p => p.Id.Equals(productId), trackChanges).SingleOrDefaultAsync() :
            await FindByCondition(p => p.Id.Equals(productId), trackChanges).IsInclude(include).SingleOrDefaultAsync();

            var price = product?.ProductHistories
                 .Where(ph => ph.Status == ProductHistoryStatus.Active && ph.ProductId == productId) 
                 .OrderByDescending(ph => ph.CreatedAt)
                 .Select(ph => ph.ProductPrice)
                 .FirstOrDefault();

            // Tạo và trả về DTO với thông tin về sản phẩm và giá
            var productDtoWithPrice = new ProductDtoWithPrice
            {
                Id = product.Id,
                ProductName = product.ProductName,
                ProductPrice = price ?? 0,
                Status = product.Status,
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt
            };
            return productDtoWithPrice;
        }

        public async Task<PagedList<ProductDtoWithPrice>> GetProductsAsync(ProductParameters productParameters, bool trackChanges, string? include = null)
        {
            // Lọc và sắp xếp danh sách sản phẩm theo các điều kiện từ productParameters
            var productsQuery = FindByCondition(p =>
                    (string.IsNullOrEmpty(productParameters.ProductName) || p.ProductName.Contains(productParameters.ProductName)),
                    trackChanges)
                .SearchByName(productParameters.ProductName) // Tìm kiếm theo tên sản phẩm
                .Sort(productParameters.OrderBy)
                .IsInclude(include)
                .AsQueryable();

            // Phân trang dữ liệu sản phẩm
            var products = await productsQuery
                .Skip((productParameters.PageNumber - 1) * productParameters.PageSize)
                .Take(productParameters.PageSize)
                .ToListAsync();

            // Lọc ra ProductHistories có trạng thái Active và lấy giá ProductPrice mới nhất cho mỗi sản phẩm
            var productsWithPrice = products
                .Select(p => new ProductDtoWithPrice
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    ProductBarcode = p.ProductBarcode,
                    Status = p.Status,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt,
                    ProductPrice = p.ProductHistories
                        .Where(ph => ph.Status == ProductHistoryStatus.Active && p.Id == ph.ProductId)
                        .OrderByDescending(ph => ph.CreatedAt)
                        .Select(ph => ph.ProductPrice)
                        .FirstOrDefault()
                })
                .ToList();

            // Lấy tổng số bản ghi để tính toán tổng số trang
            var count = await productsQuery.CountAsync();

            // Trả về kết quả dưới dạng PagedList
            return new PagedList<ProductDtoWithPrice>(
                productsWithPrice,
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