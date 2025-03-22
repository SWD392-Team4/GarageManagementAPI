using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IEmployeeScheduleRepository : IRepositoryBase<EmployeeSchedule>
    {
        Task<IEnumerable<EmployeeSchedule>> GetEmployeeSchedulesByAppointmentDetailAsync(Guid garageId, Guid appointmentId, Guid appointmentDetailId, bool trackChanges);

        Task<EmployeeSchedule?> GetEmployeeScheduleOfAppointmentDetailAsync(Guid garageId, Guid appointmentId, Guid appointmentDetailId, Guid employeeId, bool trackChanges);

        Task<IEnumerable<EmployeeSchedule>> GetOverlappingSchedules(Guid garageId, Guid employeeId, DateTimeOffset now, bool trackChanges);

        Task<IEnumerable<EmployeeSchedule>> GetEmployeeSchedulesOfAppointmentAsync(Guid garageId, Guid appointmentId, bool trackChanges);

        Task<PagedList<EmployeeSchedule>> GetEmployeeSchedulesOfAppointmentAsync(Guid garageId, Guid appointmentId, EmployeeScheduleParameters employeeScheduleParameters, bool trackChanges);

        Task<IEnumerable<EmployeeSchedule>> GetEmployeeSchedulesOfEmployeeAsync(Guid garageId, Guid employeeId, bool trackChanges);

        Task<PagedList<EmployeeSchedule>> GetEmployeeSchedulesOfEmployeeAsync(Guid garageId, Guid employeeId, EmployeeScheduleParameters employeeScheduleParameters, bool trackChanges);
    }
}
