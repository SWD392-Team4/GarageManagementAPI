using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IServiceRepository : IRepositoryBase<Service>
    {
        Task<IEnumerable<Service>> GetServiceByPackageHistoryIdAsync(Guid pacakgeHistoryId, bool trackChanges);
        Task<IEnumerable<Service>> GetServiceByPackageHistoryIdsAsync(IEnumerable<Guid> pacakgeHistoryIds, bool trackChanges);
        Task<PagedList<Service>> GetServiceByPackageHistoryIdAsync(Guid pacakgeHistoryId, bool trackChanges, ServiceParameters serviceParameters, string? include = default);
        Task<IEnumerable<Service>> GetServiceByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        Task<Service?> GetServiceByIdAsync(Guid serviceId, bool trackChanges, string? include = default);
        public Task<Service?> GetServiceByIdAndNameAsync(string name, Guid? serviceId, bool trackChanges);
        public Task<Service?> GetServiceByCarCategoryAnCarPartId(Guid? serviceId, Guid carPartId, Guid carparCategoryId, WorkNature workNature, ServiceAction action, bool trackChanges, string? include = default);
        Task<PagedList<Service>> GetServicesAsync(ServiceParameters serviceParameters, bool trackChanges, string? include = default);
    }
}
