using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Extensions.Utility;
using System.Linq.Dynamic.Core;

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
    }
}
