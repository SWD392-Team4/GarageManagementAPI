using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Repository.Extensions.Utility;

namespace GarageManagementAPI.Repository.Extensions
{
    public static class SupplierRepositoryExtesions
    {
        public static IQueryable<Supplier> SearchByName(this IQueryable<Supplier> suppliers, string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return suppliers;
            }
            return suppliers.Where(b => EF.Functions.Like(b.Name, $"%{name}%"));
        }

        public static IQueryable<Supplier> SearchByTaxCode(this IQueryable<Supplier> suppliers, string? taxCode)
        {
            if (string.IsNullOrWhiteSpace(taxCode))
            {
                return suppliers;
            }
            return suppliers.Where(b => b.TaxCode == taxCode);
        }

        public static IQueryable<Supplier> SearchByAddress(this IQueryable<Supplier> suppliers, string? address)
        {
            if (string.IsNullOrWhiteSpace(address))
            {
                return suppliers;
            }
            return suppliers.Where(b => EF.Functions.Like(b.Address, $"%{address}%"));
        }

        public static IQueryable<Supplier> SearchByProvince(this IQueryable<Supplier> suppliers, string? province)
        {
            if (string.IsNullOrWhiteSpace(province))
            {
                return suppliers;
            }
            return suppliers.Where(b => EF.Functions.Like(b.Province, $"%{province}%"));
        }

        public static IQueryable<Supplier> SearchByDistrict(this IQueryable<Supplier> suppliers, string? district)
        {
            if (string.IsNullOrWhiteSpace(district))
            {
                return suppliers;
            }
            return suppliers.Where(b => EF.Functions.Like(b.District, $"%{district}%"));
        }
        public static IQueryable<Supplier> SearchByWards(this IQueryable<Supplier> suppliers, string? wards)
        {
            if (string.IsNullOrWhiteSpace(wards))
            {
                return suppliers;
            }
            return suppliers.Where(b => EF.Functions.Like(b.Wards, $"%{wards}%"));
        }

        public static IQueryable<Supplier> SearchByStatus(this IQueryable<Supplier> suppliers, SupplierStatus? status)
        {
            if (status is null) return suppliers;
            return suppliers.Where(b => b.Status.ToString().Equals(status.ToString()));
        }

        public static IQueryable<Supplier> SearchByDate(this IQueryable<Supplier> suppliers, DateTimeOffset? date)
        {
            if (!date.HasValue || date.Value == DateTimeOffset.MinValue)
            {
                return suppliers;
            }

            DateTimeOffset startDate = date.Value.Date;
            DateTimeOffset endDate = startDate.AddDays(1).AddTicks(-1);

            // Check for out-of-range values before querying
            if (startDate > DateTimeOffset.MaxValue || endDate > DateTimeOffset.MaxValue)
            {
                throw new ArgumentOutOfRangeException("The specified date range is outside the valid range.");
            }

            return suppliers.Where(b =>
                b.CreatedAt >= startDate &&
                b.CreatedAt <= endDate
            );
        }

        public static IQueryable<Supplier> IsInclude(this IQueryable<Supplier> suppliers, string? fieldsString)
        {
            if (string.IsNullOrWhiteSpace(fieldsString))
                return suppliers;

            var fields = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);


            foreach (var field in fields)
            {
                var property = Supplier.PropertyInfos
                    .FirstOrDefault(pi => pi.Name.Equals(field.Trim(), StringComparison.InvariantCultureIgnoreCase));

                if (property != null)
                {
                    suppliers = suppliers.Include(field.Trim());
                }
            }

            return suppliers;
        }

        public static IQueryable<Supplier> Sort(this IQueryable<Supplier> suppliers, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return suppliers.OrderBy(p => p.Name);

            var orderQuery = QueryBuilder.CreateOrderQuery<Supplier>(orderByQueryString, Supplier.PropertyInfos);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return suppliers.OrderBy(p => p.Name);

            return suppliers.OrderBy(orderQuery);
        }
    } 
}
