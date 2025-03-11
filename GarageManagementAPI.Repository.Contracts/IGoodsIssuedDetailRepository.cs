using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IGoodsIssuedDetailRepository
    {
        Task<GoodsIssuedDetail?> GetGoodsIssuedDetailAsync(Guid goodsIssusedDetailId, bool trackChanges,string? include = null);
        Task<PagedList<GoodsIssuedDetail>> GetGoodsIssuedDetailsAsync(GoodsIssuedDetailParameters goodsReceivedParameters, string? include = null);
        Task<PagedList<GoodsIssuedDetail>> GetGoodsIssuedDetailsAsync(Guid goodsReceived, GoodsIssuedDetailParameters? goodsReceivedParameters, string? include = null);
        public Task CreateGoodsIssuedDetailAsync(GoodsIssuedDetail goodsIssuedDetail);
        void UpdateGoodsIssuedDetailAsync(GoodsIssuedDetail goodsIssuedDetail);
    }
}
