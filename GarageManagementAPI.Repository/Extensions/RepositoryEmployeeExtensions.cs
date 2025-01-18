using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Extensions.Utility;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

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

            var fields = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);

            foreach (var field in fields)
            {
                if (Employee.PropertyInfos.Any(pi =>
                pi.Name
                .Equals(
                    field.Trim(),
                    StringComparison.InvariantCultureIgnoreCase)))
                    employees = employees.Include(field);
            }

            return employees.AsNoTracking();
        }
    }
}
