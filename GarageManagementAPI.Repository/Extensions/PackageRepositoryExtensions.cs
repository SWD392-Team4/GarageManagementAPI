using System.Linq.Dynamic.Core;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Extensions.Utility;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.Enums.SystemStatuss;

namespace GarageManagementAPI.Repository.Extensions
{
    public static class PackageRepositoryExtensions
    {
        public static IQueryable<Package> Sort(this IQueryable<Package> packages, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return packages.OrderBy(p => p.PackageName);

            var orderQuery = QueryBuilder.CreateOrderQuery<Package>(orderByQueryString, Package.PropertyInfos);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return packages.OrderBy(p => p.PackageName);

            return packages.OrderBy(orderQuery);
        }

        public static IQueryable<Package> FilterByServiceCategory(this IQueryable<Package> packages, ServiceCategory? serviceCategoryId)
        {
            if (serviceCategoryId is null)
                return packages;

            // More explicit comparison for enum values
            var categoryValue = serviceCategoryId.Value;
            return packages.Where(p => p.ServiceCategory == categoryValue);
        }

        public static IQueryable<Package> FilterByCarCategory(this IQueryable<Package> packages, Guid? carCategoryId)
        {
            if (carCategoryId is null)
                return packages;

            // Use == for clearer intent with Guid comparison
            return packages.Where(p => p.CarCategoryId == carCategoryId.Value);
        }

        public static IQueryable<Package> FilterByPackageName(this IQueryable<Package> packages, string? packageName)
        {
            if (string.IsNullOrWhiteSpace(packageName))
                return packages;

            var lowerCaseSearch = packageName.Trim().ToLower();
            return packages.Where(p => p.PackageName.ToLower().Contains(lowerCaseSearch));
        }

        public static IQueryable<Package> FilterByPackageType(this IQueryable<Package> packages, PackageType? packageType)
        {
            if (packageType is null)
                return packages;

            return packages.Where(p => p.Type.Equals(packageType));
        }

        public static IQueryable<Package> FilterByPackageStatus(this IQueryable<Package> packages, PackageStatus? packageStatus)
        {
            if (packageStatus is null)
                return packages;

            return packages.Where(p => p.Status.Equals(packageStatus));
        }

        public static IQueryable<Package> FilterByValidityPeriod(this IQueryable<Package> packages, int? validityPeriod)
        {
            if (validityPeriod is null)
                return packages;

            return packages.Where(p => p.ValidityPeriod.Equals(validityPeriod));
        }

        public static IQueryable<Package> FilterByTimeUnit(this IQueryable<Package> packages, TimeUnit? timeUnit)
        {
            if (timeUnit is null)
                return packages;

            return packages.Where(p => p.TimeUnit.Equals(timeUnit));
        }

        public static IQueryable<Package> FilterByUsageLimit(this IQueryable<Package> packages, int? usageLimit)
        {
            if (usageLimit is null)
                return packages;

            return packages.Where(p => p.UsageLimit.Equals(usageLimit));
        }

        public static IQueryable<Package> FilterByCreatedAt(this IQueryable<Package> packages, DateTimeOffset? createdAt)
        {
            if (createdAt is null)
                return packages;

            var createdAtDate = createdAt.Value.Date.DayOfYear;
            return packages.Where(p => p.CreatedAt.Date.DayOfYear.Equals(createdAtDate));
        }

        public static IQueryable<Package> FilterByUpdatedAt(this IQueryable<Package> packages, DateTimeOffset? updatedAt)
        {
            if (updatedAt is null)
                return packages;

            var updatedAtDate = updatedAt.Value.Date.DayOfYear;
            return packages.Where(p => p.UpdatedAt.Date.DayOfYear == updatedAtDate);
        }

        public static IQueryable<Package> FilterByPriceRange(this IQueryable<Package> packages, decimal minPrice, decimal maxPrice)
        {
            return packages.Where(p => p.PackagePrice >= minPrice && p.PackagePrice <= maxPrice);
        }

        public static IQueryable<Package> FilterByDescription(this IQueryable<Package> packages, string? description)
        {
            if (string.IsNullOrWhiteSpace(description))
                return packages;

            var lowerCaseSearch = description.Trim().ToLower();
            return packages.Where(p => p.Description.Contains(lowerCaseSearch));
        }

        public static IQueryable<Package> FilterByCarPart(this IQueryable<Package> packages, Guid? carPartId)
        {
            if (carPartId is null)
                return packages;
            return packages.Where(p => p.PackageHistories.Any(ph => ph.Services.Any(s => s.CarPartId.Equals(carPartId))));
        }
    }
}
