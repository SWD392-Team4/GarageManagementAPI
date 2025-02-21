using AutoMapper;
using System.Dynamic;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.DataTransferObjects.Service;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Service.Extension;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.ErrorsConstant.Service;

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

        public async Task<Result<ServiceDto>> CreateServiceAsync(ServiceDtoForCreation serviceDtoForCreation)
        {
            var check = await GetAndCheckIServiceExistByName(serviceDtoForCreation.ServiceName);
            if (check)
                return Result<ServiceDto>.BadRequest([ServiceErrors.GetServiceNameAlreadyExistError(serviceDtoForCreation)]);

            var seviceEntity = _mapper.Map<Entities.Models.Service>(serviceDtoForCreation);

            seviceEntity.CreatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            seviceEntity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            seviceEntity.Status = ServiceStatus.Inactive;

            await _repoManager.Service.CreateServiceAsync(seviceEntity);
            await _repoManager.SaveAsync();

            var serviceDtoToReturn = _mapper.Map<ServiceDto>(seviceEntity);

            return serviceDtoToReturn.CreatedResult();
        }

        public async Task<Result> UpdateService(Guid serviceId, ServiceDtoForUpdate serviceDtoForUpdate, bool trackChanges)
        {
            var checkServiceIsExistResult = await GetAndCheckIfServiceExist(serviceId, trackChanges);
            var checkServiceNameIsExistResult = await GetAndCheckIServiceExistByName(serviceDtoForUpdate.ServiceName, serviceId);
            if (checkServiceNameIsExistResult)
                return Result<ServiceDto>.BadRequest([ServiceErrors.GetServiceNameUpdateAlreadyExistError(serviceDtoForUpdate)]);
            if (!checkServiceIsExistResult.IsSuccess)
                return Result<ServiceDto>.Failure(checkServiceIsExistResult.StatusCode, checkServiceIsExistResult.Errors!);
            var serviceEntity = checkServiceIsExistResult.GetValue<Entities.Models.Service>();

            _mapper.Map(serviceDtoForUpdate, serviceEntity);

            serviceEntity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            await _repoManager.SaveAsync();

            return Result.NoContent();
        }


        public async Task<Result<ExpandoObject>> GetServiceAsync(Guid serviceId, ServiceParameters serviceParameters, bool trackChanges, string? include = null)
        {
            var serviceResult = await GetAndCheckIfServiceExist(serviceId, trackChanges);

            if (!serviceResult.IsSuccess)
                return Result<ExpandoObject>.NotFound(serviceResult.Errors!);

            var serviceEntity = serviceResult.GetValue<Entities.Models.Service>();

            var servicesDto = _mapper.Map<ServiceDto>(serviceEntity);

            var serviceShaped = _dataShaper.Service.ShapeData(servicesDto, serviceParameters.Fields);

            return Result<ExpandoObject>.Ok(serviceShaped);
        }

        public async Task<Result<ServiceDtoForUpdate>> GetServiceForPartiallyUpdate(Guid serviceId, bool trackChanges)
        {
            var serviceResult = await GetAndCheckIfServiceExist(serviceId, trackChanges);
            if (!serviceResult.IsSuccess)
                return Result<ServiceDtoForUpdate>.Failure(serviceResult.StatusCode, serviceResult.Errors!);

            var serviceEntity = serviceResult.GetValue<Entities.Models.Service>();

            var serviceDtoForUpdate = _mapper.Map<ServiceDtoForUpdate>(serviceEntity);

            return Result<ServiceDtoForUpdate>.Ok(serviceDtoForUpdate);
        }

        public async Task<Result<IEnumerable<ExpandoObject>>> GetServicesAsync(ServiceParameters serviceParameters, bool trackChanges, string? include = null)
        {
            var servicesWithMetadata = await _repoManager.Service.GetServicesAsync(serviceParameters, trackChanges, include);

            var servicesDto = _mapper.Map<IEnumerable<ServiceDto>>(servicesWithMetadata);

            var servicesShaped = _dataShaper.Service.ShapeData(servicesDto, serviceParameters.Fields);

            return Result<IEnumerable<ExpandoObject>>.Ok(servicesShaped, servicesWithMetadata.MetaData);
        }

        private async Task<Result<Entities.Models.Service>> GetAndCheckIfServiceExist(Guid serviceId, bool trackChanges)
        {
            var service = await _repoManager.Service.GetServiceByIdAsync(serviceId, trackChanges);
            if (service == null)
                return service.NotFound(serviceId);

            return service.OkResult();
        }

        private async Task<bool> GetAndCheckIServiceExistByName(string name, Guid? serviceId = null)
        {
            var service = await _repoManager.Service.GetServiceByIdAndNameAsync(name, serviceId, false);
            if (service == null) return false;
            return true;
        }
    }
}
