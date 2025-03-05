using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Extensions.Utility;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.Linq.Dynamic.Core;

namespace GarageManagementAPI.Repository.Extensions
{
    public static class AppointmentReplacementPartRepositoryExtensions
    {
        public static IQueryable<AppointmentReplacementPart> Sort(this IQueryable<AppointmentReplacementPart> appointmentReplacementParts, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return appointmentReplacementParts.OrderBy(e => e.Status);

            var orderQuery = QueryBuilder.CreateOrderQuery<AppointmentReplacementPart>(orderByQueryString, AppointmentReplacementPart.PropertyInfos);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return appointmentReplacementParts.OrderBy(e => e.Status);

            return appointmentReplacementParts.OrderBy(orderQuery);

        }

        public static IQueryable<AppointmentReplacementPart> FilterByStatus(this IQueryable<AppointmentReplacementPart> appointmentReplacementParts, AppointmentReplacementPartStatus? status)
        {
            if (status is null)
            {
                return appointmentReplacementParts;
            }
            return appointmentReplacementParts.Where(e => e.Status == status);
        }

        public static IQueryable<AppointmentReplacementPart> FilterByAppointmentId(this IQueryable<AppointmentReplacementPart> appointmentReplacementParts, Guid? appointmentId)
        {
            if (appointmentId is null)
            {
                return appointmentReplacementParts;
            }
            return appointmentReplacementParts.Where(e => e.AppointmentDetail.AppointmentId.Equals(appointmentId));
        }

        public static IQueryable<AppointmentReplacementPart> FilterByAppointmentDetailId(this IQueryable<AppointmentReplacementPart> appointmentReplacementParts, Guid? appointmentDetailId)
        {
            if (appointmentDetailId is null)
            {
                return appointmentReplacementParts;
            }
            return appointmentReplacementParts.Where(e => e.AppointmentDetailId.Equals(appointmentDetailId));
        }
    }
}
