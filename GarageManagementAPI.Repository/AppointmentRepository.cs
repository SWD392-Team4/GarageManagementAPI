using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace GarageManagementAPI.Repository
{
    public class AppointmentRepository : RepositoryBase<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<Appointment?> GetAppointmentAsync(Guid id, bool trackChanges)
        {
            return await FindByCondition(e => e.Id.Equals(id), trackChanges).SingleOrDefaultAsync();
        }

        public async Task<PagedList<Appointment>> GetAppointmentsAsync(AppointmentParameters appointmentParameters, bool trackChanges)
        {
            var appointments = await FindAll(trackChanges)
                .FilterByEmployeeApprovedId(appointmentParameters.Employee)
                .FilterByCustomerName(appointmentParameters.CustomerName)
                .FilterByCustomerEmail(appointmentParameters.CustomerEmail)
                .FilterByCustomerPhoneNumber(appointmentParameters.CustomerPhoneNumber)
                .FilterByCarLicensePlateNumber(appointmentParameters.CarLicensePlateNumber)
                .FilterByType(appointmentParameters.AppointmentType)
                .FilterByStatus(appointmentParameters.AppointmentStatus)
                .Sort(appointmentParameters.OrderBy)
                .Skip((appointmentParameters.PageNumber - 1) * appointmentParameters.PageSize)
                .Take(appointmentParameters.PageSize)
                .ToListAsync();

            var count = await FindAll(trackChanges)
                 .FilterByEmployeeApprovedId(appointmentParameters.Employee)
                .FilterByCustomerName(appointmentParameters.CustomerName)
                .FilterByCustomerEmail(appointmentParameters.CustomerEmail)
                .FilterByCustomerPhoneNumber(appointmentParameters.CustomerPhoneNumber)
                .FilterByCarLicensePlateNumber(appointmentParameters.CarLicensePlateNumber)
                .FilterByType(appointmentParameters.AppointmentType)
                .FilterByStatus(appointmentParameters.AppointmentStatus)
                .CountAsync();


            return new PagedList<Appointment>(
                appointments,
                count,
                appointmentParameters.PageNumber,
                appointmentParameters.PageSize);
        }
    }
}
