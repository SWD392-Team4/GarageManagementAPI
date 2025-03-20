using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IGoodsIssuedDetailRepository
    {
        void UpdateGoodsIssuedDetailAsync(GoodsIssuedDetail goodsIssuedDetail);
        public Task CreateGoodsIssuedDetailAsync(GoodsIssuedDetail goodsIssuedDetail);
        Task<PagedList<GoodsIssuedDetail>> GetGoodsIssuedDetailsAsync(Guid goodsIssuedId, GoodsIssuedDetailParameters goodsReceivedParameters, bool trackChanges, string? include = null);
        Task<GoodsIssuedDetail?> GetGoodsIssuedDetailAsync(Guid goodsIssusedDetailId, bool trackChanges, string? include = null);
        Task<PagedList<GoodsIssuedDetail>> GetGoodsIssuedDetailsAsync(GoodsIssuedDetailParameters goodsReceivedParameters, string? include = null);
        Task<int> GetSumGoodsIssuedByDate(Guid? warehouseId, DateTimeOffset? startDate, DateTimeOffset? endDate);
    }
}
