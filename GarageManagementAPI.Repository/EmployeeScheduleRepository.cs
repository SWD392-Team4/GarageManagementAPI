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


        public async Task<IEnumerable<EmployeeSchedule>> GetOverlappingSchedules(Guid garageId, Guid employeeId, DateTimeOffset now, bool trackChanges)
        {
            var employeeSchedules = await FindByCondition(es =>
                    es.EstimatedEndTime.HasValue &&
                    es.EstimatedEndTime > now && es.Status != EmployeeScheduleStatus.Completed && es.EmployeeId.Equals(employeeId) && es.Employee.EmployeeInfo.WorkplaceId.Equals(garageId), trackChanges).ToListAsync();

            return employeeSchedules;
        }

        public async Task<IEnumerable<EmployeeSchedule>> GetEmployeeScheduleByAfterTime(Guid garageId, Guid employeeId, DateTimeOffset createdAt, bool trackChanges)
        {
            var employeeSchedules = await FindByCondition(es =>
                    es.CreatedAt > createdAt && es.EmployeeId.Equals(employeeId) && es.Employee.EmployeeInfo.WorkplaceId.Equals(garageId), trackChanges).ToListAsync();
            return employeeSchedules;
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

        public async Task<IEnumerable<EmployeeSchedule>> GetSubsequentSchedules(Guid employeeId, Guid currentScheduleId, bool trackChanges)
        {
            // Lấy booking hiện tại để biết thời gian EstimatedEndTime của nó
            var currentSchedule = await FindByCondition(es => es.Id.Equals(currentScheduleId), trackChanges)
                                        .FirstOrDefaultAsync();

            if (currentSchedule == null || !currentSchedule.EstimatedEndTime.HasValue)
            {
                // Nếu không tìm thấy hoặc không có EstimatedEndTime, trả về danh sách rỗng
                return Enumerable.Empty<EmployeeSchedule>();
            }

            // Lấy các booking của nhân viên:
            // - Không bao gồm booking hiện tại (currentScheduleId)
            // - Có EstimatedEndTime đã được thiết lập và lớn hơn hoặc bằng EstimatedEndTime của booking hiện tại
            // - Chưa bắt đầu (StartTime == null) => nghĩa là chưa được thực hiện
            var subsequentSchedules = await FindByCondition(es =>
                 es.EmployeeId.Equals(employeeId) &&
                 !es.Id.Equals(currentScheduleId) &&
                 es.EstimatedEndTime.HasValue &&
                 es.EstimatedEndTime.Value >= currentSchedule.EstimatedEndTime.Value &&
                 es.StartTime == null &&
                 es.Status != EmployeeScheduleStatus.Completed &&
                 es.Status != EmployeeScheduleStatus.InProgress
            , trackChanges)
                .Include(s => s.AppointmentDetail)
                .ThenInclude(ad => ad.ServiceHistory)
                .ThenInclude(sh => sh.Service)
            .OrderBy(es => es.EstimatedEndTime)  // Sắp xếp theo EstimatedEndTime tăng dần
            .ToListAsync();

            return subsequentSchedules;
        }

        // Giả sử hàm này sẽ kiểm tra xem có booking nào của nhân viên đang có trạng thái InProgress
        // hoặc thời gian hiện tại nằm trong khoảng [StartTime, EstimatedEndTime] của booking khác hay không.
        public async Task<bool> HasOverlappingInProgressOrActiveSchedule(Guid employeeId, DateTimeOffset currentTime, bool trackChanges)
        {
            var overlappingSchedules = await FindByCondition(es =>
                es.EmployeeId.Equals(employeeId) &&
                (
                    es.Status == EmployeeScheduleStatus.InProgress ||
                    // Kiểm tra nếu currentTime nằm giữa StartTime và EstimatedEndTime
                    (es.StartTime.HasValue && es.EstimatedEndTime.HasValue &&
                     es.StartTime.Value <= currentTime && currentTime <= es.EstimatedEndTime.Value && es.Status != EmployeeScheduleStatus.Completed)
                )
            , trackChanges).ToListAsync();

            return overlappingSchedules.Count != 0;
        }
    }
}
