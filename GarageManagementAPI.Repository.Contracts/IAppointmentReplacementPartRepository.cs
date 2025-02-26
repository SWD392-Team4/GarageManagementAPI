using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IAppointmentReplacementPartRepository : IRepositoryBase<AppointmentReplacementPart>
    {
        public Task<PagedList<AppointmentReplacementPart>> GetAppointmentReplacementPartsAsync(AppointmentDetailPackageParameters appointmentDetailPackageParameters, bool trackChanges);

        public Task<AppointmentReplacementPart> GetAppointmentReplacementPartAsync(Guid id, bool trackChanges);

        public Task<PagedList<AppointmentReplacementPart>> GetAppointmentReplacementPartsByAppointmentDetailIdAsync(Guid appointmentDetailId, bool trackChanges);

        public Task<PagedList<AppointmentReplacementPart>> GetAppointmentReplacementPartsByAppointmentIdAsync(Guid appointmentId, bool trackChanges);
    }
}
