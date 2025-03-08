using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Extensions.Utility;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.Linq.Dynamic.Core;

namespace GarageManagementAPI.Repository.Extensions
{
    public static class CarCategoryRepositoryExtensions
    {
        public static IQueryable<CarCategory> Sort(this IQueryable<CarCategory> carCategories, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return carCategories.OrderByDescending(e => e.UpdatedAt);

            var orderQuery = QueryBuilder.CreateOrderQuery<CarCategory>(orderByQueryString, CarCategory.PropertyInfos);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return carCategories.OrderByDescending(e => e.UpdatedAt);

            return carCategories.OrderBy(orderQuery);

        }

        public static IQueryable<CarCategory> FilterByCategory(this IQueryable<CarCategory> carCategories, string? category)
        {
            if (string.IsNullOrWhiteSpace(category))
                return carCategories;
            return carCategories.Where(e => e.Category.ToLower().Contains(category.Trim().ToLower()));
        }

        public static IQueryable<CarCategory> FilterByDescription(this IQueryable<CarCategory> carCategories, string? description)
        {
            if (string.IsNullOrWhiteSpace(description))
                return carCategories;
            return carCategories.Where(e => e.Description.ToLower().Contains(description.Trim().ToLower()));
        }

        public static IQueryable<CarCategory> FilterByStatus(this IQueryable<CarCategory> carCategories, CarCategoryStatus? status)
        {
            if (status == null)
                return carCategories;
            return carCategories.Where(e => e.Status.Equals(status));
        }

        public static IQueryable<CarCategory> FilterByCreatedAt(this IQueryable<CarCategory> carCategories, DateTimeOffset? createdAt)
        {
            if (createdAt == null)
                return carCategories;

            var date = createdAt.Value.Date.DayOfYear;
            return carCategories.Where(e => e.CreatedAt.Date.DayOfYear.Equals(date));
        }

        public static IQueryable<CarCategory> FilterByUpdatedAt(this IQueryable<CarCategory> carCategories, DateTimeOffset? updatedAt)
        {
            if (updatedAt == null)
                return carCategories;
            var date = updatedAt.Value.Date.DayOfYear;
            return carCategories.Where(e => e.UpdatedAt.Date.DayOfYear.Equals(date));
        }
    }
}
