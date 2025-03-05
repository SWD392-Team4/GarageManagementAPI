using GarageManagementAPI.Shared.DataTransferObjects.Appointment;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IAppointmentService
    {
        public Task<Result<IEnumerable<AppointmentDto>>> GetAppointmentsAsync(AppointmentParameters appointmentParameters, bool trackChanges);

        public Task<Result<AppointmentDto>> GetAppointmentAsync(Guid id, bool trackChanges);

        public Task<Result<AppointmentDto>> CreateAppointment(AppointmentDtoForCreate appointmentDtoForCreate);
    }
}
