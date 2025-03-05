using System.Linq.Dynamic.Core;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Extensions.Utility;

namespace GarageManagementAPI.Repository.Extensions
{
    public static class PackageImageRepositoryExtensions
    {
        public static IQueryable<PackageImage> Sort(this IQueryable<PackageImage> packageImages, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return packageImages.OrderBy(p => p.PackageId);
            var orderQuery = QueryBuilder.CreateOrderQuery<PackageImage>(orderByQueryString, PackageImage.PropertyInfos);
            if (string.IsNullOrWhiteSpace(orderQuery))
                return packageImages.OrderBy(p => p.PackageId);
            return packageImages.OrderBy(orderQuery);
        }
    }
}
