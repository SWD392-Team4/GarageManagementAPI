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

        Task<Result<IEnumerable<ExpandoObject>>> GetAppointments(Guid garageId, AppointmentParameters appointmentParameters, Guid userId, string role);

        Task<Result<AppointmentDto>> CreateAppointment(Guid garageId, Guid? userId, AppointmentDtoForCreation appointmentDtoCreation);

        Task<Result<AppointmentDto>> GetAppointmentForGuest(Guid garageId, AppointmentDtoForGuest appointmentDtoForGuest);

        Task<Result> CancelAppointmentForGuest(Guid garageId, AppointmentDtoForGuestCancellation appointmentDtoForGuest);

        Task<Result> CancelAppointment(Guid garageId, Guid appointmentId, Guid userId, string role, AppointmentDtoForCancellation appointmentDtoForCancellation);

        Task<Result> ConfirmAppointment(Guid garageId, Guid appointmentId, Guid userId, AppointmentDtoForConfirmation appointmentConfirmation);

        Task<Result> UpdateAppointmentInformation(Guid garageId, Guid appointmentId, Guid userId, AppointmentDtoForUpdate appointmentDtoForUpdate);

    }
}
