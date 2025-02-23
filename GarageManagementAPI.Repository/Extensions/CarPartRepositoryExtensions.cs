using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Extensions.Utility;
using GarageManagementAPI.Shared.Enums.SystemStatuss;

namespace GarageManagementAPI.Repository.Extensions
{
    public static class CarPartRepositoryExtensions
    {
        public static IQueryable<CarPart> SearchByName(this IQueryable<CarPart> carPart, string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return carPart;
            }
            return carPart.Where(b => b.PartName!.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        public static IQueryable<CarPart> SearchByStatus(this IQueryable<CarPart> carParts, CarPartStatus? status)
        {
            if (status is null) return carParts;
            return carParts.Where(b => b.Status.ToString().Equals(status.ToString()));
        }

        public static IQueryable<CarPart> SearchByDate(this IQueryable<CarPart> carPart, DateTimeOffset? date)
        {
            if (!date.HasValue || date.Value == DateTimeOffset.MinValue)
            {
                return carPart; 
            }

            DateTimeOffset startDate = date.Value.Date;
            DateTimeOffset endDate = startDate.AddDays(1).AddTicks(-1); 

            // Check for out-of-range values before querying
            if (startDate > DateTimeOffset.MaxValue || endDate > DateTimeOffset.MaxValue)
            {
                throw new ArgumentOutOfRangeException("The specified date range is outside the valid range.");
            }

            return carPart.Where(b =>
                b.CreatedAt >= startDate &&
                b.CreatedAt <= endDate
            );
        }

        public static IQueryable<CarPart> IsInclude(this IQueryable<CarPart> carPart, string? fieldsString)
        {
            if (string.IsNullOrWhiteSpace(fieldsString))
                return carPart;

            var fields = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);


            foreach (var field in fields)
            {
                var property = CarPart.PropertyInfos
                    .FirstOrDefault(pi => pi.Name.Equals(field.Trim(), StringComparison.InvariantCultureIgnoreCase));

                if (property != null)
                {
                    carPart = carPart.Include(field.Trim());
                }
            }

            return carPart;
        }

        public static IQueryable<CarPart> Sort(this IQueryable<CarPart> CarParts, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return CarParts.OrderBy(p => p.PartName);

            // Tạo biểu thức sắp xếp động từ query string
            var orderQuery = QueryBuilder.CreateOrderQuery<CarPart>(orderByQueryString, CarPart.PropertyInfos);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return CarParts.OrderBy(p => p.PartName);

            return CarParts.OrderBy(orderQuery);
        }
    }
}
