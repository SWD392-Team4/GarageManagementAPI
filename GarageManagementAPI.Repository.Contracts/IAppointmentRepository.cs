using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IAppointmentRepository : IRepositoryBase<Appointment>
    {
        public Task<PagedList<Appointment>> GetAppointmentsAsync(AppointmentParameters appointmentParameters, bool trackChanges);

        public Task<Appointment?> GetAppointmentAsync(Guid id, bool trackChanges);
    }
}
