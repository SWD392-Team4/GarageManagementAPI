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

        public async Task<AppointmentReplacementPart?> GetAppointmentReplacementPartAsync(Guid appointmentDetailId, Guid appointmentReplacementPartId, bool trackChanges)
        {
            return await FindByCondition(ad => ad.Id.Equals(appointmentReplacementPartId) && ad.AppointmentDetailId.Equals(appointmentDetailId), trackChanges)
                 .Include(ad => ad.ProductHistory)
                   .ThenInclude(ph => ph.Product)
                   .ThenInclude(p => p.ProductImages)
                   .Include(rp => rp.AppointmentReplacementPart_ProductAtGarages)
                   .SingleOrDefaultAsync();
        }

        public async Task<PagedList<AppointmentReplacementPart>> GetAppointmentReplacementPartsAsync(Guid appointmentDetailId, AppoitnmentReplacementPartParameters appoitnmentReplacementPartParameters, bool trackChanges)
        {
            var appointmentReplacementParts = await FindByCondition(ad => ad.AppointmentDetailId.Equals(appointmentDetailId), trackChanges)
                   .FilterByAppointmentId(appoitnmentReplacementPartParameters.AppointmentId)
                   .FilterByAppointmentDetailId(appoitnmentReplacementPartParameters.AppointmentDetailId)
                   .FilterByStatus(appoitnmentReplacementPartParameters.AppointmentReplacementPartStatus)
                   .Sort(appoitnmentReplacementPartParameters.OrderBy)
                   .Skip((appoitnmentReplacementPartParameters.PageNumber - 1) * appoitnmentReplacementPartParameters.PageSize)
                   .Take(appoitnmentReplacementPartParameters.PageSize)
                   .Include(ad => ad.ProductHistory)
                   .ThenInclude(ph => ph.Product)
                   .ThenInclude(p => p.ProductImages)
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
