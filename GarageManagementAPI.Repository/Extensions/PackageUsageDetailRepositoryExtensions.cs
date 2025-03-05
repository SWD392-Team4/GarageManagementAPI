using System.Linq.Dynamic.Core;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Extensions.Utility;

namespace GarageManagementAPI.Repository.Extensions
{
    public static class PackageUsageDetailRepositoryExtensions
    {
        public static IQueryable<PackageUsageDetail> Sort(this IQueryable<PackageUsageDetail> packageUsageDetails, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return packageUsageDetails.OrderBy(p => p.PackageUsageId);
            var orderQuery = QueryBuilder.CreateOrderQuery<PackageUsageDetail>(orderByQueryString, PackageUsageDetail.PropertyInfos);
            if (string.IsNullOrWhiteSpace(orderQuery))
                return packageUsageDetails.OrderBy(p => p.PackageUsageId);
            return packageUsageDetails.OrderBy(orderQuery);
        }
    }
}
