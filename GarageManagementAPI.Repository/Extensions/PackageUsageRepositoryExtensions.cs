using System.Linq.Dynamic.Core;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Extensions.Utility;

namespace GarageManagementAPI.Repository.Extensions
{
    public static class PackageUsageRepositoryExtensions
    {
        public static IQueryable<PackageUsage> Sort(this IQueryable<PackageUsage> packageUsages, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return packageUsages.OrderBy(p => p.CreatedAt);
            var orderQuery = QueryBuilder.CreateOrderQuery<PackageUsage>(orderByQueryString, PackageUsage.PropertyInfos);
            if (string.IsNullOrWhiteSpace(orderQuery))
                return packageUsages.OrderBy(p => p.CreatedAt);
            return packageUsages.OrderBy(orderQuery);
        }
    }
}
