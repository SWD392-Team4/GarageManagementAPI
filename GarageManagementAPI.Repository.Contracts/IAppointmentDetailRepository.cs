using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IAppointmentDetailRepository : IRepositoryBase<AppointmentDetail>
    {
        public Task<PagedList<AppointmentDetail>> GetAppointmentDetailsAsync(AppointmentDetailParameters appointmentDetailParameters, bool trackChanges);

        public Task<AppointmentDetail> GetAppointmentDetailAsync(Guid id, bool trackChanges);

        public Task<AppointmentDetail> GetAppointmentDetailsByAppointmentIdAsync(Guid appointmentId, bool trackChanges);
    }
}
