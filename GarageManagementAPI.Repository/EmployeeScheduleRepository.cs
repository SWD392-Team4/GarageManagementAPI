using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace GarageManagementAPI.Repository
{
    public class EmployeeScheduleRepository : RepositoryBase<EmployeeSchedule>, IEmployeeScheduleRepository
    {
        public EmployeeScheduleRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async new Task CreateAsync(EmployeeSchedule entity)
        {
            var now = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            entity.CreatedAt = now;
            entity.UpdatedAt = now;
            entity.Status = EmployeeScheduleStatus.Assigned;
            await base.CreateAsync(entity);
        }

        public async Task<EmployeeSchedule?> GetEmployeeScheduleOfAppointmentDetailAsync(Guid garageId, Guid appointmentId, Guid appointmentDetailId, Guid employeeId, bool trackChanges)
        {
            var employeeSchedule = await FindByCondition(es =>
                        es.Employee.EmployeeInfo != null &&
                        es.Employee.EmployeeInfo.WorkplaceId.Equals(garageId) &&
                        es.AppointmentDetail.AppointmentId.Equals(appointmentId) &&
                        es.AppointmentDetailId.Equals(appointmentDetailId) &&
                        es.EmployeeId.Equals(employeeId), trackChanges)
                .Include(e => e.Employee)
                .ThenInclude(e => e.Roles)
                .Include(e => e.AppointmentDetail)
                .ThenInclude(ad => ad.AppointmentReplacementParts)
                .ThenInclude(arp => arp.ProductHistory)
                .ThenInclude(ph => ph.Product)
                .Include(e => e.AppointmentDetail)
                .ThenInclude(ad => ad.ServiceHistory)
                .ThenInclude(sh => sh.Service)
                            .SingleOrDefaultAsync();
            return employeeSchedule;
        }

        public async Task<IEnumerable<EmployeeSchedule>> GetEmployeeSchedulesByAppointmentDetailAsync(Guid garageId, Guid appointmentId, Guid appointmentDetailId, bool trackChanges)
        {
            var employeeSchedule = await FindByCondition(es =>
                    es.Employee.EmployeeInfo != null &&
                     es.Employee.EmployeeInfo.WorkplaceId.Equals(garageId) &&
                     es.AppointmentDetail.AppointmentId.Equals(appointmentId) &&
                     es.AppointmentDetailId.Equals(appointmentDetailId), trackChanges)
                .Include(e => e.Employee)
                .ThenInclude(e => e.Roles)
                .Include(e => e.AppointmentDetail)
                .ThenInclude(ad => ad.AppointmentReplacementParts)
                .ThenInclude(arp => arp.ProductHistory)
                .ThenInclude(ph => ph.Product)
                .Include(e => e.AppointmentDetail)
                .ThenInclude(ad => ad.ServiceHistory)
                .ThenInclude(sh => sh.Service)
                         .ToListAsync();
            return employeeSchedule;
        }

        public async Task<IEnumerable<EmployeeSchedule>> GetEmployeeSchedulesOfAppointmentAsync(Guid garageId, Guid appointmentId, bool trackChanges)
        {
            var employeeSchedule = await FindByCondition(es =>
                         es.Employee.EmployeeInfo != null &&
                         es.Employee.EmployeeInfo.WorkplaceId.Equals(garageId) &&
                         es.AppointmentDetail.AppointmentId.Equals(appointmentId), trackChanges)
                .Include(e => e.Employee)
                .ThenInclude(e => e.Roles)
                .Include(e => e.AppointmentDetail)
                .ThenInclude(ad => ad.AppointmentReplacementParts)
                .ThenInclude(arp => arp.ProductHistory)
                .ThenInclude(ph => ph.Product)
                .Include(e => e.AppointmentDetail)
                .ThenInclude(ad => ad.ServiceHistory)
                .ThenInclude(sh => sh.Service)
                             .ToListAsync();
            return employeeSchedule;
        }

        public async Task<PagedList<EmployeeSchedule>> GetEmployeeSchedulesOfAppointmentAsync(Guid garageId, Guid appointmentId, EmployeeScheduleParameters employeeScheduleParameters, bool trackChanges)
        {
            var employeeSchedules = await FindByCondition(es =>
                        es.Employee.EmployeeInfo != null &&
                        es.Employee.EmployeeInfo.WorkplaceId.Equals(garageId) &&
                        es.AppointmentDetail.AppointmentId.Equals(appointmentId), trackChanges)
                .FilterByStartTime(employeeScheduleParameters.StartTime)
                .FilterByEstimatedEndTime(employeeScheduleParameters.EstimatedEndTime)
                .FilterByActualEndTime(employeeScheduleParameters.ActualEndTime)
                .FilterByStatus(employeeScheduleParameters.Status)
                .FilterByCreatedAt(employeeScheduleParameters.CreatedAt)
                .FilterByUpdatedAt(employeeScheduleParameters.UpdatedAt)
                .FilterByEmployeeId(employeeScheduleParameters.EmployeeId)
                .Include(e => e.Employee)
                .ThenInclude(e => e.Roles)
                .Include(e => e.AppointmentDetail)
                .ThenInclude(ad => ad.AppointmentReplacementParts)
                .ThenInclude(arp => arp.ProductHistory)
                .ThenInclude(ph => ph.Product)
                .Include(e => e.AppointmentDetail)
                .ThenInclude(ad => ad.ServiceHistory)
                .ThenInclude(sh => sh.Service)
                    .Sort(employeeScheduleParameters.OrderBy)
                    .Skip((employeeScheduleParameters.PageNumber - 1) * employeeScheduleParameters.PageSize)
                    .Take(employeeScheduleParameters.PageSize)
                    .ToListAsync();

            var count = await FindByCondition(es =>
                        es.Employee.EmployeeInfo != null &&
                        es.Employee.EmployeeInfo.WorkplaceId.Equals(garageId) &&
                        es.AppointmentDetail.AppointmentId.Equals(appointmentId), trackChanges)
                        .CountAsync();


            return new PagedList<EmployeeSchedule>(
                employeeSchedules,
                count,
                employeeScheduleParameters.PageNumber,
                employeeScheduleParameters.PageSize);
        }

        public async Task<IEnumerable<EmployeeSchedule>> GetEmployeeSchedulesOfEmployeeAsync(Guid garageId, Guid employeeId, bool trackChanges)
        {
            var employeeSchedule = await FindByCondition(es =>
                        es.Employee.EmployeeInfo != null &&
                        es.Employee.EmployeeInfo.WorkplaceId.Equals(garageId) &&
                        es.EmployeeId.Equals(employeeId), trackChanges)
                .Include(e => e.Employee)
                .ThenInclude(e => e.Roles)
                .Include(e => e.AppointmentDetail)
                .ThenInclude(ad => ad.AppointmentReplacementParts)
                .ThenInclude(arp => arp.ProductHistory)
                .ThenInclude(ph => ph.Product)
                .Include(e => e.AppointmentDetail)
                .ThenInclude(ad => ad.ServiceHistory)
                .ThenInclude(sh => sh.Service)
                            .ToListAsync();
            return employeeSchedule;
        }

        public async Task<PagedList<EmployeeSchedule>> GetEmployeeSchedulesOfEmployeeAsync(Guid garageId, Guid employeeId, EmployeeScheduleParameters employeeScheduleParameters, bool trackChanges)
        {
            var employeeSchedules = await FindByCondition(es =>
                    es.Employee.EmployeeInfo != null &&
                    es.Employee.EmployeeInfo.WorkplaceId.Equals(garageId) &&
                    es.EmployeeId.Equals(employeeId), trackChanges)
                .FilterByStartTime(employeeScheduleParameters.StartTime)
                .FilterByEstimatedEndTime(employeeScheduleParameters.EstimatedEndTime)
                .FilterByActualEndTime(employeeScheduleParameters.ActualEndTime)
                .FilterByStatus(employeeScheduleParameters.Status)
                .FilterByCreatedAt(employeeScheduleParameters.CreatedAt)
                .FilterByUpdatedAt(employeeScheduleParameters.UpdatedAt)
                .FilterByAppointmentId(employeeScheduleParameters.AppointmentId)
                .Include(e => e.Employee)
                .ThenInclude(e => e.Roles)
                .Include(e => e.AppointmentDetail)
                .ThenInclude(ad => ad.AppointmentReplacementParts)
                .ThenInclude(arp => arp.ProductHistory)
                .ThenInclude(ph => ph.Product)
                .Include(e => e.AppointmentDetail)
                .ThenInclude(ad => ad.ServiceHistory)
                .ThenInclude(sh => sh.Service)
                    .Sort(employeeScheduleParameters.OrderBy)
                    .Skip((employeeScheduleParameters.PageNumber - 1) * employeeScheduleParameters.PageSize)
                    .Take(employeeScheduleParameters.PageSize)
                    .ToListAsync();

            var count = await FindByCondition(es =>
                    es.Employee.EmployeeInfo != null &&
                    es.Employee.EmployeeInfo.WorkplaceId.Equals(garageId) &&
                    es.EmployeeId.Equals(employeeId), trackChanges)
                .FilterByStartTime(employeeScheduleParameters.StartTime)
                .FilterByEstimatedEndTime(employeeScheduleParameters.EstimatedEndTime)
                .FilterByActualEndTime(employeeScheduleParameters.ActualEndTime)
                .FilterByStatus(employeeScheduleParameters.Status)
                .FilterByCreatedAt(employeeScheduleParameters.CreatedAt)
                .FilterByUpdatedAt(employeeScheduleParameters.UpdatedAt)
                .FilterByAppointmentId(employeeScheduleParameters.AppointmentId)
                        .CountAsync();


            return new PagedList<EmployeeSchedule>(
                employeeSchedules,
                count,
                employeeScheduleParameters.PageNumber,
                employeeScheduleParameters.PageSize);
        }

        public new void Update(EmployeeSchedule entity)
        {
            entity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            base.Update(entity);
        }
    }
}
