using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace GarageManagementAPI.Repository
{
    public class AppointmentRepository : RepositoryBase<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<Appointment?> GetAppointmentAsync(Guid appointmentId, bool trackChanges)
        {
            return await FindByCondition(e => e.Id.Equals(appointmentId), trackChanges).SingleOrDefaultAsync();
        }

        public async Task<Appointment?> GetAppointmentAsync(Guid garageId, Guid appointmentId, bool trackChanges)
        {
            return await FindByCondition(e => e.GarageId.Equals(garageId) && e.Id.Equals(appointmentId), trackChanges).SingleOrDefaultAsync();
        }

        public new async Task CreateAsync(Appointment entity)
        {
            entity.CreatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            entity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            entity.Status = AppointmentStatus.Pending;

            await base.CreateAsync(entity);
        }

        public new void Update(Appointment entity)
        {
            entity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            base.Update(entity);
        }

        public async Task<PagedList<Appointment>> GetAppointmentsAsync(Guid garageId, AppointmentParameters appointmentParameters, bool trackChanges)
        {
            var appointments = await FindByCondition(a => a.GarageId.Equals(garageId), trackChanges)
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

            var count = await FindByCondition(a => a.GarageId.Equals(garageId), trackChanges)
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
