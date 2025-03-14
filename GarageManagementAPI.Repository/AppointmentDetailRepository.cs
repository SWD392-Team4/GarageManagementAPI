using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Shared.Enums.SystemStatuss;

namespace GarageManagementAPI.Repository
{
    public class AppointmentDetailRepository : RepositoryBase<AppointmentDetail>, IAppointmentDetailRepository
    {
        public AppointmentDetailRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<AppointmentDetail?> GetAppointmentDetailAsync(Guid id, bool trackChanges)
        {
            return await FindByCondition(ad => ad.Id.Equals(id), trackChanges).SingleOrDefaultAsync();
        }

        public async new Task CreateAsync(AppointmentDetail entity)
        {
            entity.Status = AppointmentDetailStatus.Pending;
            entity.CreateAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            entity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            await base.CreateAsync(entity);
        }

        public async Task<PagedList<AppointmentDetail>> GetAppointmentDetailsAsync(AppointmentDetailParameters appointmentDetailParameters, bool trackChanges)
        {
            var appointments = await FindAll(trackChanges)
            .FilterByAppointmentId(appointmentDetailParameters.AppointmentId)
            .FilterByStatus(appointmentDetailParameters.AppointmentDetailStatus)
            .Sort(appointmentDetailParameters.OrderBy)
            .Skip((appointmentDetailParameters.PageNumber - 1) * appointmentDetailParameters.PageSize)
            .Take(appointmentDetailParameters.PageSize)
            .ToListAsync();

            var count = await FindAll(trackChanges)
                .FilterByAppointmentId(appointmentDetailParameters.AppointmentId)
                .FilterByStatus(appointmentDetailParameters.AppointmentDetailStatus)
                .CountAsync();


            return new PagedList<AppointmentDetail>(
                appointments,
                count,
                appointmentDetailParameters.PageNumber,
                appointmentDetailParameters.PageSize);
        }

        public async Task<IEnumerable<AppointmentDetail>> GetAppointmentDetailByAppointmentIdAsync(Guid appointmentId, bool trackChanges)
        {
            return await FindByCondition(ad => ad.AppointmentId.Equals(appointmentId), trackChanges)
                .Include(apd => apd.ServiceHistory)
                .ThenInclude(sh => sh.Service)
                .Include(apd => apd.AppointmentReplacementParts)
                .ThenInclude(arp => arp.ProductHistory)
                .ThenInclude(ph => ph.Product)
                .AsSplitQuery()
                .ToListAsync();
        }
    }

}
