using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Service.Extension;
using GarageManagementAPI.Shared.DataTransferObjects.Product;
using GarageManagementAPI.Shared.DataTransferObjects.ProductImage;
using GarageManagementAPI.Shared.DataTransferObjects.ServiceImage;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.ErrorsConstant.ServiceImage;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;
using System.Dynamic;

namespace GarageManagementAPI.Service
{
    public class ServiceImageService : IServiceImageService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly IDataShaperManager _dataShaper;
        public ServiceImageService(IRepositoryManager repositoryManager, IMapper mapper, IDataShaperManager dataShaper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }

        public async Task<Result<ServiceImageDto>> CreateImageService(Guid serviceId, string imgId, string imgUrl)
        {
            var serviceEntity = await GetAndCheckServiceExist(serviceId, false);
            if (!serviceEntity.IsSuccess) return Result<ServiceImageDto>.Failure(serviceEntity.StatusCode, serviceEntity.Errors!);
            var serviceImage = new ServiceImage
            {
                ServiceId = serviceId,
                ImageId = imgId,
                ImageLink = imgUrl,
                Status = ServiceImageStatus.Active,
                CreatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime(),
                UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime()
            };
            await _repositoryManager.ServiceImage.CreateServiceImgAsync(serviceImage);
            await _repositoryManager.SaveAsync();
            var serviceToReturn = _mapper.Map<ServiceImageDto>(serviceImage);
            return serviceToReturn.CreatedResult();
        }

        public async Task<Result<IEnumerable<ExpandoObject>>> GetImageByIdService(Guid serviceId, ServiceImageParameters serviceImageParameters, bool trackChanges)
        {
            var serviceImagesWithMetadata = await _repositoryManager.ServiceImage.GetServiceImgByIdServiceAsync(serviceId, serviceImageParameters, trackChanges);
            var serviceImagesDto = _mapper.Map<IEnumerable<ServiceImageDto>>(serviceImagesWithMetadata);
            var productsShaped = _dataShaper.ServiceImage.ShapeData(serviceImagesDto, serviceImageParameters.Fields);
            return Result<IEnumerable<ExpandoObject>>.Ok(productsShaped, serviceImagesWithMetadata.MetaData);
        }

        public async Task<Result> UpdateServiceImage(Guid serviceImageId, ServiceImageDtoForUpdate serviceImageDtoForUpdate)
        {
            var serviceImage = await GetAndCheckServiceImageIsExist(serviceImageId, true);
            if (!serviceImage.IsSuccess) return Result<ServiceImage>.BadRequest([ServiceImageErrors.GetServiceImageNotFoundWithIdError(serviceImageId)]);
            var serviceEntity = _mapper.Map<ServiceImage>(serviceImageDtoForUpdate);
            serviceEntity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            _repositoryManager.ServiceImage.UpdateServiceImage(serviceEntity);
            await _repositoryManager.SaveAsync();
            return Result.Success(serviceImage.StatusCode);
        }

        private async Task<Result<Entities.Models.Service>> GetAndCheckServiceExist(Guid serviceId, bool trackChanges)
        {
            var service = await _repositoryManager.Service.GetServiceByIdAsync(serviceId, trackChanges);
            if (service == null) return service.NotFound(serviceId);
            return service.OkResult();
        }

        private async Task<Result<ServiceImage>> GetAndCheckServiceImageIsExist(Guid serviceImageId, bool trackchanges)
        {
            var image = await _repositoryManager.ServiceImage.GetServiceImgageAsync(serviceImageId, trackchanges);
            if (image == null) return image.NotFoundId(serviceImageId);
            return image.OkResult();
        }
    }
}
