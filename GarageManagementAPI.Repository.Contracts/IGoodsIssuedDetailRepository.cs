using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IGoodsIssuedDetailRepository
    {
        void UpdateGoodsIssuedDetailAsync(GoodsIssuedDetail goodsIssuedDetail);
        public Task CreateGoodsIssuedDetailAsync(GoodsIssuedDetail goodsIssuedDetail);
        Task<GoodsIssuedDetail?> GetGoodsIssuedDetailsAsync(Guid goodsIssuedDetailId, bool trackChanges);
        Task<PagedList<GoodsIssuedDetail>> GetGoodsIssuedDetailsAsync(Guid goodsIssuedId, GoodsIssuedDetailParameters goodsReceivedParameters, bool trackChanges, string? include = null);
        Task<GoodsIssuedDetail?> GetGoodsIssuedDetailAsync(Guid goodsIssusedDetailId, bool trackChanges, string? include = null);
        Task<PagedList<GoodsIssuedDetail>> GetGoodsIssuedDetailsAsync(GoodsIssuedDetailParameters goodsReceivedParameters, string? include = null);
    }
}
