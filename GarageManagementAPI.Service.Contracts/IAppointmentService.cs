using GarageManagementAPI.Shared.DataTransferObjects.Appointment;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IAppointmentService
    {
        public Task<Result<IEnumerable<AppointmentDto>>> GetAppointmentsAsync(AppointmentParameters appointmentParameters, bool trackChanges);
    }
}
