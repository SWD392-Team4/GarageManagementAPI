using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IAppointmentReplacementPartRepository : IRepositoryBase<AppointmentReplacementPart>
    {
        public Task<AppointmentReplacementPart?> GetAppointmentReplacementPartAsync(Guid id, bool trackChanges);

        public Task<PagedList<AppointmentReplacementPart>> GetAppointmentReplacementPartsAsync(AppoitnmentReplacementPartParameters appoitnmentReplacementPartParameters, bool trackChanges);
    }
}
