using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IGoodsIssuedRepository
    {
        Task<GoodsIssued?> GetGoodsIssuedAsync(Guid goodsIssuedId, bool trackChanges, string? include = default);
        Task<GoodsIssued?> GetGoodsIssuedByIdAndReferenceNumberAsync(string referenceNumber, Guid? goodsIssuedId, bool trackChanges);
        Task<PagedList<GoodsIssued>> GetGoodsIssuedsAsync(GoodsIssuedParameters goodsIssuedParameters, bool trackChanges, string? include = default);
        public Task CreateGoodsIssuedAsync(GoodsIssued goodsIssued);
        void UpdateGoodsIssuedAsync(GoodsIssued goodsIssued);
    }
}
