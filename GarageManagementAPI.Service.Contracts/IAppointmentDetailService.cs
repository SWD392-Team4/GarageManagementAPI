using GarageManagementAPI.Shared.DataTransferObjects.AppointmentDetail;
using GarageManagementAPI.Shared.DataTransferObjects.EmployeeSchedule;
using GarageManagementAPI.Shared.ResultModel;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IAppointmentDetailService
    {
        Task<Result<IEnumerable<AppointmentDetailDto>>> GetAppointmentDetailsAsync(Guid garageId, Guid appointmentId);

        Task<Result> CancelAppointmentDetailsAsync(Guid garageId, Guid appointmentId, AppointmentDetailDtoForCancellation appointmentDetailDtoForCancellation);

        Task<Result> RejectAppointmentDetailsAsync(Guid garageId, Guid appointmentId, AppointmentDetailDtoForCancellation appointmentDetailDtoForCancellation);

        Task<Result<IEnumerable<AppointmentDetailDto>>> CreateAppointmentDetails(Guid garageId, Guid appointmentId, IEnumerable<AppointmentDetailDtoForCreation> appointmentDetailDtoForCreations);

        Task<Result> AssignEmployee(Guid garageId, Guid appointmentId, Guid detailId, EmployeeScheduleDtoForAssign employeeScheduleDtoForAssign);

        Task<Result> UnAssignEmployee(Guid garageId, Guid appointmentId, Guid detailId, EmployeeScheduleDtoForUnassign employeeScheduleDtoForUnassign);
    }
}
