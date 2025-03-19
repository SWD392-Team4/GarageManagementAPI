using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Extensions.Utility;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace GarageManagementAPI.Repository.Extensions
{
    public static class EmployeeScheduleRepositoryExtensions
    {
        public static IQueryable<EmployeeSchedule> FilterByAppointmentId(this IQueryable<EmployeeSchedule> employeeSchedules, Guid? appointmentId)
        {
            if (appointmentId == null || appointmentId == Guid.Empty)
                return employeeSchedules;

            return employeeSchedules.Where(es => es.AppointmentDetail.AppointmentId.Equals(appointmentId));
        }

        public static IQueryable<EmployeeSchedule> FilterByEmployeeId(this IQueryable<EmployeeSchedule> employeeSchedules, Guid? employeeId)
        {
            if (employeeId == null || employeeId == Guid.Empty)
                return employeeSchedules;
            return employeeSchedules.Where(es => es.EmployeeId.Equals(employeeId));
        }

        public static IQueryable<EmployeeSchedule> FilterByStatus(this IQueryable<EmployeeSchedule> employeeSchedules, EmployeeScheduleStatus? status)
        {
            if (status == null)
                return employeeSchedules;
            return employeeSchedules.Where(es => es.Status.Equals(status));
        }

        public static IQueryable<EmployeeSchedule> FilterByStartTime(this IQueryable<EmployeeSchedule> employeeSchedules, DateTimeOffset? startTime
            )
        {
            if (startTime == null)
                return employeeSchedules;
            return employeeSchedules.Where(es => es.StartTime.HasValue &&
                                                 es.StartTime.Value.Year == startTime.Value.Year &&
                                                 es.StartTime.Value.Month == startTime.Value.Month &&
                                                 es.StartTime.Value.Day == startTime.Value.Day);
        }

        public static IQueryable<EmployeeSchedule> FilterByEstimatedEndTime(this IQueryable<EmployeeSchedule> employeeSchedules, DateTimeOffset? estimatedEndTime)
        {
            if (estimatedEndTime == null)
                return employeeSchedules;
            return employeeSchedules.Where(es => es.EstimatedEndTime.HasValue &&
                                                 es.EstimatedEndTime.Value.Year == estimatedEndTime.Value.Year &&
                                                 es.EstimatedEndTime.Value.Month == estimatedEndTime.Value.Month &&
                                                 es.EstimatedEndTime.Value.Day == estimatedEndTime.Value.Day);
        }

        public static IQueryable<EmployeeSchedule> FilterByActualEndTime(this IQueryable<EmployeeSchedule> employeeSchedules, DateTimeOffset? actualEndTime)
        {
            if (actualEndTime == null)
                return employeeSchedules;
            return employeeSchedules.Where(es => es.ActualEndTime.HasValue &&
                                                 es.ActualEndTime.Value.Year == actualEndTime.Value.Year &&
                                                 es.ActualEndTime.Value.Month == actualEndTime.Value.Month &&
                                                 es.ActualEndTime.Value.Day == actualEndTime.Value.Day);
        }

        public static IQueryable<EmployeeSchedule> FilterByCreatedAt(this IQueryable<EmployeeSchedule> employeeSchedules, DateTimeOffset? createdAt)
        {
            if (createdAt == null)
                return employeeSchedules;
            return employeeSchedules.Where(es => es.CreatedAt.Year == createdAt.Value.Year &&
                                                 es.CreatedAt.Month == createdAt.Value.Month &&
                                                 es.CreatedAt.Day == createdAt.Value.Day);
        }

        public static IQueryable<EmployeeSchedule> FilterByUpdatedAt(this IQueryable<EmployeeSchedule> employeeSchedules, DateTimeOffset? updatedAt)
        {
            if (updatedAt == null)
                return employeeSchedules;
            return employeeSchedules.Where(es => es.UpdatedAt.Year == updatedAt.Value.Year &&
                                                 es.UpdatedAt.Month == updatedAt.Value.Month &&
                                                 es.UpdatedAt.Day == updatedAt.Value.Day);
        }


        public static IQueryable<EmployeeSchedule> Sort(this IQueryable<EmployeeSchedule> employeeSchedules, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return employeeSchedules.OrderBy(e => e.CreatedAt);

            var orderQuery = QueryBuilder.CreateOrderQuery<EmployeeSchedule>(orderByQueryString, EmployeeSchedule.PropertyInfos);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return employeeSchedules.OrderBy(e => e.CreatedAt);

            return employeeSchedules.OrderBy(orderQuery);

        }

        public static IQueryable<EmployeeSchedule> IsInclude(this IQueryable<EmployeeSchedule> employeeSchedules, string? fieldsString)
        {
            if (string.IsNullOrWhiteSpace(fieldsString))
                return employeeSchedules;

            var fields = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);


            foreach (var field in fields)
            {
                var property = EmployeeSchedule.PropertyInfos
                    .FirstOrDefault(pi => pi.Name.Equals(field.Trim(), StringComparison.InvariantCultureIgnoreCase));

                if (property != null)
                {
                    employeeSchedules = employeeSchedules.Include(field.Trim());
                }
            }

            return employeeSchedules;
        }
    }
}
