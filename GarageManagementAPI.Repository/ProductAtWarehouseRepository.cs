using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Repository.Extensions;
using System.Linq.Dynamic.Core;

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

        public void UpdateProductAtWarehouse(ProductAtWarehouse productAtWarehouse)
        {
            base.Update(productAtWarehouse);
        }

        public async Task<ProductAtWarehouse?> GetProductAtWarehouse(Guid productId, bool trackChanges, string? include = null)
        {
            var productAtWareHourse = include == null
                ? await FindByCondition(p => p.Id == productId, trackChanges).SingleOrDefaultAsync()
                : await FindByCondition(p => p.Id == productId, trackChanges).IsInclude(include).SingleOrDefaultAsync();
            return productAtWareHourse;
        }

        public async Task<PagedList<ProductAtWarehouse>> GetProductAtWarehouses(Guid warehourseId, ProductAtWarehouseParameters productAtWarehouseParameters, bool trackChanges, string? include = null)
        {
            var productAtWareHouses = await FindAll(trackChanges)
                                        .Include(p => p.GoodsReceivedDetail)
                                        .ThenInclude(gd => gd.GoodsReceived)
                                        .Where(p => p.GoodsReceivedDetail != null
                                         && p.GoodsReceivedDetail.GoodsReceived != null
                                         && p.GoodsReceivedDetail.GoodsReceived.WarehouseId.Equals(warehourseId))
                                        .GroupBy(p => p.GoodsReceivedDetail.ProductId)
                                        .Select(g => g.First())
                                        .ToListAsync();

            return PagedList<ProductAtWarehouse>.ToPagedList(
                productAtWareHouses,
                productAtWarehouseParameters.PageNumber,
                productAtWarehouseParameters.PageSize
                );
        }
        public async Task<List<(Guid ProductAtWarehouseId, int DeductedQuantity)>> DeductProductQuantityFromWarehouseAsync(
      Guid productId, Guid warehouseId, int quantity)
        {
            var productEntries = await RepositoryContext.ProductAtWarehouses
                .Where(pw => pw.GoodsReceivedDetail.ProductId == productId &&
                             pw.GoodsReceivedDetail.GoodsReceived.WarehouseId == warehouseId &&
                             pw.Quantity > 0)
                .OrderBy(pw => pw.CreatedAt)
                .ToListAsync();

            int totalStock = productEntries.Sum(pw => pw.Quantity);
            if (totalStock < quantity)
            {
                return new List<(Guid, int)>();
            }

            int remainingQuantity = quantity;
            var deductedList = new List<(Guid ProductAtWarehouseId, int DeductedQuantity)>();

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
                RepositoryContext.ProductAtWarehouses.Update(entry);
            }

            await RepositoryContext.SaveChangesAsync();
            return deductedList;
        }

        public async Task<int> GetTotalStockForProduct(Guid productId, Guid warehouseId)
        {
            return await
                FindByCondition(pw => pw.GoodsReceivedDetail.ProductId == productId &&
                             pw.GoodsReceivedDetail.GoodsReceived.WarehouseId == warehouseId &&
                             pw.Quantity > 0, false)
                .SumAsync(pw => pw.Quantity);
        }


        public async Task<Dictionary<Guid, int>> GetTotalStockByProductIdsAsync(List<Guid> productIds, Guid warehouseId)
        {
            return await RepositoryContext.ProductAtWarehouses
                .Where(paw => productIds.Contains(paw.GoodsReceivedDetail.ProductId) &&
                              paw.GoodsReceivedDetail.GoodsReceived.WarehouseId == warehouseId)
                .GroupBy(paw => paw.GoodsReceivedDetail.ProductId)
                .Select(g => new { ProductId = g.Key, TotalQuantity = g.Sum(paw => paw.Quantity) })
                .ToDictionaryAsync(x => x.ProductId, x => x.TotalQuantity);
        }

        public async Task<IEnumerable<ProductAtWarehouse>> GetProductAtWarehouses(Guid warehouseId, bool trackChanges, string? include = null)
        {
            var productAtWarehouse = await FindAll(trackChanges)
                                             .Include(p => p.GoodsReceivedDetail)
                                             .ThenInclude(grd => grd.GoodsReceived)
                                             .Where(p => p.GoodsReceivedDetail.GoodsReceived.WarehouseId == warehouseId)
                                            .OrderBy(p => p.CreatedAt)
                                            .GroupBy(p => p.GoodsReceivedDetail.ProductId)
                                            .Select(group => group.First())
                                            .ToListAsync();
            return productAtWarehouse;
        }

       
    }
}
