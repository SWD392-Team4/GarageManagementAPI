using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Repository.Extensions;

namespace GarageManagementAPI.Repository
{
    public class ProductAtWarehouseRepository : RepositoryBase<ProductAtWarehouse>, IProductAtWarehouseRepository
    {
        public ProductAtWarehouseRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            
        }
        public async Task CreateProductAtWarehouse(ProductAtWarehouse productAtWarehouse)
        {
            await base.CreateAsync(productAtWarehouse);
        }

        public async Task<ProductAtWarehouse?> GetProductAtWarehouse(Guid productId, bool trackChanges, string? include = null)
        {
            var productAtWareHourse = include == null
                ? await FindByCondition(p => p.Id == productId, trackChanges).SingleOrDefaultAsync()
                : await FindByCondition(p => p.Id == productId, trackChanges).IsInclude(include).SingleOrDefaultAsync();
            return productAtWareHourse;
        }

        public async Task<PagedList<ProductAtWarehouse>> GetProductAtWarehouses(ProductAtWarehouseParameters productAtWarehouseParameters, bool trackChanges, string? include = null)
        {
            var productAtWareHouses = await FindAll(trackChanges)
                .SearchByQuantity(productAtWarehouseParameters.minQuantity, productAtWarehouseParameters.maxQuantity)
                .SerchByCreatedAt(productAtWarehouseParameters.CreatedAt)
                .SerchByUpdatedAt(productAtWarehouseParameters.UpdatedAt)
                .Sort(productAtWarehouseParameters.OrderBy)
                .IsInclude(include!)
                .ToListAsync();
            return PagedList<ProductAtWarehouse>.ToPagedList(
                productAtWareHouses,
                productAtWarehouseParameters.PageSize,
                productAtWarehouseParameters.PageNumber
                );
        }

        public void UpdateProductAtWarehouse(ProductAtWarehouse productAtWarehouse)
        {
            base.Update(productAtWarehouse);
        }
    }
}
