using System.Linq.Dynamic.Core;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Extensions.Utility;
using GarageManagementAPI.Shared.Enums;

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

        public static IQueryable<PackageCondition> FilterByConditionValue(this IQueryable<PackageCondition> packageConditions, uint minConditionValue, uint maxConditionValue)
            => packageConditions.Where(p => (p.ConditionValue >= minConditionValue && p.ConditionValue <= maxConditionValue));

        public static IQueryable<PackageCondition> FilterByPackageConditionType(this IQueryable<PackageCondition> packageConditions, PackageConditionType? type)
        {
            if (type is null)
                return packageConditions;

            return packageConditions.Where(e => e.ConditionType.Equals(type));
        }
    }
}
