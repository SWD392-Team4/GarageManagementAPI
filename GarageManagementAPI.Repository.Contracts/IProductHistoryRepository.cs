using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;


namespace GarageManagementAPI.Repository.Contracts
{
    public interface IProductHistoryRepository : IRepositoryBase<ProductHistory>
    {
        Task<PagedList<ProductHistory>> GetProductHistoryByIdProductAsync(Guid productHistoryId, ProductHistoryParameters productHistoryParameters, bool trackChanges, string? include = default);
        Task<PagedList<ProductHistory>> GetProductHistoryAsync(ProductHistoryParameters productHistoryParameters, bool trackChanges, string? include = default);
        Task<IEnumerable<ProductHistory>> GetProductHistoriesAsync(IEnumerable<Guid> productIds, bool trackChanges);
        Task<ProductHistory?> GetProductHistory(Guid productId, bool trackChanges);
        public Task<ProductHistory?> GetProductHistoryByGoodsIssuedDetails(Guid productId);
    }
}
