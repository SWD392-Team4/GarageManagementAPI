using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Extensions.Utility;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Reflection;


namespace GarageManagementAPI.Repository.Extensions
{
    public static class ProductRepositoryExtensions
    {
        public static IQueryable<Product> SearchByName(this IQueryable<Product> product, string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return product;
            }

            var lowerCaseTerm = name.Trim().ToLower();
            return product.Where(p => p.ProductName!.ToLower().Contains(name.Trim().ToLower()));
        }

        public static IQueryable<Product> SearchByStatus(this IQueryable<Product> products, ProductStatus? status)
        {
            if (status is null || status.Equals(ProductStatus.None))
            {
                return products;
            }

            return products.Where(p => p.Status == status);
        }

        public static IQueryable<Product> IsInclude(this IQueryable<Product> product, string? fieldsString)
        {
            if (string.IsNullOrWhiteSpace(fieldsString))
                return product;

            var fields = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);


            foreach (var field in fields)
            {
                var property = Product.PropertyInfos
                    .FirstOrDefault(pi => pi.Name.Equals(field.Trim(), StringComparison.InvariantCultureIgnoreCase));

                if (property != null)
                {
                    product = product.Include(field.Trim());
                }
            }

            return product;
        }

        public static IQueryable<Product> Sort(this IQueryable<Product> products, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return products.OrderBy(p => p.ProductName);  // Sắp xếp mặc định theo BrandName

            // Tạo biểu thức sắp xếp động từ query string
            var orderQuery = QueryBuilder.CreateOrderQuery<Brand>(orderByQueryString, Brand.PropertyInfos);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return products.OrderBy(p => p.ProductName);  // Nếu không có chuỗi sắp xếp hợp lệ, sắp xếp theo BrandName

            // Áp dụng sắp xếp động với biểu thức đã tạo
            return products.OrderBy(orderQuery);
        }
    }
}
