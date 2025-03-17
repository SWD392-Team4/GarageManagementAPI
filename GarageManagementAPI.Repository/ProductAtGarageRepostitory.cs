using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository
{
    public class ProductAtGarageRepostitory : RepositoryBase<ProductAtGarage>, IProductAtGarageRepository
    {
        public ProductAtGarageRepostitory(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
        public async Task CreateProductAtGarageAsync(ProductAtGarage productAtGarage)
        {
            await base.CreateAsync(productAtGarage);
        }

        public async Task<PagedList<ProductAtGarage>> GetProductAtGarages(ProductAtGarageParameters productAtGarageParameters, bool trackChanges, string? include = null)
        {
            var productsAtgarages = await FindAll(trackChanges)
                                            .SearchByQuantityProduct(productAtGarageParameters.minQuantity, productAtGarageParameters.maxQuantity)
                                            .Include("Product")
                                            .OrderBy(p => p.CreatedAt)
                                            .GroupBy(p => p.ProductId)
                                            .Select(group => group.First())
                                            .ToListAsync();
            return PagedList<ProductAtGarage>.ToPagedList(productsAtgarages,
                productAtGarageParameters.PageNumber,
                productAtGarageParameters.PageSize);
        }

        public async Task<Dictionary<Guid, int>> GetTotalQuantityByProductIdAsync()
        {
            var totalQuantities = await FindAll(false)
                .GroupBy(p => p.ProductId)
                .Select(group => new
                {
                    ProductId = group.Key,
                    TotalQuantity = group.Sum(p => p.Quantity)
                })
                .ToDictionaryAsync(x => x.ProductId, x => x.TotalQuantity);

            return totalQuantities;
        }

        public async Task<ProductAtGarage?> GetProductAtGarage(Guid productAtGarageId, bool trackChanges, string? include = null)
        {
            var productAtGarage = include == null ? await FindByCondition(pat => pat.Id.Equals(productAtGarageId), trackChanges).SingleOrDefaultAsync() : await FindByCondition(pat => pat.Id.Equals(productAtGarageId), false).IsInclude(include).SingleOrDefaultAsync();
            return productAtGarage;
        }

        public async Task<ProductAtGarage?> GetProductAtGarage(Guid productId, bool trackChanges)
        {
            return await FindByCondition(p => p.ProductId.Equals(productId), trackChanges).FirstOrDefaultAsync();
        }

        public void UpdateProductGarage(ProductAtGarage productAtGarage)
        {
            base.Update(productAtGarage);
        }

        public async Task<List<(Guid ProductAtGarageId, int DeductedQuantity)>> DeductProductQuantityFromGarageAsync(
     Guid productId, Guid? garageId, int quantity)
        {
            var productEntries = await FindByCondition(pat => pat.ProductId.Equals(productId), true)
                .OrderBy(pw => pw.CreatedAt)
                .ToListAsync();

            int totalStock = productEntries.Sum(pw => pw.Quantity);

            if (totalStock < quantity)
            {
                return new List<(Guid, int)>();
            }

            int remainingQuantity = quantity;
            var deductedList = new List<(Guid ProductAtGarageId, int DeductedQuantity)>();

            foreach (var entry in productEntries)
            {
                if (remainingQuantity <= 0)
                    break;

                int deducted = 0;
                if (entry.Quantity >= remainingQuantity)
                {
                    deducted = remainingQuantity;
                    entry.Quantity -= remainingQuantity;
                    remainingQuantity = 0;
                }
                else
                {
                    deducted = entry.Quantity;
                    remainingQuantity -= entry.Quantity;
                    entry.Quantity = 0;
                }

                deductedList.Add((entry.Id, deducted));
                RepositoryContext.ProductAtGarages.Update(entry);
            }

            await RepositoryContext.SaveChangesAsync();
            return deductedList;
        }

        public async Task<int> GetTotalStockForProduct(Guid productId, Guid? garageId)
        {
            return await
                FindByCondition(pw => pw.ProductId.Equals(productId) &&
                             pw.WorkplaceId.Equals(garageId) &&
                             pw.Quantity > 0, false)
                .SumAsync(pw => pw.Quantity);
        }

        public async Task<IEnumerable<ProductAtGarage>> GetProductAtGarages(Guid garageId, bool trackChanges, string? include = null)
        {
            var productAtGagare = await FindByCondition(pg => pg.WorkplaceId.Equals(garageId), false)
                                            .Include("Product")
                                            .OrderBy(p => p.CreatedAt)
                                            .GroupBy(p => p.ProductId)
                                            .Select(group => group.First())
                                            .ToListAsync();

            return productAtGagare;
        }
    }
}
