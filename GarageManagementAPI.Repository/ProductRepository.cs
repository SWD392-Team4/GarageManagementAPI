using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.RequestFeatures;

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
            var products = await FindAll(trackChanges)
                .SearchByName(productParameters.ProductName)
                 .SearchByStatus(productParameters.ProductStatus)
                .Sort(productParameters.OrderBy)
                .IsInclude(include)
                .SearchByPrice(productParameters.MinPrice, productParameters.MaxPrice)
                .SearchByCategory(productParameters.ProductCategory)
                .SearchByBrand(productParameters.ProductBrandName)
                .ToListAsync();

            return PagedList<Product>.ToPagedList(
                products,
                productParameters.PageNumber,
                productParameters.PageSize
            );
        }

        public async Task<PagedList<Product>> GetProductsByWarehouseIdAsync(Guid warehouseId, ProductParameters productParameters, bool trackChanges, string? include = default)
        {
            var products = await (from p in RepositoryContext.Products
                                 join grd in RepositoryContext.GoodsReceivedDetails on p.Id equals grd.ProductId
                                 join gr in RepositoryContext.GoodsReceiveds on grd.GoodsReceivedId equals gr.Id
                                 where gr.WarehouseId == warehouseId
                                 select p)
                         .Distinct()
                         .ToListAsync();

            return PagedList<Product>.ToPagedList(
                products,
                productParameters.PageNumber,
                productParameters.PageSize
                );
        }
    }
}