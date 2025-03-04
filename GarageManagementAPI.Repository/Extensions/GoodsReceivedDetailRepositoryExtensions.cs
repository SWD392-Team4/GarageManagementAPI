using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Repository.Extensions.Utility;

namespace GarageManagementAPI.Repository.Extensions
{
    public static class GoodsReceivedDetailRepositoryExtensions
    {
        public static IQueryable<GoodsReceivedDetail> SearchByQuantity(this IQueryable<GoodsReceivedDetail> goodsReceivedDetails, int? minQuantity, int? maxQuantity)
        {
            if (!minQuantity.HasValue || !maxQuantity.HasValue)
            {
                return goodsReceivedDetails;
            }

            return goodsReceivedDetails.Where(p =>
                    p.Quantity >= minQuantity &&
                    p.Quantity <= maxQuantity
                );
        }
        public static IQueryable<GoodsReceivedDetail> SearchByUnitPrice(this IQueryable<GoodsReceivedDetail> goodsReceivedDetails, decimal? minPrice, decimal? maxPrice)
        {
            if (!minPrice.HasValue || !maxPrice.HasValue)
            {
                return goodsReceivedDetails;
            }

            return goodsReceivedDetails.Where(p =>
                    p.UnitPrice >= minPrice &&
                    p.UnitPrice <= maxPrice
                );
        }
        public static IQueryable<GoodsReceivedDetail> SearchByTotalPrice(this IQueryable<GoodsReceivedDetail> goodsReceivedDetails, decimal? minPrice, decimal? maxPrice)
        {
            if (!minPrice.HasValue || !maxPrice.HasValue)
            {
                return goodsReceivedDetails;
            }

            return goodsReceivedDetails.Where(p =>
                    p.TotalPrice >= minPrice &&
                    p.TotalPrice <= maxPrice
                );
        }

        public static IQueryable<GoodsReceivedDetail> SearchByStatus(this IQueryable<GoodsReceivedDetail> goodsReceivedDetails, GoodsReceivedDetailStatus? status)
        {
            if (status is null)
            {
                return goodsReceivedDetails;
            }

            return goodsReceivedDetails.Where(p => p.Status.ToString().Equals(status.ToString()));
        }

        public static IQueryable<GoodsReceivedDetail> SearchByDate(this IQueryable<GoodsReceivedDetail> goodsReceivedDetails, DateTimeOffset? createdAt)
        {
            if (!createdAt.HasValue || createdAt.Value == DateTimeOffset.MinValue)
            {
                return goodsReceivedDetails;  
            }

            DateTimeOffset startDate = createdAt.Value.Date;
            DateTimeOffset endDate = startDate.AddDays(1).AddTicks(-1);

            // Check for out-of-range values before querying
            if (startDate > DateTimeOffset.MaxValue || endDate > DateTimeOffset.MaxValue)
            {
                throw new ArgumentOutOfRangeException("The specified date range is outside the valid range.");
            }

            return goodsReceivedDetails.Where(b =>
                b.CreatedAt >= startDate &&
                b.CreatedAt <= endDate
            );
        }

        public static IQueryable<GoodsReceivedDetail> IsInclude(this IQueryable<GoodsReceivedDetail> goodsReceivedDetails, string? fieldsString)
        {
            if (string.IsNullOrWhiteSpace(fieldsString))
                return goodsReceivedDetails;

            var fields = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);


            foreach (var field in fields)
            {
                var property = GoodsReceivedDetail.PropertyInfos
                    .FirstOrDefault(pi => pi.Name.Equals(field.Trim(), StringComparison.InvariantCultureIgnoreCase));

                if (property != null)
                {
                    goodsReceivedDetails = goodsReceivedDetails.Include(field.Trim());
                }
            }

            return goodsReceivedDetails;
        }

        public static IQueryable<GoodsReceivedDetail> Sort(this IQueryable<GoodsReceivedDetail> GoodsReceivedDetails, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return GoodsReceivedDetails.OrderBy(p => p.TotalPrice);  // Sắp xếp mặc định theo GoodsReceivedDetailName

            // Tạo biểu thức sắp xếp động từ query string
            var orderQuery = QueryBuilder.CreateOrderQuery<GoodsReceivedDetail>(orderByQueryString, GoodsReceivedDetail.PropertyInfos);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return GoodsReceivedDetails.OrderBy(p => p.TotalPrice);  // Nếu không có chuỗi sắp xếp hợp lệ, sắp xếp theo GoodsReceivedDetailName

            return GoodsReceivedDetails.OrderBy(orderQuery);
        }
    }
}
