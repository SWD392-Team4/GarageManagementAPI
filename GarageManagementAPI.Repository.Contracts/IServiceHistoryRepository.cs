using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IServiceHistoryRepository
    {
        Task<PagedList<ServiceHistory>> GetServiceHistoryByIdSerivceAsync(Guid serviceHistoryId, ServiceHistoryParameters serviceHistoryParameters, bool trackChanges, string? include = default);
        Task<ServiceHistory?> GetServiceHistoryByPriceAndIdServiceAsync(Guid serviceId, decimal price, bool trackChanges, string? include = default);
        Task<ServiceHistory?> GetServiceHistoryByStatusAndIdServiceAsync(Guid serviceId, bool trackChanges, string? include = default);
        Task<PagedList<ServiceHistory>> GetServiceHistoryAsync(ServiceHistoryParameters ServiceHistoryParameters, bool trackChanges, string? include = default);
        Task<IEnumerable<ServiceHistory>> GetServiceHistoriesAsync(IEnumerable<Guid> ids, bool trackChanges);

        Task CreateServicetHisotoryAsync(ServiceHistory productHisotry);
        void UpdateServiceHistory(ServiceHistory ServiceHistory);
    }
}
