using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.DataTransferObjects.Dashboard;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.Utilities;
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
            return await FindByCondition(e => e.Id.Equals(appointmentId), trackChanges)
                        .Include(a => a.AppointmentDetails)
                        .ThenInclude(ad => ad.ServiceHistory)
                        .ThenInclude(ad => ad.Service)
                        .Include(a => a.AppointmentDetails)
                        .ThenInclude(a => a.AppointmentReplacementParts)
                        .ThenInclude(a => a.ProductHistory)
                        .ThenInclude(a => a.Product)
                             .Include(a => a.AppointmentDetails)
                             .ThenInclude(ad => ad.CarConditionImages)
                        .Include(a => a.AppointmentDetailPackages)
                        .ThenInclude(a => a.PackageHistory)
                        .Include(a => a.ApproveByEmployee)
                        .Include(a => a.RejecteByEmployee)
                        .Include(a => a.AppointmentDetails)
                        .ThenInclude(a => a.EmployeeSchedules)
                        .ThenInclude(a => a.Employee)
                        .ThenInclude(e => e.Roles)
                        .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentAsync(DateTimeOffset estimatedAppointmentTime, bool trackChanges)
        {
            return await FindByCondition(e => e.EstimatedAppointmentTime.Year == estimatedAppointmentTime.Year &&
                                              e.EstimatedAppointmentTime.Month == estimatedAppointmentTime.Month &&
                                              e.EstimatedAppointmentTime.Day == estimatedAppointmentTime.Day
                                              && e.Status != AppointmentStatus.Cancelled && e.Status != AppointmentStatus.Rejected, trackChanges).ToListAsync();
        }

        public async Task<Appointment?> GetAppointmentAsync(Guid garageId, Guid appointmentId, bool trackChanges)
        {
            return await FindByCondition(e => e.GarageId.Equals(garageId) && e.Id.Equals(appointmentId), trackChanges)
                .Include(a => a.AppointmentDetails)
                .ThenInclude(ad => ad.ServiceHistory)
                .ThenInclude(ad => ad.Service)
                .Include(a => a.AppointmentDetails)
                .ThenInclude(a => a.AppointmentReplacementParts)
                .ThenInclude(a => a.ProductHistory)
                .ThenInclude(a => a.Product)
                .Include(a => a.AppointmentDetailPackages)
                .ThenInclude(a => a.PackageHistory)
                .Include(a => a.ApproveByEmployee)
                .Include(a => a.RejecteByEmployee)
                .Include(a => a.AppointmentDetails)
                .ThenInclude(ad => ad.CarConditionImages)
                .Include(a => a.AppointmentDetails)
                .ThenInclude(a => a.EmployeeSchedules)
                .ThenInclude(a => a.Employee)
                .ThenInclude(e => e.Roles)
                .Include(a => a.AppointmentDetails)
                .ThenInclude(a => a.AppointmentReplacementParts)
                .ThenInclude(a => a.AppointmentReplacementPart_ProductAtGarages)
                .ThenInclude(a => a.ProductAtGarage)
                .SingleOrDefaultAsync();
        }

        public async Task CreateAsync(Guid garageId, Appointment entity)
        {
            entity.GarageId = garageId;
            entity.CreatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            entity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            entity.Status = AppointmentStatus.Pending;
            entity.VerificationCode = CodeGenerator.GenerateRandomCode(6);
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
                .FilterByTime(appointmentParameters.FromTime, appointmentParameters.ToTime)
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
                .Include(a => a.AppointmentDetails)
                .ThenInclude(ad => ad.ServiceHistory)
                .ThenInclude(ad => ad.Service)
                .Include(a => a.AppointmentDetails)
                .ThenInclude(a => a.AppointmentReplacementParts)
                .ThenInclude(a => a.ProductHistory)
                .ThenInclude(a => a.Product)
                .Include(a => a.AppointmentDetailPackages)
                .ThenInclude(a => a.PackageHistory)
                .Include(a => a.ApproveByEmployee)
                .Include(a => a.RejecteByEmployee)
                .Include(a => a.AppointmentDetails)
                .ThenInclude(ad => ad.CarConditionImages)
                .Include(a => a.AppointmentDetails)
                .ThenInclude(a => a.EmployeeSchedules)
                .ThenInclude(a => a.Employee)
                .ThenInclude(e => e.Roles)
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

        public async Task<Appointment?> GetAppointmentAsync(Guid garageId, string verifyCode, string customerEmail, string customerPhone, DateTimeOffset estimatedAppointmentTime, bool trackChanges)
        {
            return await FindByCondition(ap => ap.GarageId.Equals(garageId) &&
                                                ap.VerificationCode!.Equals(verifyCode) &&
                                                ap.CustomerEmail.Equals(customerEmail) &&
                                                ap.CustomerPhoneNumber.Equals(customerPhone) &&
                                                (ap.EstimatedAppointmentTime.Year == estimatedAppointmentTime.Year &&
                                                ap.EstimatedAppointmentTime.Month == estimatedAppointmentTime.Month &&
                                                ap.EstimatedAppointmentTime.Day == estimatedAppointmentTime.Day), trackChanges)
                        .Include(a => a.AppointmentDetails)
                        .ThenInclude(ad => ad.ServiceHistory)
                        .ThenInclude(ad => ad.Service)
                        .Include(a => a.AppointmentDetails)
                        .ThenInclude(a => a.AppointmentReplacementParts)
                        .ThenInclude(a => a.ProductHistory)
                        .ThenInclude(a => a.Product)
                        .Include(a => a.AppointmentDetailPackages)
                        .ThenInclude(a => a.PackageHistory)
                        .Include(a => a.ApproveByEmployee)
                        .Include(a => a.RejecteByEmployee)
                        .Include(a => a.AppointmentDetails)
                        .ThenInclude(ad => ad.CarConditionImages)
                        .Include(a => a.AppointmentDetails)
                        .ThenInclude(a => a.EmployeeSchedules)
                        .ThenInclude(a => a.Employee)
                        .ThenInclude(e => e.Roles)
                        .FirstOrDefaultAsync();
        }


        //Dashboard
        public async Task<IEnumerable<AppointmentStatisticsDto>> GetAppointmentCountByMonth(int year, Guid? garageId, bool trackChanges)
        {
            var result = garageId == null
               ?
                await FindAll(trackChanges)
                .Where(a => a.CreatedAt.Year == year)
                .GroupBy(a => a.CreatedAt.Month)
                .Select(g => new AppointmentStatisticsDto
                {
                    Month = g.Key,
                    TotalAppointments = g.Count()
                })
                .OrderBy(g => g.Month)
                .ToListAsync()
                :
                await FindByCondition(a => a.GarageId.Equals(garageId), trackChanges)
                .Where(a => a.CreatedAt.Year == year)
                 .GroupBy(a => a.CreatedAt.Month)
                .Select(g => new AppointmentStatisticsDto
                {
                    Month = g.Key,
                    TotalAppointments = g.Count()
                })
                .OrderBy(g => g.Month)
                .ToListAsync();
            return result;
        }

        public async Task<IEnumerable<CustomerDto>> GetCustomers(int year, Guid? garageId, bool trackChanges)
        {
            var startOfYear = new DateTime(year, 1, 1);
            var endOfYear = startOfYear.AddYears(1);

            var query = garageId == null
                ? FindAll(trackChanges)
                : FindByCondition(a => a.GarageId.Equals(garageId), trackChanges);

            var customers = query
                .Where(a => a.CreatedAt >= startOfYear && a.CreatedAt < endOfYear)
                .AsEnumerable()
                .GroupBy(a => new { a.CreatedAt.Month, a.CustomerPhoneNumber })
                .Select(g => g.First())
                .GroupBy(a => a.CreatedAt.Month)
                .Select(g => new CustomerDto
                {
                    Month = g.Key,
                    Number = g.Count(),
                })
                .OrderBy(g => g.Month)
                .ToList();

            return customers;
        }

        public async Task<PagedList<Appointment>> GetAppointmentsOfEmployeeAsync(Guid garageId, Guid employeeId, AppointmentParameters appointmentParameters, bool trackChanges)
        {
            var appointments = await FindByCondition(a => a.GarageId.Equals(garageId) && a.AppointmentDetails.Any(ad => ad.EmployeeSchedules.Any(es => es.EmployeeId.Equals(employeeId))), trackChanges)
                .FilterByTime(appointmentParameters.FromTime, appointmentParameters.ToTime)
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
                .Include(a => a.AppointmentDetails)
                .ThenInclude(ad => ad.ServiceHistory)
                .ThenInclude(ad => ad.Service)
                .Include(a => a.AppointmentDetails)
                .ThenInclude(a => a.AppointmentReplacementParts)
                .ThenInclude(a => a.ProductHistory)
                .ThenInclude(a => a.Product)
                .Include(a => a.AppointmentDetailPackages)
                .ThenInclude(a => a.PackageHistory)
                .Include(a => a.ApproveByEmployee)
                .Include(a => a.RejecteByEmployee)
                .Include(a => a.AppointmentDetails)
                .ThenInclude(ad => ad.CarConditionImages)
                .Include(a => a.AppointmentDetails.Where(ad => ad.EmployeeSchedules.Any(es => es.EmployeeId.Equals(employeeId) && es.Status != EmployeeScheduleStatus.Cancelled && es.Status != EmployeeScheduleStatus.Declined)))
                .ThenInclude(a => a.EmployeeSchedules.Where(es => es.EmployeeId.Equals(employeeId) && es.Status != EmployeeScheduleStatus.Cancelled && es.Status != EmployeeScheduleStatus.Declined))
                .ThenInclude(a => a.Employee)
                .ThenInclude(e => e.Roles)
                .ToListAsync();

            var count = await FindByCondition(a => a.GarageId.Equals(garageId) && a.AppointmentDetails.Any(ad => ad.EmployeeSchedules.Any(es => es.EmployeeId.Equals(employeeId))), trackChanges)
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
        public async Task<IEnumerable<PackageIsUsedDto>> GetPakages(int year, Guid? garageId, bool trackChanges)
        {
            var pakages = garageId == null
                                    ? await FindByCondition(a => a.CreatedAt.Year == year, trackChanges)
                                            .Include(a => a.AppointmentDetailPackages)
                                            .GroupBy(a => a.CreatedAt.Month)
                                            .Select(a => new PackageIsUsedDto
                                            {
                                                Month = a.Key,
                                                TotalPackageQuantity = a.Sum(ap => ap.AppointmentDetailPackages.Count)
                                            })
                                            .ToListAsync()
                                    : await FindByCondition(a => a.CreatedAt.Year == year && a.GarageId.Equals(garageId), trackChanges)
                                            .Include(a => a.AppointmentDetailPackages)
                                            .GroupBy(a => a.CreatedAt.Month)
                                            .Select(a => new PackageIsUsedDto
                                            {
                                                Month = a.Key,
                                                TotalPackageQuantity = a.Sum(ap => ap.AppointmentDetailPackages.Count)
                                            })
                                            .ToListAsync();
            return pakages;
        }

        public async Task<IEnumerable<ServiceIsUsedDto>> GetServices(int year, Guid? garageId, bool trackChanges)
        {
            var services = garageId == null
                                    ? await FindByCondition(a => a.CreatedAt.Year == year, trackChanges)
                                            .Include(a => a.AppointmentDetails)
                                            .GroupBy(a => a.CreatedAt.Month)
                                            .Select(a => new ServiceIsUsedDto
                                            {
                                                Month = a.Key,
                                                TotalServiceQuantity = a.Sum(ap => ap.AppointmentDetails.Count)
                                            })
                                            .ToListAsync()
                                    : await FindByCondition(a => a.CreatedAt.Year == year && a.GarageId.Equals(garageId), trackChanges)
                                             .Include(a => a.AppointmentDetails)
                                            .GroupBy(a => a.CreatedAt.Month)
                                            .Select(a => new ServiceIsUsedDto
                                            {
                                                Month = a.Key,
                                                TotalServiceQuantity = a.Sum(ap => ap.AppointmentDetails.Count)
                                            })
                                            .ToListAsync();
            return services;
        }

         
    }
}
