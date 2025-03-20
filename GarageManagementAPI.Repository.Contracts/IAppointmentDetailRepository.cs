using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.DataTransferObjects.Dashboard;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IAppointmentDetailRepository : IRepositoryBase<AppointmentDetail>
    {
        public Task<AppointmentDetail?> GetAppointmentDetailAsync(Guid id, bool trackChanges);

        public Task<IEnumerable<AppointmentDetail>> GetAppointmentDetailByAppointmentIdAsync(Guid appointmentId, bool trackChanges);

        public Task<PagedList<AppointmentDetail>> GetAppointmentDetailsAsync(AppointmentDetailParameters appointmentDetailParameters, bool trackChanges);
        Task<IEnumerable<ServiceStatisticsDto>> GetTotalEachService(int year, Guid? garageId, bool trackChanges);

        Task<IEnumerable<PackageStatisticsDto>> GetTotalEachPackage(int year, Guid? garageId, bool trackChanges);
    }
}
