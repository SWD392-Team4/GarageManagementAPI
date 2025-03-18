using AutoMapper;

using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.CarConditionImage;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.ErrorsConstant.Appointment;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;

using Microsoft.EntityFrameworkCore;

using System.Dynamic;

namespace GarageManagementAPI.Service
{
    public class CarConditionImageService : ICarConditionImageService
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

        public async Task<Result<IEnumerable<CarConditionImageDto>>> CreateCarConditionImageAsync(Guid appointmentId, Guid appointmentDetailId, IEnumerable<(string? ImageId, string? ImageLink)> imageTuples, ConditionStage conditionStage)
        {
            var appointment = await _repoManager.Appointment.FindByCondition(a => a.Id.Equals(appointmentId), false).SingleOrDefaultAsync();
            if (appointment is null)
                return Result<IEnumerable<CarConditionImageDto>>.NotFound(AppointmentErrors.GetAppointmentNotFoundError(appointmentId));

            var appointmentDetail = await _repoManager.AppointmentDetail.FindByCondition(ad => ad.Id.Equals(appointmentDetailId) && ad.AppointmentId.Equals(appointmentId), false).SingleOrDefaultAsync();
            if (appointmentDetail is null)
                return Result<IEnumerable<CarConditionImageDto>>.NotFound(AppointmentErrors.GetAppointmentDetailNotFound(appointmentDetailId));

            var carConditionImages = new List<CarConditionImage>();
            foreach (var imageItem in imageTuples)
            {
                var carConditionImage = new CarConditionImage
                {
                    AppointmentDetailId = appointmentDetailId,
                    ImageLink = imageItem.ImageLink,
                    ImageId = imageItem.ImageId,
                    ConditionStage = conditionStage
                };
                carConditionImages.Add(carConditionImage);
            }
            await _repoManager.CarConditionImage.CreatesAsync([.. carConditionImages]);
            await _repoManager.SaveAsync();

            var carConditionImageDtos = _mapper.Map<IEnumerable<CarConditionImageDto>>(carConditionImages);

            return Result<IEnumerable<CarConditionImageDto>>.Ok(carConditionImageDtos);
        }

        public async Task<Result<IEnumerable<ExpandoObject>>> GetCarConditionImageByAppointmentDetailIdAsync(Guid appointmentId, Guid appointmentDetailId, CarConditionImageParameters carConditionImageParameters)
        {
            var appointment = await _repoManager.Appointment.FindByCondition(a => a.Id.Equals(appointmentId), false).SingleOrDefaultAsync();
            if (appointment is null)
                return Result<IEnumerable<ExpandoObject>>.NotFound(AppointmentErrors.GetAppointmentNotFoundError(appointmentId));

            var appointmentDetail = await _repoManager.AppointmentDetail.FindByCondition(ad => ad.Id.Equals(appointmentDetailId) && ad.AppointmentId.Equals(appointmentId), false).SingleOrDefaultAsync();
            if (appointmentDetail is null)
                return Result<IEnumerable<ExpandoObject>>.NotFound(AppointmentErrors.GetAppointmentDetailNotFound(appointmentDetailId));

            var carConditionImages = await _repoManager.CarConditionImage.GetCarConditionImagesAsync(appointmentId, appointmentDetailId, carConditionImageParameters, trackChanges: false);

            var carConditionImageDtos = _mapper.Map<IEnumerable<CarConditionImageDto>>(carConditionImages);

            var carConditionImageDtoShapers = _dataShaper.CarConditionImage.ShapeData(carConditionImageDtos, carConditionImageParameters.Fields);

            return Result<IEnumerable<ExpandoObject>>.Ok(carConditionImageDtoShapers);
        }

        public async Task<Result<CarConditionImageDto>> GetCarConditionImageByIdAsync(Guid appointmentId, Guid appointmentDetailId, Guid carConditionImageId)
        {
            var appointment = await _repoManager.Appointment.FindByCondition(a => a.Id.Equals(appointmentId), false).SingleOrDefaultAsync();
            if (appointment is null)
                return Result<CarConditionImageDto>.NotFound(AppointmentErrors.GetAppointmentNotFoundError(appointmentId));

            var appointmentDetail = await _repoManager.AppointmentDetail.FindByCondition(ad => ad.Id.Equals(appointmentDetailId), false).SingleOrDefaultAsync();
            if (appointmentDetail is null)
                return Result<CarConditionImageDto>.NotFound(AppointmentErrors.GetAppointmentDetailNotFound(appointmentDetailId));

            var carConditionImage = await _repoManager.CarConditionImage.GetCarConditionImageAsync(appointmentDetailId, carConditionImageId, trackChanges: false);
            if (carConditionImage is null)
                return Result<CarConditionImageDto>.NotFound(AppointmentErrors.GetCarConditionImageNotFoundError(carConditionImageId));

            var carConditionImageDto = _mapper.Map<CarConditionImageDto>(carConditionImage);

            return Result<CarConditionImageDto>.Ok(carConditionImageDto);


        }
    }
}
