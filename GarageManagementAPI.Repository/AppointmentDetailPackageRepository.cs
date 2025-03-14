using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace GarageManagementAPI.Repository
{
    public class AppointmentDetailPackageRepository : RepositoryBase<AppointmentDetailPackage>, IAppointmentDetailPackageRepository
    {
        public AppointmentDetailPackageRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<AppointmentDetailPackage?> GetAppointmentDetailPackageAsync(Guid id, bool trackChanges)
        {
            return await FindByCondition(ad => ad.Id.Equals(id), trackChanges).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<AppointmentDetailPackage>> GetAppointmentDetailPackageByAppointmentIdAsync(Guid appointmentId, bool trackChanges)
        {
            return await FindByCondition(ad => ad.AppointmentId.Equals(appointmentId), trackChanges)
                .Include(adp => adp.PackageHistory)
                .ToListAsync();
        }

        public async Task<PagedList<AppointmentDetailPackage>> GetAppointmentDetailPackagesByAppointmentIdAsync(AppointmentDetailPackageParameters appointmentDetailPackageParameters, bool trackChanges)
        {
            var appointmentDetailPackages = await FindAll(trackChanges)
                        .FilterByAppointmentId(appointmentDetailPackageParameters.AppointmentId)
                        .FilterByStatus(appointmentDetailPackageParameters.AppointmentDetailPackageStatus)
                        .Sort(appointmentDetailPackageParameters.OrderBy)
                        .Skip((appointmentDetailPackageParameters.PageNumber - 1) * appointmentDetailPackageParameters.PageSize)
                        .Take(appointmentDetailPackageParameters.PageSize)
                        .ToListAsync();

            var count = await FindAll(trackChanges)
                        .FilterByAppointmentId(appointmentDetailPackageParameters.AppointmentId)
                        .FilterByStatus(appointmentDetailPackageParameters.AppointmentDetailPackageStatus)
                        .CountAsync();


            return new PagedList<AppointmentDetailPackage>(
                appointmentDetailPackages,
                count,
                appointmentDetailPackageParameters.PageNumber,
                appointmentDetailPackageParameters.PageSize);
        }
    }

}
