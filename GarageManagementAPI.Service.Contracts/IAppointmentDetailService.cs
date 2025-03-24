using GarageManagementAPI.Shared.DataTransferObjects.AppointmentDetail;
using GarageManagementAPI.Shared.DataTransferObjects.Dashboard;
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

        Task<IEnumerable<ServiceStatisticsDto>> GetTotalEachService(int year, Guid? garageId, bool trackChanges);
        Task<IEnumerable<PackageStatisticsDto>> GetTotalEachPackage(int year, Guid? garageId, bool trackChanges);

        Task<Result> ConfirmAppointmentDetail(Guid garageId, Guid appointmentId, AppointmentDetailDtoForConfirm detailDtoForConfirm);
    }
}
