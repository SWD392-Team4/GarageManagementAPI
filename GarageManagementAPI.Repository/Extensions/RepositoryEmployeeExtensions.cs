using GarageManagementAPI.Entities.NewModels;
using GarageManagementAPI.Repository.Extensions.Utility;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Reflection;

namespace GarageManagementAPI.Repository.Extensions
{
    public static class RepositoryEmployeeExtensions
    {
        public static IQueryable<Employee> Search(this IQueryable<Employee> employees, string? searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return employees;
            }

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return employees.Where(e => e.Name.ToLower().Contains(searchTerm));
        }

        public static IQueryable<Employee> Sort(this IQueryable<Employee> employees, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return employees.OrderBy(e => e.Name);

            var orderQuery = QueryBuilder.CreateOrderQuery<Employee>(orderByQueryString, Employee.PropertyInfos);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return employees.OrderBy(e => e.Name);

            return employees.OrderBy(orderQuery);

        }

        public static IQueryable<Employee> Includes(this IQueryable<Employee> employees, string? fieldsString)
        {
            if (string.IsNullOrWhiteSpace(fieldsString))
            {
                return employees;
            }

            // Tách các trường từ fieldsString
            var fields = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);

            // Duyệt qua các trường và thêm Include nếu là quan hệ điều hướng hợp lệ
            foreach (var field in fields)
            {
                var property = Employee.PropertyInfos
                    .FirstOrDefault(pi => pi.Name.Equals(field.Trim(), StringComparison.InvariantCultureIgnoreCase));

                if (property != null && IsNavigationProperty(property))
                {
                    employees = employees.Include(field.Trim());
                }
            }

            // Projection kết quả
            return employees;
        }


        // Kiểm tra xem một property có phải là quan hệ điều hướng hay không
        private static bool IsNavigationProperty(PropertyInfo property)
        {
            return typeof(IEnumerable<>).IsAssignableFrom(property.PropertyType)
                   || (property.PropertyType.IsClass && property.PropertyType != typeof(string));
        }
    }
}
