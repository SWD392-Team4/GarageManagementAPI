using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace GarageManagementAPI.Repository
{
    public class AppointmentReplacementPartRepository : RepositoryBase<AppointmentReplacementPart>, IAppointmentReplacementPartRepository
    {
        public AppointmentReplacementPartRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<AppointmentReplacementPart?> GetAppointmentReplacementPartAsync(Guid id, bool trackChanges)
        {
            return await FindByCondition(ad => ad.Id.Equals(id), trackChanges).SingleOrDefaultAsync();
        }

        public async Task<PagedList<AppointmentReplacementPart>> GetAppointmentReplacementPartsAsync(AppoitnmentReplacementPartParameters appoitnmentReplacementPartParameters, bool trackChanges)
        {
            var appointmentReplacementParts = await FindAll(trackChanges)
                   .FilterByAppointmentId(appoitnmentReplacementPartParameters.AppointmentId)
                   .FilterByAppointmentDetailId(appoitnmentReplacementPartParameters.AppointmentDetailId)
                   .FilterByStatus(appoitnmentReplacementPartParameters.AppointmentReplacementPartStatus)
                   .Sort(appoitnmentReplacementPartParameters.OrderBy)
                   .Skip((appoitnmentReplacementPartParameters.PageNumber - 1) * appoitnmentReplacementPartParameters.PageSize)
                   .Take(appoitnmentReplacementPartParameters.PageSize)
                   .ToListAsync();

            var count = await FindAll(trackChanges)
                    .FilterByAppointmentId(appoitnmentReplacementPartParameters.AppointmentId)
                   .FilterByAppointmentDetailId(appoitnmentReplacementPartParameters.AppointmentDetailId)
                   .FilterByStatus(appoitnmentReplacementPartParameters.AppointmentReplacementPartStatus)
                    .CountAsync();


            return new PagedList<AppointmentReplacementPart>(
                appointmentReplacementParts,
                count,
                appoitnmentReplacementPartParameters.PageNumber,
                appoitnmentReplacementPartParameters.PageSize);
        }
    }

}
