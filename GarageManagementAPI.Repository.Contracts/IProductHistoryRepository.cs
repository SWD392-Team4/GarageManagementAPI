using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;


namespace GarageManagementAPI.Repository.Contracts
{
    public interface IProductHistoryRepository : IRepositoryBase<ProductHistory>
    {
        Task<PagedList<ProductHistory>> GetProductHistoryByIdProductAsync(Guid productHistoryId, ProductHistoryParameters productHistoryParameters, bool trackChanges, string? include = default);
        Task<ProductHistory?> GetProductHistoryByPriceAndIdProductAsync(Guid productId, decimal price, bool trackChanges, string? include = default);
        Task<ProductHistory?> GetProductHistoryByStatusAndIdProductAsync(Guid productId, bool trackChanges, string? include = default);
        Task<PagedList<ProductHistory>> GetProductHistoryAsync(ProductHistoryParameters productHistoryParameters, bool trackChanges, string? include = default);
        Task CreateProductHisotoryAsync(ProductHistory productHisotry);
        void UpdateProductHistory(ProductHistory productHistory);
    }
}
