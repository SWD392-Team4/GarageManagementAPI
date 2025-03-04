using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Repository.Extensions.Utility;

namespace GarageManagementAPI.Repository.Extensions
{
    public static class SupplierContactContactRepositoryExtensions
    {
        public static IQueryable<SupplierContact> SearchByName(this IQueryable<SupplierContact> supplierContacts, string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return supplierContacts;
            }
            return supplierContacts.Where(b => EF.Functions.Like(b.ContactPersonName, $"%{name}%"));
        }

        public static IQueryable<SupplierContact> SearchByPosition(this IQueryable<SupplierContact> supplierContacts, string? position)
        {
            if (string.IsNullOrWhiteSpace(position))
            {
                return supplierContacts;
            }
            return supplierContacts.Where(b => EF.Functions.Like(b.ContactPosition, $"%{position}%"));
        }

        public static IQueryable<SupplierContact> SearchByhoneNumber(this IQueryable<SupplierContact> supplierContacts, string? phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                return supplierContacts;
            }
            return supplierContacts.Where(b => EF.Functions.Like(b.ContactPhoneNumber, $"%{phoneNumber}%"));
        }

        public static IQueryable<SupplierContact> SearchByEmail(this IQueryable<SupplierContact> supplierContacts, string? email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return supplierContacts;
            }
            return supplierContacts.Where(b => EF.Functions.Like(b.ContactEmail, $"%{email}%"));
        }

        public static IQueryable<SupplierContact> SearchByStatus(this IQueryable<SupplierContact> supplierContacts, SupplierContactStatus? status)
        {
            if (status is null) return supplierContacts;
            return supplierContacts.Where(b => b.Status.ToString().Equals(status.ToString()));
        }

        public static IQueryable<SupplierContact> SearchByDate(this IQueryable<SupplierContact> supplierContacts, DateTimeOffset? date)
        {
            if (!date.HasValue || date.Value == DateTimeOffset.MinValue)
            {
                return supplierContacts;
            }

            DateTimeOffset startDate = date.Value.Date;
            DateTimeOffset endDate = startDate.AddDays(1).AddTicks(-1);

            if (startDate > DateTimeOffset.MaxValue || endDate > DateTimeOffset.MaxValue)
            {
                throw new ArgumentOutOfRangeException("The specified date range is outside the valid range.");
            }

            return supplierContacts.Where(b =>
                b.CreatedAt >= startDate &&
                b.CreatedAt <= endDate
            );
        }

        public static IQueryable<SupplierContact> IsInclude(this IQueryable<SupplierContact> supplierContacts, string? fieldsString)
        {
            if (string.IsNullOrWhiteSpace(fieldsString))
                return supplierContacts;

            var fields = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);


            foreach (var field in fields)
            {
                var property = SupplierContact.PropertyInfos
                    .FirstOrDefault(pi => pi.Name.Equals(field.Trim(), StringComparison.InvariantCultureIgnoreCase));

                if (property != null)
                {
                    supplierContacts = supplierContacts.Include(field.Trim());
                }
            }

            return supplierContacts;
        }

        public static IQueryable<SupplierContact> Sort(this IQueryable<SupplierContact> supplierContacts, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return supplierContacts.OrderBy(p => p.ContactPersonName);

            var orderQuery = QueryBuilder.CreateOrderQuery<SupplierContact>(orderByQueryString, SupplierContact.PropertyInfos);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return supplierContacts.OrderBy(p => p.ContactPersonName);

            return supplierContacts.OrderBy(orderQuery);
        }
    }
}
