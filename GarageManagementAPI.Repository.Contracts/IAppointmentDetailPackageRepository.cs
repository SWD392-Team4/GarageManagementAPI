using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IAppointmentDetailPackageRepository : IRepositoryBase<AppointmentDetailPackage>
    {
        public Task<PagedList<AppointmentDetailPackage>> GetAppointmentDetailPackagesAsync(AppointmentDetailPackageParameters appointmentDetailPackageParameters, bool trackChanges);

        public Task<AppointmentDetailPackage> GetAppointmentDetailPackageAsync(Guid id, bool trackChanges);

        public Task<PagedList<AppointmentDetailPackage>> GetAppointmentDetailPackagesByAppointmentIdAsync(Guid appointmentId, bool trackChanges);
    }
}
