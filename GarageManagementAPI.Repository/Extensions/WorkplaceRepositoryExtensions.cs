using Bogus.DataSets;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Extensions.Utility;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Xml.Linq;

namespace GarageManagementAPI.Repository.Extensions
{
    public static class WorkplaceRepositoryExtensions
    {
        public static IQueryable<Workplace> SearchByStatus(this IQueryable<Workplace> workpaces, WorkplaceStatus? status)
        {
            if (status is null || status.Equals(WorkplaceStatus.None))
            {
                return workpaces;
            }

            return workpaces.Where(g => g.Status == status);
        }
        public static IQueryable<Workplace> SearchByType(this IQueryable<Workplace> workpaces, WorkplaceType? type)
        {
            if (type is null || type.Equals(WorkplaceType.None))
            {
                return workpaces;
            }

            return workpaces.Where(g => g.WorkplaceType == type);
        }

        public static IQueryable<Workplace> SearchByName(this IQueryable<Workplace> workpaces, string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return workpaces;
            }

            var lowerCaseTerm = name.Trim().ToLower();
            return workpaces.Where(g => g.Name.ToLower().Contains(name));
        }

        public static IQueryable<Workplace> Sort(this IQueryable<Workplace> workpaces, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return workpaces.OrderBy(e => e.Name);

            var orderQuery = QueryBuilder.CreateOrderQuery<Workplace>(orderByQueryString, Workplace.PropertyInfos);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return workpaces.OrderBy(e => e.Name);

            return workpaces.OrderBy(orderQuery);

        }
    }

    public static class AppointmentRepositoryExtensions
    {
        public static IQueryable<Appointment> Sort(this IQueryable<Appointment> appointments, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return appointments.OrderBy(e => e.CreatedAt);

            var orderQuery = QueryBuilder.CreateOrderQuery<Appointment>(orderByQueryString, Appointment.PropertyInfos);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return appointments.OrderBy(e => e.CreatedAt);

            return appointments.OrderBy(orderQuery);

        }

        public static IQueryable<Appointment> FilterByEmployeeApprovedId(this IQueryable<Appointment> appointments, Guid? employeeId)
        {
            if (employeeId is null)
            {
                return appointments;
            }

            return appointments.Where(g => g.ApproveByEmployeeId.Equals(employeeId));
        }

        public static IQueryable<Appointment> FilterByCustomerName(this IQueryable<Appointment> appointments, string? customerName)
        {
            if (string.IsNullOrWhiteSpace(customerName)) return appointments;

            var lowerCaseTerm = customerName.Trim().ToLower();
            return appointments.Where(g => g.CustomerName.ToLower().Contains(lowerCaseTerm));
        }

        public static IQueryable<Appointment> FilterByCustomerPhoneNumber(this IQueryable<Appointment> appointments, string? customerPhone)
        {
            if (string.IsNullOrWhiteSpace(customerPhone)) return appointments;

            var lowerCaseTerm = customerPhone.Trim().ToLower();
            return appointments.Where(g => g.CustomerPhoneNumber.ToLower().Contains(lowerCaseTerm));
        }

        public static IQueryable<Appointment> FilterByCustomerEmail(this IQueryable<Appointment> appointments, string? customerEmail)
        {
            if (string.IsNullOrWhiteSpace(customerEmail)) return appointments;

            var lowerCaseTerm = customerEmail.Trim().ToLower();
            return appointments.Where(g => g.CustomerEmail.ToLower().Contains(lowerCaseTerm));
        }

        public static IQueryable<Appointment> FilterByCarLicensePlateNumber(this IQueryable<Appointment> appointments, string? carLicensePlateNumber)
        {
            if (string.IsNullOrWhiteSpace(carLicensePlateNumber)) return appointments;

            var lowerCaseTerm = carLicensePlateNumber.Trim().ToLower();
            return appointments.Where(g => g.CarLicensePlateNumber != null && g.CarLicensePlateNumber.ToLower().Contains(carLicensePlateNumber));
        }

        public static IQueryable<Appointment> FilterByType(this IQueryable<Appointment> appointments, AppointmentType? type)
        {
            if (type is null)
            {
                return appointments;
            }

            return appointments.Where(e => e.AppointmentType == type);
        }

        public static IQueryable<Appointment> FilterByStatus(this IQueryable<Appointment> appointments, AppointmentStatus? status)
        {
            if (status is null)
            {
                return appointments;
            }

            return appointments.Where(e => e.Status == status);
        }

    }
}
