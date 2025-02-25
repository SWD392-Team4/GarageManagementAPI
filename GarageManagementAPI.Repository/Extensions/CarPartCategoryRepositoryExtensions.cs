using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Extensions.Utility;
using GarageManagementAPI.Shared.Enums.SystemStatuss;

namespace GarageManagementAPI.Repository.Extensions
{
    public static class CarPartCategoryRepositoryExtensions
    {
        public static IQueryable<CarPartCategory> SearchByName(this IQueryable<CarPartCategory> carPartCategory, string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return carPartCategory;
            }
            return carPartCategory.Where(c => EF.Functions.Like(c.PartCategory, $"%{name}%"));
        }

        public static IQueryable<CarPartCategory> SearchByStatus(this IQueryable<CarPartCategory> carPartCategory, CarPartCategoryStatus? status)
        {
            if (status is null) return carPartCategory;
            return carPartCategory.Where(b => b.Status.ToString().Equals(status.ToString()));
        }

        public static IQueryable<CarPartCategory> SearchByDate(this IQueryable<CarPartCategory> carPartCategory, DateTimeOffset? date)
        {
            if (!date.HasValue || date.Value == DateTimeOffset.MinValue)
            {
                return carPartCategory;
            }

            DateTimeOffset startDate = date.Value.Date;
            DateTimeOffset endDate = startDate.AddDays(1).AddTicks(-1);

            // Check for out-of-range values before querying
            if (startDate > DateTimeOffset.MaxValue || endDate > DateTimeOffset.MaxValue)
            {
                throw new ArgumentOutOfRangeException("The specified date range is outside the valid range.");
            }

            return carPartCategory.Where(b =>
                b.CreatedAt >= startDate &&
                b.CreatedAt <= endDate
            );
        }

        public static IQueryable<CarPartCategory> IsInclude(this IQueryable<CarPartCategory> carPartCategory, string? fieldsString)
        {
            if (string.IsNullOrWhiteSpace(fieldsString))
                return carPartCategory;

            var fields = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);


            foreach (var field in fields)
            {
                var property = CarPartCategory.PropertyInfos
                    .FirstOrDefault(pi => pi.Name.Equals(field.Trim(), StringComparison.InvariantCultureIgnoreCase));

                if (property != null)
                {
                    carPartCategory = carPartCategory.Include(field.Trim());
                }
            }

            return carPartCategory;
        }

        public static IQueryable<CarPartCategory> Sort(this IQueryable<CarPartCategory> carPartCategories, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return carPartCategories.OrderBy(p => p.PartCategory);

            // Tạo biểu thức sắp xếp động từ query string
            var orderQuery = QueryBuilder.CreateOrderQuery<CarPartCategory>(orderByQueryString, CarPartCategory.PropertyInfos);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return carPartCategories.OrderBy(p => p.PartCategory);

            return carPartCategories.OrderBy(orderQuery);
        }
    }
}
