using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository
{
    public class GoodsIssuedDetailRepository : RepositoryBase<GoodsIssuedDetail>, IGoodsIssuedDetailRepository
    {
        public GoodsIssuedDetailRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public async Task CreateGoodsIssuedDetailAsync(GoodsIssuedDetail goodsIssuedDetail)
        {
            await base.CreateAsync(goodsIssuedDetail);
        }

        public async Task<GoodsIssuedDetail?> GetGoodsIssuedDetailAsync(Guid goodsIssusedDetailId, bool trackChanges, string? include = null)
        {
            var goodIssuedDetail = include == null ? await FindByCondition(g => g.GoodsIssuedId.Equals(goodsIssusedDetailId), trackChanges).SingleOrDefaultAsync()
                :
                await FindByCondition(g => g.GoodsIssuedId.Equals(goodsIssusedDetailId), trackChanges).IsInclude(include).SingleOrDefaultAsync();
            return goodIssuedDetail;
        }

        public async Task<PagedList<GoodsIssuedDetail>> GetGoodsIssuedDetailsAsync(GoodsIssuedDetailParameters goodsReceivedParameters, string? include = null)
        {
            var goodIssuedDetails = await FindAll(false)
                .SearchByQuantity(goodsReceivedParameters.minQuantity, goodsReceivedParameters.maxQuantity)
                .SearchByCreatedAt(goodsReceivedParameters.CreatedAt)
                .SearchByUpdatedAt(goodsReceivedParameters.UpdatedAt)
                .SearchByStatus(goodsReceivedParameters.Status)
                .ToListAsync();
            return PagedList<GoodsIssuedDetail>.ToPagedList(
                goodIssuedDetails,
                goodsReceivedParameters.PageNumber,
                goodsReceivedParameters.PageSize
                );
        }

        public async Task<GoodsIssuedDetail?> GetGoodsIssuedDetailsAsync(Guid goodsIssuedDetailId, bool trackChanges)
        {
            var goodsIssuedDetail = await FindAll(trackChanges)
                                        .Include(g => g.ProductAtWareHouse)
                                        .ThenInclude(pw => pw.GoodsReceivedDetail)
                                        .Where(gid => gid.Id == goodsIssuedDetailId)
                                        .FirstOrDefaultAsync();
            return goodsIssuedDetail;
            }

        public async Task<PagedList<GoodsIssuedDetail>> GetGoodsIssuedDetailsAsync(Guid goodsIssuedId, GoodsIssuedDetailParameters goodsReceivedParameters, bool trackChanges, string? include)
        {

            var goodIssuedDetails = await FindByCondition(gi => gi.GoodsIssuedId.Equals(goodsIssuedId),trackChanges)
                .SearchByQuantity(goodsReceivedParameters.minQuantity, goodsReceivedParameters.maxQuantity)
                .SearchByCreatedAt(goodsReceivedParameters.CreatedAt)
                .SearchByUpdatedAt(goodsReceivedParameters.UpdatedAt)
                .SearchByStatus(goodsReceivedParameters.Status)
                .ToListAsync();

            return PagedList<GoodsIssuedDetail>.ToPagedList(
                goodIssuedDetails,
                goodsReceivedParameters.PageNumber,
                goodsReceivedParameters.PageSize
                );
        }

        public void UpdateGoodsIssuedDetailAsync(GoodsIssuedDetail goodsIssuedDetail)
        {
            base.Update(goodsIssuedDetail);
        }
    }
}
