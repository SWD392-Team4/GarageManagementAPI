using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository
{
    public class GoodsReceivedDetailRepository : RepositoryBase<GoodsReceivedDetail>, IGoodsReceivedDetailRepository
    {
        public GoodsReceivedDetailRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CreateGoodsReceivedDetailAsync(GoodsReceivedDetail goodsReceivedDetail)
        {
            await base.CreateAsync(goodsReceivedDetail);
        }

        public async Task<GoodsReceivedDetail?> GetGoodsReceivedDetailAsync(Guid goodsReceivedDetailId, bool trackChanges, string? include = null)
        {
            var goodsReceivedDetail = include is null ?
              await FindByCondition(b => b.Id.Equals(goodsReceivedDetailId), trackChanges).SingleOrDefaultAsync() :
              await FindByCondition(b => b.Id.Equals(goodsReceivedDetailId), trackChanges).IsInclude(include).SingleOrDefaultAsync();
            return goodsReceivedDetail;
        }

        public async Task<GoodsReceivedDetail?> GetGoodsReceivedDetailByProductAndGoodsReceivedAsync(Guid? productId, Guid? goodsReceivedId, Guid? goodsReceivedDetailId, bool trackChanges)
        {
            var goodsReceivedDetail = await FindByCondition(b => b.ProductId.Equals(productId) && b.GoodsReceivedId.Equals(goodsReceivedId) && !b.Id.Equals(goodsReceivedDetailId), trackChanges).SingleOrDefaultAsync();
            return goodsReceivedDetail;
        }

        public async Task<PagedList<GoodsReceivedDetail>> GetGoodsReceivedDetailsAsync(GoodsReceivedDetailParameters goodsReceivedDetailParameters, bool trackChanges, string? include = null)
        {
            var goodsReceivedDetails = await FindAll(trackChanges)
              .SearchByUnitPrice(goodsReceivedDetailParameters.MinUnitPrice, goodsReceivedDetailParameters.MaxUnitPrice)
              .SearchByTotalPrice(goodsReceivedDetailParameters.MiniTotalPrice,goodsReceivedDetailParameters.MaxTotalPrice)
              .SearchByCreate(goodsReceivedDetailParameters.CreatedAt)
              .SearchByCreate(goodsReceivedDetailParameters.UpdatedAt)
              .SearchByStatus(goodsReceivedDetailParameters.Status)
              .Sort(goodsReceivedDetailParameters.OrderBy)
              .IsInclude(include)
              .ToListAsync();

            return PagedList<GoodsReceivedDetail>.ToPagedList(
                goodsReceivedDetails,
                goodsReceivedDetailParameters.PageNumber,
                goodsReceivedDetailParameters.PageSize
                );
        }

        public async Task<PagedList<GoodsReceivedDetail>> GetGoodsReceivedDetailsAsync(Guid goodsReceivedId, GoodsReceivedDetailParameters goodsReceivedDetailParameters, bool trackChanges, string? include = null)
        {

            var goodsReceivedDetails = await FindByCondition(g => g.GoodsReceivedId.Equals(goodsReceivedId), trackChanges)
              .SearchByUnitPrice(goodsReceivedDetailParameters.MinUnitPrice, goodsReceivedDetailParameters.MaxUnitPrice)
              .SearchByTotalPrice(goodsReceivedDetailParameters.MiniTotalPrice, goodsReceivedDetailParameters.MaxTotalPrice)
              .SearchByCreate(goodsReceivedDetailParameters.CreatedAt)
              .SearchByCreate(goodsReceivedDetailParameters.UpdatedAt)
              .SearchByStatus(goodsReceivedDetailParameters.Status)
              .Sort(goodsReceivedDetailParameters.OrderBy)
              .IsInclude(include)
              .ToListAsync();

            return PagedList<GoodsReceivedDetail>.ToPagedList(
                goodsReceivedDetails,
                goodsReceivedDetailParameters.PageNumber,
                goodsReceivedDetailParameters.PageSize
                );
        }

        public void UpdateGoodsReceivedDetailAsync(GoodsReceivedDetail goodsReceivedDetail)
        {
            base.Update(goodsReceivedDetail);
        }

        public async Task<int> GetSumGoodsReceivedByDate(Guid? warehouseId, DateTimeOffset? startDate, DateTimeOffset? endDate)
        {
            int total = 0;
            total = await FindAll(false)
                          .Include(p => p.GoodsReceived)
                          .Where(p => p.GoodsReceived != null && p.GoodsReceived.WarehouseId.Equals(warehouseId))
                          .SearchByDate(startDate, endDate)
                          .SumAsync(p => p.Quantity);
            return total;
        }

        public async Task<IEnumerable<Product>> GetLowStockProducts(int threshold, Guid? warehouseId, bool trackChanges)
        {
            var lowStockProducts = await FindAll(trackChanges)
                                        .Include(p => p.GoodsReceived)
                                        .Where(p => p.GoodsReceived != null && p.GoodsReceived.WarehouseId.Equals(warehouseId))
                                        .Include(p => p.Product)
                                        .GroupBy(p => p.ProductId) 
                                        .Select(g => new
                                        {
                                            Product = g.First().Product, 
                                            TotalQuantity = g.Sum(p => p.Quantity) 
                                        })
                                        .Where(p => p.TotalQuantity <= threshold) 
                                        .OrderBy(p => p.TotalQuantity) 
                                        .Select(p => p.Product) 
                                        .ToListAsync();

            return lowStockProducts;
        }
    }
}
