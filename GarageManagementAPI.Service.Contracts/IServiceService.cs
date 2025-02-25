using System.Dynamic;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.DataTransferObjects.Service;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IServiceService
    {
        public Task<Result<ExpandoObject>> GetServiceAsync(Guid serviceId, bool trackChanges, string? include = null);
        public Task<Result<IEnumerable<ExpandoObject>>> GetServicesAsync(ServiceParameters serviceParameters, bool trackChanges, string? include = null);
        public Task<Result<ServiceDtoForUpdate>> GetServiceForPartiallyUpdate(Guid serviceId, bool trackChanges);
        public Task<Result<ServiceDto>> CreateServiceAsync(ServiceDtoForCreation serviceDtoForCreation);
        public Task<Result> UpdateService(Guid serviceId, ServiceDtoForUpdate serviceDtoForUpdate, bool trackChanges);

    }
}
