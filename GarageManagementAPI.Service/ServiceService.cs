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
using GarageManagementAPI.Shared.ErrorsConstant.ServiceHisory;
using GarageManagementAPI.Shared.DataTransferObjects.ServiceHistory;
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

        public async Task<Result<ServiceDto>> CreateServiceAsync(ServiceDtoForCreation serviceDtoForCreation)
        {
            var serviceResult = await GetAndCheckIServiceExistByName(serviceDtoForCreation.ServiceName);
            var carPartResult = await GetAndCheckIfCarPartIsExist(serviceDtoForCreation.CarPartId);
            var carCategoryResult = await GetAndCheckIfCarCategoryIsExist(serviceDtoForCreation.CarCategoryId);
            var serviceCarCategoryResult = await GetAndCheckIfCategoryByCarCategoryAndCarPart(serviceDtoForCreation.CarCategoryId, serviceDtoForCreation.CarPartId, serviceDtoForCreation.WorkNature, serviceDtoForCreation.Action);
            if (serviceResult)
                return Result<ServiceDto>.BadRequest([ServiceErrors.GetServiceNameAlreadyExistError(serviceDtoForCreation)]);
            if (carPartResult)
                return Result<ServiceDto>.BadRequest([ServiceErrors.GetCarPartNotFoundError(serviceDtoForCreation.CarPartId)]);
            if (carCategoryResult)
                return Result<ServiceDto>.BadRequest([ServiceErrors.GetCarCategoryNotFoundError(serviceDtoForCreation.CarCategoryId)]);
                if (serviceCarCategoryResult)
               return Result<ServiceDto>.BadRequest([ServiceErrors.GetCategoryAndCarPartAlreadyExistError(serviceDtoForCreation.CarCategoryId, serviceDtoForCreation.CarPartId, nameof(serviceDtoForCreation.WorkNature), nameof(serviceDtoForCreation.Action))]);
            var seviceEntity = _mapper.Map<Entities.Models.Service>(serviceDtoForCreation);
            seviceEntity.CreatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            seviceEntity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            seviceEntity.Status = ServiceStatus.Inactive;

            await _repoManager.Service.CreateServiceAsync(seviceEntity);
            await _repoManager.SaveAsync();

            //Create Service History
            await CreateServiceHistoryAsync(seviceEntity.Id, serviceDtoForCreation.ServicePrice);

            var serviceDtoToReturn = _mapper.Map<ServiceDto>(seviceEntity);

            return serviceDtoToReturn.CreatedResult();
        }

        public async Task<Result> UpdateService(Guid serviceId, ServiceDtoForUpdate serviceDtoForUpdate, bool trackChanges)
        {
            var serviceResult = await GetAndCheckIfServiceExist(serviceId, trackChanges);
            var carPartResult = await GetAndCheckIfCarPartIsExist(serviceDtoForUpdate.CarPartId);
            var carCategoryResult = await GetAndCheckIfCarCategoryIsExist(serviceDtoForUpdate.CarCategoryId);
            var serviceNameResult = await GetAndCheckIServiceExistByName(serviceDtoForUpdate.ServiceName, serviceId);
            var serviceCarCategoryResult = await GetAndCheckIfCategoryByCarCategoryAndCarPart(serviceDtoForUpdate.CarCategoryId, serviceDtoForUpdate.CarPartId, serviceDtoForUpdate.WorkNature, serviceDtoForUpdate.Action);
            if (serviceNameResult)
                return Result<ServiceDto>.BadRequest([ServiceErrors.GetServiceNameUpdateAlreadyExistError(serviceDtoForUpdate)]);
            if (carPartResult)
                return Result<ServiceDto>.BadRequest([ServiceErrors.GetCarPartNotFoundError(serviceDtoForUpdate.CarPartId)]);
            if (carCategoryResult)
                return Result<ServiceDto>.BadRequest([ServiceErrors.GetCarCategoryNotFoundError(serviceDtoForUpdate.CarCategoryId)]);
            if (serviceCarCategoryResult)
                return Result<ServiceDto>.BadRequest([ServiceErrors.GetCategoryAndCarPartAlreadyExistError(serviceDtoForUpdate.CarCategoryId, serviceDtoForUpdate.CarPartId, nameof(serviceDtoForUpdate.WorkNature), nameof(serviceDtoForUpdate.Action))]);
            if (!serviceResult.IsSuccess)
                return Result<ServiceDto>.Failure(serviceResult.StatusCode, serviceResult.Errors!);
            var serviceEntity = serviceResult.GetValue<Entities.Models.Service>();
            _mapper.Map(serviceDtoForUpdate, serviceEntity);

            serviceEntity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            //Create Service History
            await CreateServiceHistoryAsync(serviceId, serviceDtoForUpdate.ServicePrice);
            await _repoManager.SaveAsync();

            return Result.NoContent();
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

        public async Task<Result<ServiceHistoryDto>> CreateServiceHistoryAsync(Guid serviceId, decimal price)
        {
            var servicePriceResult = await GetAndCheckIfProductHistoryByIdAndPrice(serviceId, price);
            if (servicePriceResult)
                return Result<ServiceHistoryDto>.BadRequest([ServiceHistoryErrors.GetServiceHistoryPriceAlreadyExistError(price)]);

            await UpdateStatusServiceHistory(serviceId);

            var serviceEntity = new ServiceHistory
            {
                ServiceId = serviceId,
                Price = price,
                Status = ServiceHistoryStatus.Active,
                CreatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime(),
                UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime(),
            };
            Console.WriteLine("Xin chao");
            await _repoManager.ServiceHistory.CreateServicetHisotoryAsync(serviceEntity);
            await _repoManager.SaveAsync();
            var serviceHistoryDtoToReturn = _mapper.Map<ServiceHistoryDto>(serviceEntity);

            return serviceHistoryDtoToReturn.CreatedResult();
        }

        private async Task UpdateStatusServiceHistory(Guid serviceId)
        {
            var productEntity = await _repoManager.ProductImage.GetProductImgByStatusAndIdProductAsync(serviceId, false);

            if (productEntity != null)
            {
                productEntity.Status = ProductImageStatus.Inactive;
                productEntity.UpdatedAt = DateTimeOffset.UtcNow;
                _repoManager.ProductImage.UpdateProductImg(productEntity);
            }
        }

        private async Task<bool> GetAndCheckIfProductHistoryByIdAndPrice(Guid serviceId, decimal price)
        {
            var latestServiceHistory = await _repoManager.ServiceHistory.GetServiceHistoryByPriceAndIdServiceAsync(serviceId, price, false);

            if (latestServiceHistory != null) return true;

            return false;
        }

        private async Task<bool> GetAndCheckIfCategoryByCarCategoryAndCarPart(Guid carCategoryId, Guid carPartId, WorkNature workNature, ServiceAction action, Guid? serviceId = null)
        {
            var service = await _repoManager.Service.GetServiceByCarCategoryAnCarPartId(serviceId, carPartId, carCategoryId, workNature, action, false);

            if (service == null) return false;

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
