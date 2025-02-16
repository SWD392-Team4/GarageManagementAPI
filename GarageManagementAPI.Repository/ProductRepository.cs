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

        public async Task<ProductDtoFull?> GetProductFulllByBarCodeAsync(string barcode, bool trackChanges, string? include = null)
        {
            var product = include is null ?
           await FindByCondition(p => p.ProductBarcode.Equals(barcode), trackChanges).SingleOrDefaultAsync() :
           await FindByCondition(p => p.ProductBarcode.Equals(barcode), trackChanges).IsInclude(include).SingleOrDefaultAsync();

            var price = product?.ProductHistories
                .Where(ph => ph.Status == ProductHistoryStatus.Active)
                .OrderByDescending(ph => ph.CreatedAt)
                .Select(ph => ph.ProductPrice)
                .FirstOrDefault();

            var img = product?.ProductImages
                 .Where(pm => pm.Status == ProductImageStatus.Active)
                 .OrderByDescending(pm => pm.CreatedAt)
                 .Select(pm => pm.Link)
                 .FirstOrDefault();

            // Tạo và trả về DTO với thông tin về sản phẩm và giá
            var productDtoFull = new ProductDtoFull
            {
                Id = product.Id,
                ProductName = product.ProductName,
                ProductBarcode = product.ProductBarcode,
                ProductDescription = product.ProductDescription,
                ProductPrice = price ?? 0,
                ProductImg = img ?? "none",
                Status = product.Status,
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt
            };
            return productDtoFull;
        }

        public async Task<ProductDtoFull?> GetProductFullByIdAsync(Guid productId, bool trackChanges, string? include = null)
        {
            var product = include is null ?
            await FindByCondition(p => p.Id.Equals(productId), trackChanges).SingleOrDefaultAsync() :
            await FindByCondition(p => p.Id.Equals(productId), trackChanges).IsInclude(include).SingleOrDefaultAsync();

            var price = product?.ProductHistories
                 .Where(ph => ph.Status == ProductHistoryStatus.Active)
                 .OrderByDescending(ph => ph.CreatedAt)
                 .Select(ph => ph.ProductPrice)
                 .FirstOrDefault();

            var img = product?.ProductImages
                 .Where(pm => pm.Status == ProductImageStatus.Active)
                 .OrderByDescending(pm => pm.CreatedAt)
                 .Select(pm => pm.Link)
                 .FirstOrDefault();

            // Tạo và trả về DTO với thông tin về sản phẩm và giá
            var productDtoFull = new ProductDtoFull
            {
                Id = product.Id,
                ProductName = product.ProductName,
                ProductBarcode = product.ProductBarcode,
                ProductDescription = product.ProductDescription,
                ProductPrice = price ?? 0,
                ProductImg = img ?? "none",
                Status = product.Status,
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt
            };
            return productDtoFull;
        }

        public async Task<PagedList<ProductDtoFull>> GetProductsAsync(ProductParameters productParameters, bool trackChanges, string? include = null)
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

            // Lọc ra ProductHistories có trạng thái Active và lấy giá ProductPrice mới nhất cho mỗi sản phẩm
            var productsDto = products
                .Select(p => new ProductDtoFull
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    ProductBarcode = p.ProductBarcode,
                    ProductDescription = p.ProductDescription,
                    Status = p.Status,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt,
                    ProductPrice = p.ProductHistories
                        .Where(ph => ph.Status == ProductHistoryStatus.Active && p.Id == ph.ProductId)
                        .OrderByDescending(ph => ph.CreatedAt)
                        .Select(ph => ph.ProductPrice)
                        .FirstOrDefault(),
                    ProductImg = p.ProductImages
                        .Where(pm => pm.Status == ProductImageStatus.Active && p.Id == pm.ProductId)
                        .OrderByDescending(pm => pm.CreatedAt)
                        .Select(ph => ph.Link)
                        .FirstOrDefault()
                }).ToList();


            // Lấy tổng số bản ghi để tính toán tổng số trang
            var count = await productsQuery.CountAsync();

            // Trả về kết quả dưới dạng PagedList
            return new PagedList<ProductDtoFull>(
                productsDto,
                count,
                productParameters.PageNumber,
                productParameters.PageSize
            );
        }


        public async Task<Product?> GetProductByIdAsync(Guid productId, bool trackChanges, string? include = null)
        {
            var product = include is null ?
          await FindByCondition(p => p.Id.Equals(productId), trackChanges).SingleOrDefaultAsync() :
          await FindByCondition(p => p.Id.Equals(productId), trackChanges).IsInclude(include).SingleOrDefaultAsync();

            return product;
        }
    }
}