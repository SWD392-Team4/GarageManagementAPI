using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.Extension;

namespace GarageManagementAPI.Repository
{
    internal class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
        public async new Task CreateAsync(Product entity)
        {
            entity.CreatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            entity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            await base.CreateAsync(entity);
        }


        public async Task<Product?> GetProductByBarCodeAsync(string barcode, bool trackChanges, string? include = null)
        {
            var product = await FindByCondition(p => p.ProductBarcode.Equals(barcode), trackChanges).IsInclude(include).SingleOrDefaultAsync();

            return product;
        }

        public async Task<Product?> GetProductByIdAsync(Guid productId, bool trackChanges, string? include = null)
        {
            var product = await FindByCondition(p => p.Id.Equals(productId), trackChanges).IsInclude(include).SingleOrDefaultAsync();

            return product;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(IEnumerable<Guid> productIds, bool trackChanges)
        {
            return await FindByCondition(p => productIds.Contains(p.Id), trackChanges).ToListAsync();
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
    }
}