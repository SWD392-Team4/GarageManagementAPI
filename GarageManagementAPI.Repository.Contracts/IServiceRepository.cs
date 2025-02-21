using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IServiceRepository
    {
        Task<Service?> GetServiceByIdAsync(Guid serviceId, bool trackChanges, string? include = default);
        public Task<Service?> GetServiceByIdAndNameAsync(string name, Guid? serviceId, bool trackChanges);
        Task<PagedList<Service>> GetServicesAsync(ServiceParameters serviceParameters, bool trackChanges, string? include = default);
        Task CreateServiceAsync(Service service);
        void UpdateServiceAsync(Service service);
    }
}
