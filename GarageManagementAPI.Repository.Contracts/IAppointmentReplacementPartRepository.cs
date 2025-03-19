using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IAppointmentReplacementPartRepository : IRepositoryBase<AppointmentReplacementPart>
    {
        public Task<AppointmentReplacementPart?> GetAppointmentReplacementPartAsync(Guid appointmentDetailId, Guid appointmentReplacementPartId, bool trackChanges);

        public Task<PagedList<AppointmentReplacementPart>> GetAppointmentReplacementPartsAsync(Guid appointmentDetailId, AppoitnmentReplacementPartParameters appoitnmentReplacementPartParameters, bool trackChanges);
    }
}
