using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Extensions.Utility;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.Linq.Dynamic.Core;

namespace GarageManagementAPI.Repository.Extensions
{
    public static class AppointmentDetailRepositoryExtensions
    {
        public static IQueryable<AppointmentDetail> Sort(this IQueryable<AppointmentDetail> appointmentDetails, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return appointmentDetails.OrderBy(e => e.Status);

            var orderQuery = QueryBuilder.CreateOrderQuery<AppointmentDetail>(orderByQueryString, AppointmentDetail.PropertyInfos);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return appointmentDetails.OrderBy(e => e.Status);

            return appointmentDetails.OrderBy(orderQuery);

        }

        public static IQueryable<AppointmentDetail> FilterByStatus(this IQueryable<AppointmentDetail> appointmentDetails, AppointmentDetailStatus? status)
        {
            if (status is null)
            {
                return appointmentDetails;
            }
            return appointmentDetails.Where(e => e.Status == status);
        }

        public static IQueryable<AppointmentDetail> FilterByAppointmentId(this IQueryable<AppointmentDetail> appointmentDetails, Guid? appointmentId)
        {
            if (appointmentId is null)
            {
                return appointmentDetails;
            }
            return appointmentDetails.Where(e => e.AppointmentId.Equals(appointmentId));
        }
    }
}
