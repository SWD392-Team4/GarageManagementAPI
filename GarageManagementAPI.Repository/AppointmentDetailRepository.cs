using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

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
    }

}
