using GarageManagementAPI.Shared.DataTransferObjects.Appointment;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.ResultModel;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IAppointmentService
    {
        Task<Result> ConfirmAppointment(Guid garageId, Guid appointmentId, Guid? userId, string? role, AppointmentConfirmationDto appointmentConfirmation);

        Task<Result<AppointmentDto>> CreateAppointment(Guid garageId, Guid? userId, string? role, AppointmentDtoCreation appointmentDtoCreation);
    }
}
