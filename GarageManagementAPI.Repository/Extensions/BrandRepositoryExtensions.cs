using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Extensions.Utility;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Reflection;

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
            return brand.Where(b => b.BrandName!.ToLower().Contains(name.Trim().ToLower()));
        }

        public static IQueryable<Brand> IsInclude(this IQueryable<Brand> brand, string? fieldsString)
        {
            if (string.IsNullOrWhiteSpace(fieldsString))
                return brand;

            var fields = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);


            foreach (var field in fields)
            {
                var property = User.PropertyInfos
                    .FirstOrDefault(pi => pi.Name.Equals(field.Trim(), StringComparison.InvariantCultureIgnoreCase));

                if (property != null && IsNavigationProperty(property))
                {
                    brand = brand.Include(field.Trim());
                }
            }

            return brand;
        }

        private static bool IsNavigationProperty(PropertyInfo property)
        {
            return (property.PropertyType.IsGenericType && typeof(IEnumerable<>).IsAssignableFrom(property.PropertyType.GetGenericTypeDefinition())) // Kiểm tra nếu là Collection
                   || (property.PropertyType.IsClass && property.PropertyType != typeof(string)); // Kiểm tra nếu là một class ngoại trừ string
        }

        public static IQueryable<Brand> Sort(this IQueryable<Brand> brands, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return brands.OrderBy(p => p.BrandName);  // Sắp xếp mặc định theo BrandName

            // Tạo biểu thức sắp xếp động từ query string
            var orderQuery = QueryBuilder.CreateOrderQuery<Brand>(orderByQueryString, Brand.PropertyInfos);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return brands.OrderBy(p => p.BrandName);  // Nếu không có chuỗi sắp xếp hợp lệ, sắp xếp theo BrandName

            // Áp dụng sắp xếp động với biểu thức đã tạo
            return brands.OrderBy(orderQuery);  
        }
    }
}
