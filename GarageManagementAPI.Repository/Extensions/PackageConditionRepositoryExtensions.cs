using System.Linq.Dynamic.Core;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Extensions.Utility;

namespace GarageManagementAPI.Repository.Extensions
{
    public static class PackageConditionRepositoryExtensions
    {
        public static IQueryable<PackageCondition> Sort(this IQueryable<PackageCondition> packageConditions, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return packageConditions.OrderBy(p => p.ConditionType);

            var orderQuery = QueryBuilder.CreateOrderQuery<PackageCondition>(orderByQueryString, PackageCondition.PropertyInfos);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return packageConditions.OrderBy(p => p.ConditionType);

            return packageConditions.OrderBy(orderQuery);
        }
    }
}
