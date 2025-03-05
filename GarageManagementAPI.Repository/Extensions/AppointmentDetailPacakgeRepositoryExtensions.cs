using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Extensions.Utility;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.Linq.Dynamic.Core;

namespace GarageManagementAPI.Repository.Extensions
{
    public static class AppointmentDetailPacakgeRepositoryExtensions
    {
        public static IQueryable<AppointmentDetailPackage> Sort(this IQueryable<AppointmentDetailPackage> appointmentDetailPackages, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return appointmentDetailPackages.OrderBy(e => e.Status);

            var orderQuery = QueryBuilder.CreateOrderQuery<AppointmentDetailPackage>(orderByQueryString, AppointmentDetailPackage.PropertyInfos);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return appointmentDetailPackages.OrderBy(e => e.Status);

            return appointmentDetailPackages.OrderBy(orderQuery);

        }

        public static IQueryable<AppointmentDetailPackage> FilterByStatus(this IQueryable<AppointmentDetailPackage> appointmentDetailPackages, AppointmentDetailPackageStatus? status)
        {
            if (status is null)
            {
                return appointmentDetailPackages;
            }
            return appointmentDetailPackages.Where(e => e.Status == status);
        }

        public static IQueryable<AppointmentDetailPackage> FilterByAppointmentId(this IQueryable<AppointmentDetailPackage> appointmentDetailPackages, Guid? appointmentId)
        {
            if (appointmentId is null)
            {
                return appointmentDetailPackages;
            }
            return appointmentDetailPackages.Where(e => e.AppointmentId.Equals(appointmentId));
        }
    }
}
