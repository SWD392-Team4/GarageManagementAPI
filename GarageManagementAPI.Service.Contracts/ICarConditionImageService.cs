using GarageManagementAPI.Shared.DataTransferObjects.CarConditionImage;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;

using System;
using System.Dynamic;

namespace GarageManagementAPI.Service.Contracts
{
    public interface ICarConditionImageService
    {
        Task<Result<IEnumerable<ExpandoObject>>> GetCarConditionImageByAppointmentDetailIdAsync(Guid appointmentId, Guid appointmentDetailId, CarConditionImageParameters carConditionImageParameters);

        Task<Result<CarConditionImageDto>> GetCarConditionImageByIdAsync(Guid appointmentId, Guid appointmentDetailId, Guid carConditionImageId);

        Task<Result<IEnumerable<CarConditionImageDto>>> CreateCarConditionImageAsync(Guid appointmentId, Guid appointmentDetailId, IEnumerable<(string? ImageId, string? ImageLink)> imageTuples, ConditionStage conditionStage);
    }
}
