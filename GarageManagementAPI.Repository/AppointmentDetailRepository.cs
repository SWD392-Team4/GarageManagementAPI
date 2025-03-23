using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.DataTransferObjects.Service;
using GarageManagementAPI.Shared.DataTransferObjects.Dashboard;

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

        //Dashboard
        public async Task<IEnumerable<ServiceStatisticsDto>> GetTotalEachService(int year, Guid? garageId, bool trackChanges)
        {
            DateTime startOfYear = new DateTime(year, 1, 1);
            DateTime endOfYear = new DateTime(year + 1, 1, 1);

            var services = await FindAll(trackChanges)
                .Where(a => a.ServiceHistory.CreatedAt >= startOfYear && a.ServiceHistory.CreatedAt < endOfYear)
                .Where(a => garageId == null || (a.Appointment != null && a.Appointment.GarageId == garageId))
                .GroupBy(a => a.ServiceHistory.ServiceId) 
                .Select(g => new ServiceStatisticsDto
                {
                    Id = g.Key,
                    Name = g.First().ServiceHistory.Service.ServiceName, 
                    Description = g.First().ServiceHistory.Service.Description,
                    EstimatedHours = g.First().ServiceHistory.Service.EstimatedHours,
                    TotalRevenue = g.Sum(a => a.ServiceHistory.Price),
                    TotalUsed = g.Count()
                })
                .OrderByDescending(s => s.TotalUsed)
                .ToListAsync();

            return services;
        }

        public async Task<IEnumerable<PackageStatisticsDto>> GetTotalEachPackage(int year, Guid? garageId, bool trackChanges)
        {
            DateTime startOfYear = new DateTime(year, 1, 1);
            DateTime endOfYear = new DateTime(year + 1, 1, 1);

            var packages = await FindAll(trackChanges)
                .Where(a => a.PackageHistory != null && a.PackageHistory.CreatedAt >= startOfYear && a.PackageHistory.CreatedAt < endOfYear)
                .Where(a => garageId == null || (a.Appointment != null && a.Appointment.GarageId == garageId))
                .GroupBy(a => a.PackageHistory!.PackageId) 
                .Select(g => new PackageStatisticsDto
                {
                    Id = g.Key,
                    Name = g.First().PackageHistory!.Package.PackageName,
                    Description = g.First().PackageHistory!.Package.Description, 
                    TotalRevenue = g.Sum(a => a.PackageHistory!.PackagePrice),
                    TotalUsed = g.Count() 
                })
                .OrderByDescending(s => s.TotalUsed)
                .ToListAsync();

            return packages;
        }

    }

}
