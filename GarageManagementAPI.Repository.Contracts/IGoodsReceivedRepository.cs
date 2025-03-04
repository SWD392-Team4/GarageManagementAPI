using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IGoodsReceivedRepository
    {
        Task<GoodsReceived?> GetGoodsReceivedAsync(Guid goodsReceivedId, bool trackChanges, string? include = default);
        Task<GoodsReceived?> GetGoodsReceivedByRefereneceNumberAsync(Guid? goodsReceivedId, string refereneceNumber, bool trackChanges, string? include = default);
        Task<GoodsReceived?> GetGoodsReceivedByInvoiceCodeAsync(Guid? goodsReceivedId, string invoiceCode, bool trackChanges, string? include = default);
        Task<GoodsReceived?> GetGoodsReceivedByAddressAsync(Guid? goodsReceivedId, GoodsReceived goodsReceived, bool trackChanges, string? include = default);
        Task<PagedList<GoodsReceived>> GetGoodsReceivedsAsync(GoodsReceivedParameters goodsReceivedParameters, bool trackChanges, string? include = default);
        Task CreateGoodsReceivedAsync(GoodsReceived goodsReceived);
        void UpdateGoodsReceived(GoodsReceived goodsReceived);
    }
}
