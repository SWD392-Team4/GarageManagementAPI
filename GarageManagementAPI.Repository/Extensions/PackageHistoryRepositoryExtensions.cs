using System.Linq.Dynamic.Core;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Extensions.Utility;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.Enums;

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

        public static IQueryable<PackageHistory> FilterByServiceCategory(this IQueryable<PackageHistory> packageHistories, ServiceCategory? serviceCategoryId)
        {
            if (serviceCategoryId is null)
                return packageHistories;

            var categoryValue = serviceCategoryId.Value;
            return packageHistories.Where(p => p.ServiceCategory == categoryValue);
        }

        public static IQueryable<PackageHistory> FilterByCarCategory(this IQueryable<PackageHistory> packageHistories, Guid? carCategoryId)
        {
            if (carCategoryId is null)
                return packageHistories;

            return packageHistories.Where(p => p.CarCategoryId == carCategoryId.Value);
        }

        public static IQueryable<PackageHistory> FilterByPackageName(this IQueryable<PackageHistory> packageHistories, string? packageName)
        {
            if (string.IsNullOrWhiteSpace(packageName))
                return packageHistories;

            var lowerCaseSearch = packageName.Trim().ToLower();
            return packageHistories.Where(p => p.PackageName.ToLower().Contains(lowerCaseSearch));
        }

        public static IQueryable<PackageHistory> FilterByPackageType(this IQueryable<PackageHistory> packageHistories, PackageType? packageType)
        {
            if (packageType is null)
                return packageHistories;

            return packageHistories.Where(p => p.Type.Equals(packageType));
        }

        public static IQueryable<PackageHistory> FilterByValidityPeriod(this IQueryable<PackageHistory> packageHistories, int? validityPeriod)
        {
            if (validityPeriod is null)
                return packageHistories;

            return packageHistories.Where(p => p.ValidityPeriod.Equals(validityPeriod));
        }

        public static IQueryable<PackageHistory> FilterByTimeUnit(this IQueryable<PackageHistory> packageHistories, TimeUnit? timeUnit)
        {
            if (timeUnit is null)
                return packageHistories;

            return packageHistories.Where(p => p.TimeUnit.Equals(timeUnit));
        }

        public static IQueryable<PackageHistory> FilterByUsageLimit(this IQueryable<PackageHistory> packageHistories, int? usageLimit)
        {
            if (usageLimit is null)
                return packageHistories;

            return packageHistories.Where(p => p.UsageLimit.Equals(usageLimit));
        }

        public static IQueryable<PackageHistory> FilterByCreatedAt(this IQueryable<PackageHistory> packageHistories, DateTimeOffset? createdAt)
        {
            if (createdAt is null)
                return packageHistories;

            var createdAtDate = createdAt.Value.Date.DayOfYear;
            return packageHistories.Where(p => p.CreatedAt.Date.DayOfYear.Equals(createdAtDate));
        }

        public static IQueryable<PackageHistory> FilterByPriceRange(this IQueryable<PackageHistory> packageHistories, decimal minPrice, decimal maxPrice)
        {
            return packageHistories.Where(p => p.PackagePrice >= minPrice && p.PackagePrice <= maxPrice);
        }

        public static IQueryable<PackageHistory> FilterByDescription(this IQueryable<PackageHistory> packageHistories, string? description)
        {
            if (string.IsNullOrWhiteSpace(description))
                return packageHistories;

            var lowerCaseSearch = description.Trim().ToLower();
            return packageHistories.Where(p => p.Description.Contains(lowerCaseSearch));
        }
    }
}
