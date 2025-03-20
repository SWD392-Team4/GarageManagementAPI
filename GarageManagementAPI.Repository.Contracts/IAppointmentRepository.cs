using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.Dashboard;
using GarageManagementAPI.Shared.DataTransferObjects.Service;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IAppointmentRepository : IRepositoryBase<Appointment>
    {
        Task<PagedList<Appointment>> GetAppointmentsAsync(Guid garageId, AppointmentParameters appointmentParameters, bool trackChanges);

        Task<Appointment?> GetAppointmentAsync(Guid garageId, Guid appoitnmentId, bool trackChanges);

        Task<Appointment?> GetAppointmentAsync(Guid garageId, string verifyCode, string customerEmail, string customerPhone, DateTimeOffset estimatedAppointmentTime, bool trackChanges);

        Task<Appointment?> GetAppointmentAsync(Guid appointmentId, bool trackChanges);

        Task<IEnumerable<Appointment>> GetAppointmentAsync(DateTimeOffset estimatedAppointmentTime, bool trackChanges);

        Task CreateAsync(Guid garageId, Appointment appointment);

        Task<IEnumerable<AppointmentStatisticsDto>> GetAppointmentCountByMonth(int year, Guid? garageId, bool trackChanges);


        Task<IEnumerable<CustomerDto>> GetCustomers(int year, Guid? garageId, bool trackChanges);
        Task<PagedList<Appointment>> GetAppointmentsOfEmployeeAsync(Guid garageId, Guid employeeId, AppointmentParameters appointmentParameters, bool trackChanges);
    }
}
