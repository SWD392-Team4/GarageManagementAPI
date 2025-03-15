using GarageManagementAPI.Shared.DataTransferObjects.AppointmentReplacementPart;
using GarageManagementAPI.Shared.ResultModel;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IAppointmentReplacementPartService
    {
        Task<Result<IEnumerable<AppointmentReplacementPartDto>>> GetAppointmentReplacementPartsAsync(Guid garageId, Guid appointmentId, Guid appointmentDetailId);
        Task<Result<AppointmentReplacementPartDto>> GetAppointmentReplacementPartAsync(Guid garageId, Guid appointmentId, Guid appointmentDetailId, Guid replacementPartId);
        Task<Result<AppointmentReplacementPartDto>> CreateAppointmentReplacementPartAsync(Guid garageId, Guid appointmentId, Guid appointmentDetailId, AppointmentReplacementPartDtoForCreation appointmentReplacementPartDtoForCreation);
        //Task<Result> UpdateAppointmentReplacementPartAsync(Guid garageId, Guid appointmentId, Guid appointmentDetailId, Guid replacementPartId, AppointmentReplacementPartDtoForUpdate appointmentReplacementPartDtoForUpdate);
    }
}
