using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Extensions.Utility;

namespace GarageManagementAPI.Repository.Extensions
{
    public static class PackageRepositoryExtensions
    {
        public static IQueryable<Package> IsInclude(this IQueryable<Package> package, string? fieldsString)
        {
            if (string.IsNullOrWhiteSpace(fieldsString))
                return package;

            var fields = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);


            foreach (var field in fields)
            {
                var property = Package.PropertyInfos
                    .FirstOrDefault(pi => pi.Name.Equals(field.Trim(), StringComparison.InvariantCultureIgnoreCase));

                if (property != null)
                {
                    package = package.Include(field.Trim());
                }
            }

            return package;
        }

        public static IQueryable<Package> Sort(this IQueryable<Package> packages, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return packages.OrderBy(p => p.PackageName);

            var orderQuery = QueryBuilder.CreateOrderQuery<Package>(orderByQueryString, Package.PropertyInfos);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return packages.OrderBy(p => p.PackageName);

            return packages.OrderBy(orderQuery);
        }
    }
}
