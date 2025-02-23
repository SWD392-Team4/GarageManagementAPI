using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Extensions.Utility;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace GarageManagementAPI.Repository.Extensions
{
    public static class BrandRepositoryExtensions
    {
        public static IQueryable<Brand> SearchByName(this IQueryable<Brand> brand, string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return brand;
            }

            var lowerCaseTerm = name.Trim().ToLower();
            return brand.Where(b => b.BrandName!.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        public static IQueryable<Brand> SearchByStatus(this IQueryable<Brand> brand, BrandStatus? status)
        {
            if (status is null) return brand;
            return brand.Where(b => b.Status.ToString().Equals(status.ToString()));
        }

        public static IQueryable<Brand> SearchByDate(this IQueryable<Brand> brand, DateTimeOffset? date)
        {
            if (!date.HasValue || date.Value == DateTimeOffset.MinValue)
            {
                return brand;  
            }

            DateTimeOffset startDate = date.Value.Date;
            DateTimeOffset endDate = startDate.AddDays(1).AddTicks(-1); 

            // Check for out-of-range values before querying
            if (startDate > DateTimeOffset.MaxValue || endDate > DateTimeOffset.MaxValue)
            {
                throw new ArgumentOutOfRangeException("The specified date range is outside the valid range.");
            }

            return brand.Where(b =>
                b.CreatedAt >= startDate &&
                b.CreatedAt <= endDate
            );
        }

        public static IQueryable<Brand> IsInclude(this IQueryable<Brand> brand, string? fieldsString)
        {
            if (string.IsNullOrWhiteSpace(fieldsString))
                return brand;

            var fields = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);


            foreach (var field in fields)
            {
                var property = Brand.PropertyInfos
                    .FirstOrDefault(pi => pi.Name.Equals(field.Trim(), StringComparison.InvariantCultureIgnoreCase));

                if (property != null)
                {
                    brand = brand.Include(field.Trim());
                }
            }

            return brand;
        }

        public static IQueryable<Brand> Sort(this IQueryable<Brand> brands, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return brands.OrderBy(p => p.BrandName); 

            // Tạo biểu thức sắp xếp động từ query string
            var orderQuery = QueryBuilder.CreateOrderQuery<Brand>(orderByQueryString, Brand.PropertyInfos);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return brands.OrderBy(p => p.BrandName); 

            return brands.OrderBy(orderQuery);
        }
    }
}
