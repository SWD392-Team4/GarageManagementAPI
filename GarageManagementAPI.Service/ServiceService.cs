using AutoMapper;
using System.Dynamic;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Service.Extension;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.ErrorsConstant.Service;
using GarageManagementAPI.Shared.DataTransferObjects.Service;
using GarageManagementAPI.Shared.DataTransferObjects.Package;
using GarageManagementAPI.Shared.Enums;

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

        public async Task CreateServiceHistory(Entities.Models.Service service)
        {
            var serviceHistory = _mapper.Map<ServiceHistory>(service);
            await _repoManager.ServiceHistory.CreateAsync(serviceHistory);
        }

        public async Task<Result<ServiceDto>> CreateServiceAsync(ServiceDtoForCreation serviceDtoForCreation)
        {
            var validateResult = await ValidateInputForCreate(serviceDtoForCreation);
            if (!validateResult.IsSuccess)
                return Result<ServiceDto>.Failure(validateResult);

            var seviceEntity = _mapper.Map<Entities.Models.Service>(serviceDtoForCreation);
            seviceEntity.Status = ServiceStatus.Inactive;
            await _repoManager.Service.CreateAsync(seviceEntity);
            await CreateServiceHistory(seviceEntity);

            await _repoManager.SaveAsync();

            var serviceDtoToReturn = _mapper.Map<ServiceDto>(seviceEntity);

            return serviceDtoToReturn.CreatedResult();
        }

        public async Task<Result> ValidateInputForCreate(ServiceDtoForCreation serviceDtoForCreation)
        {
            var serviceResult = await GetAndCheckIServiceExistByName(serviceDtoForCreation.ServiceName);
            if (serviceResult)
                return Result.BadRequest([ServiceErrors.GetServiceNameAlreadyExistError(serviceDtoForCreation)]);

            var carPartResult = await GetAndCheckIfCarPartIsExist(serviceDtoForCreation.CarPartId);
            if (carPartResult)
                return Result.BadRequest([ServiceErrors.GetCarPartNotFoundError(serviceDtoForCreation.CarPartId)]);

            var carCategoryResult = await GetAndCheckIfCarCategoryIsExist(serviceDtoForCreation.CarCategoryId);
            if (carCategoryResult)
                return Result.BadRequest([ServiceErrors.GetCarCategoryNotFoundError(serviceDtoForCreation.CarCategoryId)]);

            var serviceCarCategoryResult = await GetAndCheckIfCategoryByCarCategoryAndCarPart(serviceDtoForCreation.CarCategoryId, serviceDtoForCreation.CarPartId, serviceDtoForCreation.WorkNature, serviceDtoForCreation.Action);
            if (serviceCarCategoryResult)
                return Result.BadRequest([ServiceErrors.GetCategoryAndCarPartAlreadyExistError(serviceDtoForCreation.CarCategoryId, serviceDtoForCreation.CarPartId, nameof(serviceDtoForCreation.WorkNature), nameof(serviceDtoForCreation.Action))]);

            return Result.Ok();
        }

        public async Task<Result> UpdateService(Guid serviceId, ServiceDtoForUpdate serviceDtoForUpdate, bool trackChanges)
        {
            var validateResult = await ValidateInputForUpdate(serviceId, serviceDtoForUpdate);
            if (!validateResult.IsSuccess)
                return Result<ServiceDto>.Failure(validateResult);

            var serviceEntity = validateResult.GetValue<Entities.Models.Service>();

            if (!serviceEntity.Price.Equals(serviceDtoForUpdate.ServicePrice))
            {
                _mapper.Map(serviceDtoForUpdate, serviceEntity);
                await CreateServiceHistory(serviceEntity);
            }
            else
                _mapper.Map(serviceDtoForUpdate, serviceEntity);

            _repoManager.Service.Update(serviceEntity);
            await _repoManager.SaveAsync();

            return Result.NoContent();
        }

        public async Task<Result<Entities.Models.Service>> ValidateInputForUpdate(Guid serviceId, ServiceDtoForUpdate serviceDtoForUpdate)
        {
            var serviceResult = await GetAndCheckIfServiceExist(serviceId, true);
            if (!serviceResult.IsSuccess)
                return Result<Entities.Models.Service>.Failure(serviceResult.StatusCode, serviceResult.Errors!);

            var carPartResult = await GetAndCheckIfCarPartIsExist(serviceDtoForUpdate.CarPartId);
            if (carPartResult)
                return Result<Entities.Models.Service>.BadRequest([ServiceErrors.GetCarPartNotFoundError(serviceDtoForUpdate.CarPartId)]);

            var carCategoryResult = await GetAndCheckIfCarCategoryIsExist(serviceDtoForUpdate.CarCategoryId);
            if (carCategoryResult)
                return Result<Entities.Models.Service>.BadRequest([ServiceErrors.GetCarCategoryNotFoundError(serviceDtoForUpdate.CarCategoryId)]);

            var serviceNameResult = await GetAndCheckIServiceExistByName(serviceDtoForUpdate.ServiceName, serviceId);
            if (serviceNameResult)
                return Result<Entities.Models.Service>.BadRequest([ServiceErrors.GetServiceNameUpdateAlreadyExistError(serviceDtoForUpdate)]);

            var serviceCarCategoryResult = await GetAndCheckIfCategoryByCarCategoryAndCarPart(serviceDtoForUpdate.CarCategoryId, serviceDtoForUpdate.CarPartId, serviceDtoForUpdate.WorkNature, serviceDtoForUpdate.Action, serviceId);
            if (serviceCarCategoryResult)
                return Result<Entities.Models.Service>.BadRequest([ServiceErrors.GetCategoryAndCarPartAlreadyExistError(serviceDtoForUpdate.CarCategoryId, serviceDtoForUpdate.CarPartId, nameof(serviceDtoForUpdate.WorkNature), nameof(serviceDtoForUpdate.Action))]);


            return serviceResult;

        }


        public async Task<Result<ExpandoObject>> GetServiceAsync(Guid serviceId, bool trackChanges, string? include = null)
        {
            var serviceResult = await GetAndCheckIfServiceExist(serviceId, trackChanges, include);

            if (!serviceResult.IsSuccess)
                return Result<ExpandoObject>.NotFound(serviceResult.Errors!);

            var serviceEntity = serviceResult.GetValue<Entities.Models.Service>();

            var servicesDto = _mapper.Map<ServiceDto>(serviceEntity);

            var serviceShaped = _dataShaper.Service.ShapeData(servicesDto, null);

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

        private async Task<Result<Entities.Models.Service>> GetAndCheckIfServiceExist(Guid serviceId, bool trackChanges, string? include = null)
        {
            var service = await _repoManager.Service.GetServiceByIdAsync(serviceId, trackChanges, include);
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

        private async Task<bool> GetAndCheckIfCategoryByCarCategoryAndCarPart(Guid carCategoryId, Guid carPartId, WorkNature workNature, ServiceAction action, Guid? serviceId = null)
        {
            var service = await _repoManager.Service.GetServiceByCarCategoryAnCarPartId(serviceId, carPartId, carCategoryId, workNature, action, false);

            if (service == null) return false;

            if (service.Id.Equals(serviceId)) return false;

            return true;
        }

        private async Task<bool> GetAndCheckIfCarCategoryIsExist(Guid carCategoryId)
        {
            var category = await _repoManager.CarCategory.GetCarCategoryAsync(carCategoryId, false);

            if (category == null) return true;

            return false;
        }

        private async Task<bool> GetAndCheckIfCarPartIsExist(Guid carPartId)
        {
            var category = await _repoManager.CarPart.GetCarPartByIdAsync(carPartId, false);

            if (category == null) return true;

            return false;
        }

        public async Task<Result<IEnumerable<ExpandoObject>>> GetPackgeOfServiceAsync(Guid serviceId, PackageParameters packageParameters)
        {
            var packages = await _repoManager.Package.GetPackagesByServiceIdAsync(serviceId, packageParameters, false);

            var packageDto = _mapper.Map<IEnumerable<PackageDto>>(packages);

            var packageDtoShaped = _dataShaper.Package.ShapeData(packageDto, packageParameters.Fields);

            return Result<IEnumerable<ExpandoObject>>.Ok(packageDtoShaped, packages.MetaData);
        }
    }
}
