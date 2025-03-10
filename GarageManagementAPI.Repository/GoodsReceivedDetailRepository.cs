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
              .SearchByDate(goodsReceivedDetailParameters.CreatedAt)
              .SearchByDate(goodsReceivedDetailParameters.UpdatedAt)
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
              .SearchByDate(goodsReceivedDetailParameters.CreatedAt)
              .SearchByDate(goodsReceivedDetailParameters.UpdatedAt)
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
    }
}
