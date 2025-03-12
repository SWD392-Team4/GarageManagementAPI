using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IServiceHistoryRepository : IRepositoryBase<ServiceHistory>
    {
        Task<PagedList<ServiceHistory>> GetServiceHistoryByIdSerivceAsync(Guid serviceId, ServiceHistoryParameters serviceHistoryParameters, bool trackChanges, string? include = default);

        Task<PagedList<ServiceHistory>> GetServiceHistoryAsync(ServiceHistoryParameters ServiceHistoryParameters, bool trackChanges, string? include = default);

        Task<IEnumerable<ServiceHistory>> GetServiceHistoriesAsync(IEnumerable<Guid> serviceIds, bool trackChanges);

        Task<ServiceHistory?> GetServiceHistory(Guid serviceId, bool trackChanges, string? include = null);
    }
}
