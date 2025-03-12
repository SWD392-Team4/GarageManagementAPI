using GarageManagementAPI.Shared.DataTransferObjects.Appointment;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;
using System.Dynamic;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IAppointmentService
    {
        Task<Result<ExpandoObject>> GetAppointment(Guid garageId, Guid appointmentId, string? fields = null);

        Task<Result<IEnumerable<ExpandoObject>>> GetAppointments(Guid garageId, AppointmentParameters appointmentParameters);

        Task<Result<AppointmentDto>> CreateAppointment(Guid garageId, Guid? userId, AppointmentDtoForCreation appointmentDtoCreation);

        Task<Result<AppointmentDto>> ConfirmAppointment(Guid garageId, Guid appointmentId, string? userId, string? role, AppointmentDtoForConfirmation appointmentConfirmation);
    }
}
