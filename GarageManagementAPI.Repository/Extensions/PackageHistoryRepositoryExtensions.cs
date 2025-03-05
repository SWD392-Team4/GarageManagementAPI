using System.Linq.Dynamic.Core;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Extensions.Utility;

namespace GarageManagementAPI.Repository.Extensions
{
    public static class PackageHistoryRepositoryExtensions
    {
        public static IQueryable<PackageHistory> Sort(this IQueryable<PackageHistory> packageHistories, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return packageHistories.OrderByDescending(p => p.CreatedAt);
            var orderQuery = QueryBuilder.CreateOrderQuery<PackageHistory>(orderByQueryString, PackageHistory.PropertyInfos);
            if (string.IsNullOrWhiteSpace(orderQuery))
                return packageHistories.OrderByDescending(p => p.CreatedAt);
            return packageHistories.OrderBy(orderQuery);
        }
    }
}
