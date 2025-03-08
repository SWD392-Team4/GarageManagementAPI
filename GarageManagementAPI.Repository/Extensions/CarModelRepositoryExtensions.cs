using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Extensions.Utility;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Reflection;

namespace GarageManagementAPI.Repository.Extensions
{
    public static class CarModelRepositoryExtensions
    {
        public static IQueryable<CarModel> Sort(this IQueryable<CarModel> carModels, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return carModels.OrderByDescending(e => e.UpdatedAt);

            var orderQuery = QueryBuilder.CreateOrderQuery<CarModel>(orderByQueryString, CarModel.PropertyInfos);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return carModels.OrderByDescending(e => e.UpdatedAt);

            return carModels.OrderBy(orderQuery);

        }

        public static IQueryable<CarModel> SearchByModelName(this IQueryable<CarModel> carModels, string? modelName)
        {
            if (string.IsNullOrWhiteSpace(modelName))
            {
                return carModels;
            }

            var lowerCaseTerm = modelName.Trim().ToLower();
            return carModels.Where(c => c.ModelName.ToLower().Contains(modelName));
        }

        public static IQueryable<CarModel> SearchByBrandId(this IQueryable<CarModel> carModels, Guid? brandId)
        {
            if (brandId is null || Guid.Empty.Equals(brandId))
            {
                return carModels;
            }

            return carModels.Where(c => c.BrandId.Equals(brandId));
        }

        public static IQueryable<CarModel> SearchByCarCategoryId(this IQueryable<CarModel> carModels, Guid? carCategoryId)
        {
            if (carCategoryId is null || Guid.Empty.Equals(carCategoryId))
            {
                return carModels;
            }

            return carModels.Where(c => c.CarCategoryId.Equals(carCategoryId));
        }

        public static IQueryable<CarModel> SearchByModelYear(this IQueryable<CarModel> carModels, int? modelYear)
        {
            if (modelYear is null)
            {
                return carModels;
            }

            return carModels.Where(c => c.ModelYear.Year.Equals(modelYear));
        }

        public static IQueryable<CarModel> FilterByStatus(this IQueryable<CarModel> carModels, CarModelStatus? status)
        {
            if (status is null)
                return carModels;

            return carModels.Where(c => c.Status.Equals(status));
        }

        public static IQueryable<CarModel> FilterByCreatedAt(this IQueryable<CarModel> carModels, DateTimeOffset? createAt)
        {
            if (createAt is null)
                return carModels;

            var dateOfYear = createAt.Value.DayOfYear;

            return carModels.Where(c => c.CreatedAt.DayOfYear.Equals(dateOfYear));
        }

        public static IQueryable<CarModel> FilterByUpdatedAt(this IQueryable<CarModel> carModels, DateTimeOffset? updatedAt)
        {
            if (updatedAt is null)
                return carModels;

            var dateOfYear = updatedAt.Value.DayOfYear;

            return carModels.Where(c => c.UpdatedAt.DayOfYear.Equals(updatedAt));
        }

        public static IQueryable<CarModel> IsInclude(this IQueryable<CarModel> carModel, string? fieldsString)
        {
            if (string.IsNullOrWhiteSpace(fieldsString))
                return carModel;

            var fields = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);

            foreach (var field in fields)
            {
                var trimmedField = field.Trim();
                var property = CarModel.PropertyInfos
                    .FirstOrDefault(pi => pi.Name.Equals(trimmedField, StringComparison.InvariantCultureIgnoreCase));

                if (property != null && IsLikelyNavigationProperty(property))
                {
                    carModel = carModel.Include(trimmedField);
                }
            }

            return carModel;
        }

        private static bool IsLikelyNavigationProperty(PropertyInfo property)
        {
            var propertyType = property.PropertyType;

            if (propertyType.IsPrimitive || propertyType == typeof(string) ||
                propertyType == typeof(DateTime) || propertyType == typeof(decimal) ||
                propertyType.IsValueType)
            {
                return false;
            }

            if (propertyType.IsClass)
            {
                return true;
            }

            // Check if it's a collection navigation
            if (typeof(IEnumerable<>).IsAssignableFrom(propertyType) &&
                propertyType != typeof(string))
            {
                return true;
            }

            return false;
        }
    }
}
