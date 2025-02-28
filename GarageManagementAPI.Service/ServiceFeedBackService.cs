using AutoMapper;
using System.Dynamic;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Service.Extension;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.DataTransferObjects.ServiceFeeback;

namespace GarageManagementAPI.Service
{
    public class ServiceFeedBackService : IServiceFeedbackService
    {
        private readonly IRepositoryManager _repoManager;
        private readonly IMapper _mapper;
        private readonly IDataShaperManager _dataShaper;

        public ServiceFeedBackService(IRepositoryManager repoManager, IMapper mapper, IDataShaperManager dataShaper)
        {
            _repoManager = repoManager;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }
        public async Task<Result<ServiceFeedBackDto>> CreateServiceFeedBack(Guid userId, ServiceFeedbackDtoForCreation serviceFeedBackDtoForCreation)
        {
            var serviceResult = await GetAndCheckServiceIsExist(serviceFeedBackDtoForCreation.ServiceId);
            if (!serviceResult.IsSuccess)
                return Result<ServiceFeedBackDto>.NotFound(serviceResult.Errors!);

            var serviceEntity = _mapper.Map<ServiceFeedBack>(serviceFeedBackDtoForCreation);

            serviceEntity.CustomerId = userId;
            serviceEntity.CreatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            serviceEntity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            serviceEntity.Status = ServiceFeedBackStatus.Active;

            await _repoManager.ServiceFeeback.CreateServiceFeedbackAsync(serviceEntity);
            await _repoManager.SaveAsync();

            var serviceFeddbackDtoToReturn = _mapper.Map<ServiceFeedBackDto>(serviceEntity);

            return serviceFeddbackDtoToReturn.CreatedResult();
        }

        public async Task<Result<IEnumerable<ExpandoObject>>> GetServiceFeedBackByIdService(Guid serviceId, ServiceFeedBackParameters serviceFeedBackParameterdParameters, bool trackChanges, string? include = null)
        {
            var serviceResult = await GetAndCheckServiceIsExist(serviceId);

            if (!serviceResult.IsSuccess)
                return Result<IEnumerable<ExpandoObject>>.NotFound(serviceResult.Errors!);

            var servicesWithMetadata = await _repoManager.ServiceFeeback.GetServiceFeedbackByIdServiceAsync(serviceId, serviceFeedBackParameterdParameters, trackChanges, include);

            var servicesDto = _mapper.Map<IEnumerable<ServiceFeedBackDto>>(servicesWithMetadata);

            var servicesShaped = _dataShaper.ServiceFeedback.ShapeData(servicesDto, serviceFeedBackParameterdParameters.Fields);

            return Result<IEnumerable<ExpandoObject>>.Ok(servicesShaped, servicesWithMetadata.MetaData);
        }

        public async Task<Result<ExpandoObject>> GetServiceFeedback(Guid serviceFeedbackId, bool trackChanges, string? include)
        {
            var serviceFeedbackResult = await this.GetAndCheckIfServiceFeedbackExist(serviceFeedbackId, trackChanges);
            if (!serviceFeedbackResult.IsSuccess) return Result<ExpandoObject>.NotFound(serviceFeedbackResult.Errors!);

            var serviceFeedbackEntity = serviceFeedbackResult.GetValue<ServiceFeedBack>();

            var serviceFeedbackDto = _mapper.Map<ServiceFeedBackDto>(serviceFeedbackEntity);

            var productShaped = _dataShaper.ServiceFeedback.ShapeData(serviceFeedbackDto, null);

            return Result<ExpandoObject>.Ok(productShaped);
        }


        public async Task<Result> UpdateServiceFeedBack(Guid serviceFeedBackId, ServiceFeedBackDtoForUpdate serviceFeedBackDtoForUpdate, bool trackChanges)
        {
            var serviceFeedbackResult = await GetAndCheckIfServiceFeedbackExist(serviceFeedBackId, trackChanges);
            if (!serviceFeedbackResult.IsSuccess)
                return Result<ServiceFeedBackDto>.Failure(serviceFeedbackResult.StatusCode, serviceFeedbackResult.Errors!);

            var serviceEntity = serviceFeedbackResult.GetValue<ServiceFeedBack>();

            _mapper.Map(serviceFeedBackDtoForUpdate, serviceEntity);

            serviceEntity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();

            await _repoManager.SaveAsync();

            return Result.NoContent();
        }

        private async Task<Result<Entities.Models.Service>> GetAndCheckServiceIsExist(Guid serviceId) {
            var service = await _repoManager.Service.GetServiceByIdAsync(serviceId, false, null);
            if (service == null) return service.NotFound(serviceId);
            return service.OkResult();
        }

        private async Task<Result<ServiceFeedBack>> GetAndCheckIfServiceFeedbackExist(Guid serviceFeebackId, bool trackChanges)
        {
            var serviceFeedback = await _repoManager.ServiceFeeback.GetServiceFeedbackAsync(serviceFeebackId, trackChanges);
            if (serviceFeedback == null) return serviceFeedback.NotFound(serviceFeebackId);
            return serviceFeedback.OkResult();
        }
    }
}
