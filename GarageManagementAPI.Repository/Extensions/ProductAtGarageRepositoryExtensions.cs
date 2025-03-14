using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Extensions.Utility;


namespace GarageManagementAPI.Repository.Extensions
{
    public static class ProductAtGarageRepositoryExtensions
    {
        public static IQueryable<ProductAtGarage> SearchByQuantityProduct(this IQueryable<ProductAtGarage> productAtGarages, int? minQuantity, int? maxQuantity)
        {
            if(minQuantity == 0  && maxQuantity == null) return productAtGarages;

            return productAtGarages.Where(pag => pag.Quantity >= minQuantity && pag.Quantity >= maxQuantity);
        }

        public static IQueryable<ProductAtGarage> SearchByCreated(this IQueryable<ProductAtGarage> productAtGarages, DateTimeOffset? createdAt)
        {
            if (!createdAt.HasValue) return productAtGarages;
            DateTimeOffset createdAtUtc = createdAt.Value.Date;
            DateTimeOffset endDate = createdAtUtc.AddDays(2).AddTicks(-1);

            return productAtGarages.Where(pat => pat.CreatedAt >= createdAtUtc && pat.CreatedAt <= endDate);
        }

        public static IQueryable<ProductAtGarage> IsInclude(this IQueryable<ProductAtGarage> productAtGarages, string? fieldsString)
        {
            if (string.IsNullOrWhiteSpace(fieldsString)) return productAtGarages;
            var fields = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);
            foreach (var field in fields) {
                var property = ProductAtGarage.PropertyInfos.FirstOrDefault(pi => pi.Name.Equals(field.Trim(), StringComparison.InvariantCultureIgnoreCase));
                if(property != null)
                {
                    productAtGarages.Include(field.Trim());
                }
            }
            return productAtGarages;
        }

        public static IQueryable<ProductAtGarage> Sort(this IQueryable<ProductAtGarage> productAtGarages, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return productAtGarages.OrderBy(p => p.CreatedAt);

            // Tạo biểu thức sắp xếp động từ query string
            var orderQuery = QueryBuilder.CreateOrderQuery<ProductAtGarage>(orderByQueryString, ProductAtGarage.PropertyInfos);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return productAtGarages.OrderBy(p => p.CreatedAt);

            return productAtGarages.OrderBy(orderQuery);
        }
    }
}
