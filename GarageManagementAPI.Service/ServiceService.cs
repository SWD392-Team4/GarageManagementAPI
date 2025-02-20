using AutoMapper;
using System.Dynamic;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.DataTransferObjects.Service;
using GarageManagementAPI.Shared.ResultModel;

namespace GarageManagementAPI.Service
{
    public class ServiceService : IServiceService
    {
        private readonly IRepositoryManager _repoManager;
        private readonly IMapper _mapper;
        private readonly IDataShaperManager _dataShaper;

        public ServiceService(IRepositoryManager repoManager, IMapper mapper, IDataShaperManager dataShaper)
        {
            _repoManager = repoManager;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }

        public Task<Result<ServiceDto>> CreateServiceAsync(ServiceDtoForCreation serviceDtoForCreation)
        {
            throw new NotImplementedException();
        }

        public Task<Result<ExpandoObject>> GetServiceAsync(Guid serviceId, ServiceParameters serviceParameters, bool trackChanges, string? include = null)
        {
            throw new NotImplementedException();
        }

        public Task<Result<ServiceDtoForUpdate>> GetServiceForPartiallyUpdate(Guid serviceId, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<IEnumerable<ExpandoObject>>> GetServicesAsync(ServiceParameters serviceParameters, bool trackChanges, string? include = null)
        {
            var servicesWithMetadata = await _repoManager.Service.GetServicesAsync(serviceParameters, trackChanges, include);

            var servicesDto = _mapper.Map<IEnumerable<ServiceDto>>(servicesWithMetadata);

            var servicesShaped = _dataShaper.Service.ShapeData(servicesDto, serviceParameters.Fields);

            return Result<IEnumerable<ExpandoObject>>.Ok(servicesShaped, servicesWithMetadata.MetaData);
        }

        public Task<Result> UpdateService(Guid serviceId, ServiceDtoForUpdate serviceDtoForUpdate, bool trackChanges)
        {
            throw new NotImplementedException();
        }
    }
}
