using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Repository.Extensions.Utility;

namespace GarageManagementAPI.Repository.Extensions
{
    public static class GoodsIssuedDetailrepositoryExtensions
    {
        public static IQueryable<GoodsIssuedDetail> SearchByQuantity(this IQueryable<GoodsIssuedDetail> goodsIssuedDetails, int? minQuantity, int? maxQuantity)
        {
            if (!maxQuantity.HasValue && minQuantity == 0) return goodsIssuedDetails;

            return goodsIssuedDetails.Where(g => g.Quantity > minQuantity && g.Quantity < maxQuantity);
        }
        public static IQueryable<GoodsIssuedDetail> SearchByStatus(this IQueryable<GoodsIssuedDetail> goodsIssuedDetails, GoodsIssuedDetailStatus? goodsIssuedDetailStatus)
        {
            if (goodsIssuedDetailStatus == null) return goodsIssuedDetails;
            return goodsIssuedDetails.Where(g => g.Status.Equals(goodsIssuedDetailStatus));
        }
        public static IQueryable<GoodsIssuedDetail> SearchByCreatedAt(this IQueryable<GoodsIssuedDetail> goodsIssuedDetails, DateTimeOffset? createdAt) {
            if (!createdAt.HasValue || createdAt.Value == DateTimeOffset.MinValue)
            {
                return goodsIssuedDetails;
            }
            DateTimeOffset startDate = createdAt.Value.Date;
            DateTimeOffset endDate = startDate.AddDays(1).AddTicks(-1);

            // Check for out-of-range values before querying
            if (startDate > DateTimeOffset.MaxValue || endDate > DateTimeOffset.MaxValue)
            {
                throw new ArgumentOutOfRangeException("The specified date range is outside the valid range.");
            }

            return goodsIssuedDetails.Where(b =>
                b.CreatedAt >= startDate &&
                b.CreatedAt <= endDate
            );
        }

        public static IQueryable<GoodsIssuedDetail> SearchByUpdatedAt(this IQueryable<GoodsIssuedDetail> goodsIssuedDetails, DateTimeOffset? updateAt)
        {
            if (!updateAt.HasValue || updateAt.Value == DateTimeOffset.MinValue)
            {
                return goodsIssuedDetails;
            }
            DateTimeOffset startDate = updateAt.Value.Date;
            DateTimeOffset endDate = startDate.AddDays(1).AddTicks(-1);

            // Check for out-of-range values before querying
            if (startDate > DateTimeOffset.MaxValue || endDate > DateTimeOffset.MaxValue)
            {
                throw new ArgumentOutOfRangeException("The specified date range is outside the valid range.");
            }

            return goodsIssuedDetails.Where(b =>
                b.UpdatedAt >= startDate &&
                b.UpdatedAt <= endDate
            );
        }

        public static IQueryable<GoodsIssuedDetail> IsInclude(this IQueryable<GoodsIssuedDetail> goodsIssuedDetails, string? fieldsString)
        {
            if (string.IsNullOrWhiteSpace(fieldsString))
                return goodsIssuedDetails;

            var fields = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);


            foreach (var field in fields)
            {
                var property = GoodsIssuedDetail.PropertyInfos
                    .FirstOrDefault(pi => pi.Name.Equals(field.Trim(), StringComparison.InvariantCultureIgnoreCase));

                if (property != null)
                {
                    goodsIssuedDetails = goodsIssuedDetails.Include(field.Trim());
                }
            }

            return goodsIssuedDetails;
        }

        public static IQueryable<GoodsIssuedDetail> Sort(this IQueryable<GoodsIssuedDetail> goodsIssuedDetails, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return goodsIssuedDetails.OrderBy(p => p.Quantity);  

            var orderQuery = QueryBuilder.CreateOrderQuery<GoodsIssuedDetail>(orderByQueryString, GoodsIssuedDetail.PropertyInfos);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return goodsIssuedDetails.OrderBy(p => p.Quantity); 

            return goodsIssuedDetails.OrderBy(orderQuery);
        }
    }
}
