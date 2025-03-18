using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.CarConditionImage;
using GarageManagementAPI.Shared.DataTransferObjects.PackageImage;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.ErrorsConstant.Package;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;
using System.Dynamic;

namespace GarageManagementAPI.Service
{
    public class CarConditionImageService : ICarConditionImage
    {
        private readonly IRepositoryManager _repoManager;
        private readonly IMapper _mapper;
        private readonly IDataShaperManager _dataShaper;
        public CarConditionImageService(IRepositoryManager repoManager, IMapper mapper, IDataShaperManager dataShaper)
        {
            _repoManager = repoManager;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }

        public Task<Result<IEnumerable<CarConditionImageDto>>> CreatePackageImageAsync(Guid garageId, Guid appointmentId, Guid appointmentDetailId, IEnumerable<(string? ImageId, string? ImageLink)> imageTuples, ConditionStage conditionStage)
        {
            var package = await _repoManager.Package.GetPackageByIdAsync(packageId, trackChanges: false);
            if (package is null)
                return Result<IEnumerable<PackageImageDto>>.NotFound(PackageErrors.GetPackageNotFoundError(packageId));

            var packageImages = new List<PackageImage>();
            foreach (var imageItem in imageTuples)
            {
                var packageImage = new PackageImage
                {
                    PackageId = packageId,
                    ImageLink = imageItem.ImageLink,
                    ImageId = imageItem.ImageId
                };
                packageImages.Add(packageImage);
            }
            await _repoManager.PackageImage.CreatesAsync(packageImages.ToArray());
            await _repoManager.SaveAsync();

            var packageImagesDto = _mapper.Map<IEnumerable<PackageImageDto>>(packageImages);

            return Result<IEnumerable<PackageImageDto>>.Ok(packageImagesDto);
        }

        public Task<Result<IEnumerable<ExpandoObject>>> GetCarConditionImageByAppointmentDetailIdAsync(Guid garageId, Guid appointmentId, Guid appointmentDetailId, CarConditionImageParameters carConditionImageParameters)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<ExpandoObject>>> GetCarConditionImageByAppointmentIdAsync(Guid garageId, Guid appointmentId, CarConditionImageParameters carConditionImageParameters)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<CarConditionImageDto>>> GetCarConditionImageByAppointmentIdAsync(Guid garageId, Guid appointmentId)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<CarConditionImageDto>>> GetCarConditionImageByAppointmentIdAsync(Guid garageId, Guid appointmentId, Guid appointmentDetailId)
        {
            throw new NotImplementedException();
        }

        public Task<Result<CarConditionImageDto>> GetPCarConditionImageByIdAsync(Guid garageId, Guid appointmentId, Guid appointmentDetailId, Guid carConditionImageId)
        {
            throw new NotImplementedException();
        }

        public Task<Result> RemoveCarConditionImageAsync(Guid garageId, Guid appointmentId, Guid appointmentDetailId, Guid carConditionImageId)
        {
            throw new NotImplementedException();
        }

        public Task<Result> RemoveCarConditionImageAsync(Guid garageId, Guid appointmentId, Guid appointmentDetailId)
        {
            throw new NotImplementedException();
        }
    }
}
