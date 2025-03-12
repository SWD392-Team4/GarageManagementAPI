using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Repository.Extensions.Utility;

namespace GarageManagementAPI.Repository.Extensions
{
    public static class ServiceHistoryRepositoryExtensions
    {
        public static IQueryable<ServiceHistory> SearchByPrice(this IQueryable<ServiceHistory> services, decimal? price)
        {
            if (price is null || price == 0 || price < 0)
            {
                return services;
            }
            return services.Where(s => s.Price == price);
        }

        public static IQueryable<ServiceHistory> IsInclude(this IQueryable<ServiceHistory> service, string? fieldsString)
        {
            if (string.IsNullOrWhiteSpace(fieldsString))
                return service;

            var fields = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);

            foreach (var field in fields)
            {
                // Tìm thuộc tính trong PropertyInfos của lớp ServiceHistory
                var property = ServiceHistory.PropertyInfos
                    .FirstOrDefault(pi => pi.Name.Equals(field.Trim(), StringComparison.InvariantCultureIgnoreCase));

                if (property != null)
                {
                    // Bao gồm các tất cả thuộc tính 
                    service = service.Include(field.Trim());
                }
            }
            return service;
        }


        public static IQueryable<ServiceHistory> Sort(this IQueryable<ServiceHistory> products, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return products.OrderBy(p => p.Price);

            var orderQuery = QueryBuilder.CreateOrderQuery<ServiceHistory>(orderByQueryString, ServiceHistory.PropertyInfos);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return products.OrderBy(p => p.Price);

            return products.OrderBy(orderQuery);
        }
    }
}
