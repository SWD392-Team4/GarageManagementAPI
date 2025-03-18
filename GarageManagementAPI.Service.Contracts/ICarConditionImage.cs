using GarageManagementAPI.Shared.DataTransferObjects.CarConditionImage;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;
using System;
using System.Dynamic;

namespace GarageManagementAPI.Service.Contracts
{
    public interface ICarConditionImage
    {
        Task<Result<IEnumerable<ExpandoObject>>> GetCarConditionImageByAppointmentIdAsync(Guid garageId,Guid appointmentId, CarConditionImageParameters carConditionImageParameters);

        Task<Result<IEnumerable<ExpandoObject>>> GetCarConditionImageByAppointmentDetailIdAsync(Guid garageId, Guid appointmentId, Guid appointmentDetailId, CarConditionImageParameters carConditionImageParameters);

        Task<Result<IEnumerable<CarConditionImageDto>>> GetCarConditionImageByAppointmentIdAsync(Guid garageId, Guid appointmentId);

        Task<Result<IEnumerable<CarConditionImageDto>>> GetCarConditionImageByAppointmentIdAsync(Guid garageId, Guid appointmentId, Guid appointmentDetailId);

        Task<Result<CarConditionImageDto>> GetPCarConditionImageByIdAsync(Guid garageId, Guid appointmentId, Guid appointmentDetailId, Guid carConditionImageId);

        Task<Result<IEnumerable<CarConditionImageDto>>> CreatePackageImageAsync(Guid garageId, Guid appointmentId, Guid appointmentDetailId, IEnumerable<(string? ImageId, string? ImageLink)> imageTuples, ConditionStage conditionStage);

        Task<Result> RemoveCarConditionImageAsync(Guid garageId, Guid appointmentId, Guid appointmentDetailId, Guid carConditionImageId);

        Task<Result> RemoveCarConditionImageAsync(Guid garageId, Guid appointmentId, Guid appointmentDetailId);


    }
}
