using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IGoodsReceivedDetailRepository
    {
        Task<GoodsReceivedDetail?> GetGoodsReceivedDetailAsync(Guid goodsReceivedDetailId, bool trackChanges, string? include = default);
        Task<GoodsReceivedDetail?> GetGoodsReceivedDetailByProductAndGoodsReceivedAsync(Guid? productId, Guid? goodsReceivedId, Guid? goodsReceivedDetailId, bool trackChanges);
        Task<PagedList<GoodsReceivedDetail>> GetGoodsReceivedDetailsAsync(GoodsReceivedDetailParameters goodsReceivedDetailParameters, bool trackChanges, string? include = default);
        Task<PagedList<GoodsReceivedDetail>> GetGoodsReceivedDetailsAsync(Guid goodsReceivedId, GoodsReceivedDetailParameters goodsReceivedDetailParameters, bool trackChanges, string? include = default);
        public Task CreateGoodsReceivedDetailAsync(GoodsReceivedDetail goodsReceivedDetail);
    }
}
