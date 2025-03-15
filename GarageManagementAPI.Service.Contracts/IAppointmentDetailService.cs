using GarageManagementAPI.Shared.DataTransferObjects.AppointmentDetail;
using GarageManagementAPI.Shared.ResultModel;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IAppointmentDetailService
    {
        Task<Result> DeleteAppointmentDetailAsync(Guid garageId, Guid appointmentId, IEnumerable<Guid> appointmentDetailIds);

        Task<Result<IEnumerable<AppointmentDetailDto>>> GetAppointmentDetailAsync(Guid garageId, Guid appointmentId);

        Task<Result> CancelAppointmentDetailAsync(Guid garageId, Guid appointmentId, IEnumerable<Guid> appointmentDetailIds);

        Task<Result> ApproveAppointmentDetailAsync(Guid garageId, Guid appointmentId, IEnumerable<Guid> appointmentDetailIds);

        Task<Result<IEnumerable<AppointmentDetailDto>>> CreateAppointmentDetails(Guid garageId, Guid appointmentId, IEnumerable<AppointmentDetailDtoForCreation> appointmentDetailDtoForCreations);
    }
}
