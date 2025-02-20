using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IServiceRepository
    {
        Task<Service?> GetServiceByIdAsync(Guid serviceId, bool trackChanges, string? include = default);
        Task<PagedList<Service>> GetServicesAsync(ServiceParameters serviceParameters, bool trackChanges, string? include = default);

        Task CreateServiceAsync(Service service);
        void UpdateServiceAsync(Service service);
    }
}
