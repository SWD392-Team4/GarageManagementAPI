using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IAppointmentRepository : IRepositoryBase<Appointment>
    {
        public Task<PagedList<Appointment>> GetAppointmentsAsync(Guid garageId, AppointmentParameters appointmentParameters, bool trackChanges);

        public Task<Appointment?> GetAppointmentAsync(Guid garageId, Guid appoitnmentId, bool trackChanges);

        public Task<Appointment?> GetAppointmentAsync(Guid appointmentId, bool trackChanges);
    }
}
