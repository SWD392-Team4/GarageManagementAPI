using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IAppointmentDetailRepository : IRepositoryBase<AppointmentDetail>
    {
        public Task<AppointmentDetail?> GetAppointmentDetailAsync(Guid id, bool trackChanges);

        public Task<IEnumerable<AppointmentDetail>> GetAppointmentDetailByAppointmentIdAsync(Guid appointmentId, bool trackChanges);

        public Task<PagedList<AppointmentDetail>> GetAppointmentDetailsAsync(AppointmentDetailParameters appointmentDetailParameters, bool trackChanges);
    }
}
