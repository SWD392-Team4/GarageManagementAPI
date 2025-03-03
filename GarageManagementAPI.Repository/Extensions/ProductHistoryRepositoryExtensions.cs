using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Repository.Extensions.Utility;


namespace GarageManagementAPI.Repository.Extensions
{
    public static class ProductHistoryRepositoryExtensions
    {
        public static IQueryable<ProductHistory> SearchByPrice(this IQueryable<ProductHistory> product, decimal? price)
        {
            if (price == 0 || price < 0)
            {
                return product;
            }      
            return product.Where(p => p.ProductPrice == price);
        }

        public static IQueryable<ProductHistory> SearchByStatus(this IQueryable<ProductHistory> products, ProductHistoryStatus? status)
        {
            if (status is null) return products;
            return products.Where(p => p.Status == status);
        }

        public static IQueryable<ProductHistory> IsInclude(this IQueryable<ProductHistory> product, string? fieldsString)
        {
            if (string.IsNullOrWhiteSpace(fieldsString))
                return product;

            var fields = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);

            foreach (var field in fields)
            {
                // Tìm thuộc tính trong PropertyInfos của lớp ProductHistory
                var property = ProductHistory.PropertyInfos
                    .FirstOrDefault(pi => pi.Name.Equals(field.Trim(), StringComparison.InvariantCultureIgnoreCase));

                if (property != null)
                {
                        // Bao gồm các tất cả thuộc tính 
                        product = product.Include(field.Trim());
                }
            }
            return product;
        }


        public static IQueryable<ProductHistory> Sort(this IQueryable<ProductHistory> products, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return products.OrderBy(p => p.ProductPrice);  

            var orderQuery = QueryBuilder.CreateOrderQuery<ProductHistory>(orderByQueryString, ProductHistory.PropertyInfos);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return products.OrderBy(p => p.ProductPrice);  

            return products.OrderBy(orderQuery);
        }
    }
}
