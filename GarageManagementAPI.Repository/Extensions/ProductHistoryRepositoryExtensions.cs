using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Extensions.Utility;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;


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
            if (status is null || status.Equals(ProductHistoryStatus.None))
            {
                return products;
            }

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

                // Nếu thuộc tính hợp lệ, thực hiện Include
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
                return products.OrderBy(p => p.ProductPrice);  // Sắp xếp mặc định theo ProductName

            // Tạo biểu thức sắp xếp động từ query string
            var orderQuery = QueryBuilder.CreateOrderQuery<ProductHistory>(orderByQueryString, ProductHistory.PropertyInfos);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return products.OrderBy(p => p.ProductPrice);  // Nếu không có chuỗi sắp xếp hợp lệ, sắp xếp theo ProductName

            // Áp dụng sắp xếp động với biểu thức đã tạo
            return products.OrderBy(orderQuery);
        }
    }
}
