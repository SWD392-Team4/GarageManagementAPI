using GarageManagementAPI.Shared.DataTransferObjects.AppointmentDetail;
using GarageManagementAPI.Shared.ResultModel;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IAppointmentDetailService
    {
        Task<Result<IEnumerable<AppointmentDetailDto>>> GetAppointmentDetailsAsync(Guid garageId, Guid appointmentId);

        Task<Result> CancelAppointmentDetailsAsync(Guid garageId, Guid appointmentId, AppointmentDetailDtoForCancellation appointmentDetailDtoForCancellation);

        Task<Result> RejectAppointmentDetailsAsync(Guid garageId, Guid appointmentId, AppointmentDetailDtoForCancellation appointmentDetailDtoForCancellation);

        Task<Result<IEnumerable<AppointmentDetailDto>>> CreateAppointmentDetails(Guid garageId, Guid appointmentId, IEnumerable<AppointmentDetailDtoForCreation> appointmentDetailDtoForCreations);
    }
}
