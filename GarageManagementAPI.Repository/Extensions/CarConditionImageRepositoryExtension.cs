using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Extensions.Utility;
using GarageManagementAPI.Shared.Enums;
using System.Linq.Dynamic.Core;

namespace GarageManagementAPI.Repository.Extensions
{
    public static class CarConditionImageRepositoryExtension
    {
        public static IQueryable<CarConditionImage> Sort(this IQueryable<CarConditionImage> carConditionImages, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return carConditionImages.OrderBy(p => p.AppointmentDetailId);
            var orderQuery = QueryBuilder.CreateOrderQuery<CarConditionImage>(orderByQueryString, CarConditionImage.PropertyInfos);
            if (string.IsNullOrWhiteSpace(orderQuery))
                return carConditionImages.OrderBy(p => p.AppointmentDetailId);
            return carConditionImages.OrderBy(orderQuery);
        }

        public static IQueryable<CarConditionImage> FilterByStage(this IQueryable<CarConditionImage> carConditionImages, ConditionStage? conditionStage)
        {
            if (conditionStage is null)
                return carConditionImages;

            return carConditionImages.Where(c => c.ConditionStage.Equals(conditionStage));
        }
    }
}
