using System.Linq.Dynamic.Core;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Extensions.Utility;

namespace GarageManagementAPI.Repository.Extensions
{
    public static class PackageFeedBackRepositoryExtensions
    {
        public static IQueryable<PackageFeedBack> Sort(this IQueryable<PackageFeedBack> packageFeedBacks, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return packageFeedBacks.OrderBy(p => p.CreatedAt);
            var orderQuery = QueryBuilder.CreateOrderQuery<PackageFeedBack>(orderByQueryString, PackageFeedBack.PropertyInfos);
            if (string.IsNullOrWhiteSpace(orderQuery))
                return packageFeedBacks.OrderBy(p => p.CreatedAt);
            return packageFeedBacks.OrderBy(orderQuery);
        }
    }
}
