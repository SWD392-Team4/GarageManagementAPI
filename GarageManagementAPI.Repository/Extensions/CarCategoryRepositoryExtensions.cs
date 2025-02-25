using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Extensions.Utility;
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
    }
}
