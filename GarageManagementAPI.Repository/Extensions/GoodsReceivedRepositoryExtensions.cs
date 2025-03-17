using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Repository.Extensions.Utility;


namespace GarageManagementAPI.Repository.Extensions
{
    public static class GoodsReceivedRepositoryExtensions
    {
        public static IQueryable<GoodsReceived> SearchByRefereneceNumber(this IQueryable<GoodsReceived> goodsReceived, string? refereneceNumber)
        {
            if (string.IsNullOrWhiteSpace(refereneceNumber))
            {
                return goodsReceived;
            }
            return goodsReceived.Where(b => EF.Functions.Like(b.RefereneceNumber, $"%{refereneceNumber}%"));
        }

        public static IQueryable<GoodsReceived> SearchByInvoiceCode(this IQueryable<GoodsReceived> goodsReceived, string? invoiceCode)
        {
            if (string.IsNullOrWhiteSpace(invoiceCode))
            {
                return goodsReceived;
            }
            return goodsReceived.Where(b => EF.Functions.Like(b.InvoiceCode, $"%{invoiceCode}%"));
        }

        public static IQueryable<GoodsReceived> SearchBySourceAddress(this IQueryable<GoodsReceived> goodsReceived, string? address)
        {
            if (string.IsNullOrWhiteSpace(address))
            {
                return goodsReceived;
            }
            return goodsReceived.Where(b => EF.Functions.Like(b.SourceAddress, $"%{address}%"));
        }

        public static IQueryable<GoodsReceived> SearchBySourceProvince(this IQueryable<GoodsReceived> goodsReceived, string? province)
        {
            if (string.IsNullOrWhiteSpace(province))
            {
                return goodsReceived;
            }
            return goodsReceived.Where(b => EF.Functions.Like(b.SourceProvince, $"%{province}%"));
        }

        public static IQueryable<GoodsReceived> SearchBySourceDistrict(this IQueryable<GoodsReceived> goodsReceived, string? district)
        {
            if (string.IsNullOrWhiteSpace(district))
            {
                return goodsReceived;
            }
            return goodsReceived.Where(b => EF.Functions.Like(b.SourceDistrict, $"%{district}%"));
        }

        public static IQueryable<GoodsReceived> SearchBySourceWards(this IQueryable<GoodsReceived> goodsReceived, string? wards)
        {
            if (string.IsNullOrWhiteSpace(wards))
            {
                return goodsReceived;
            }
            return goodsReceived.Where(b => EF.Functions.Like(b.SourceWards, $"%{wards}%"));
        }

        public static IQueryable<GoodsReceived> SearchByPrice(this IQueryable<GoodsReceived> goodsReceived, decimal? minPrice, decimal? maxPrice)
        {
            if (!minPrice.HasValue || !maxPrice.HasValue)
            {
                return goodsReceived;
            }

            return goodsReceived.Where(p => p.TotalPrice >= minPrice && p.TotalPrice <= maxPrice);
        }

        public static IQueryable<GoodsReceived> SearchByStatus(this IQueryable<GoodsReceived> goodsReceived, GoodsReceivedStatus? status)
        {
            if (status is null)
            {
                return goodsReceived;
            }

            return goodsReceived.Where(p => p.Status.ToString().Equals(status.ToString()));
        }

        public static IQueryable<GoodsReceived> SearchByDate(this IQueryable<GoodsReceived> goodsReceived, DateTimeOffset? date)
        {
            if (!date.HasValue || date.Value == DateTimeOffset.MinValue)
            {
                return goodsReceived;
            }

            DateTimeOffset startDate = date.Value.Date;
            DateTimeOffset endDate = startDate.AddDays(1).AddTicks(-1);

            // Check for out-of-range values before querying
            if (startDate > DateTimeOffset.MaxValue || endDate > DateTimeOffset.MaxValue)
            {
                throw new ArgumentOutOfRangeException("The specified date range is outside the valid range.");
            }

            return goodsReceived.Where(b =>
                b.CreatedAt >= startDate &&
                b.CreatedAt <= endDate
            );
        }

        public static IQueryable<GoodsReceived> IsInclude(this IQueryable<GoodsReceived> goodsReceived, string? fieldsString)
        {
            if (string.IsNullOrWhiteSpace(fieldsString))
                return goodsReceived;

            var fields = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);

            foreach (var field in fields)
            {
                var property = GoodsReceived.PropertyInfos
                    .FirstOrDefault(pi => pi.Name.Equals(field.Trim(), StringComparison.InvariantCultureIgnoreCase));

                if (property != null)
                {
                    goodsReceived = goodsReceived.Include(field.Trim());
                }
            }
            return goodsReceived;
        }


        public static IQueryable<GoodsReceived> Sort(this IQueryable<GoodsReceived> goodsReceived, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return goodsReceived.OrderBy(p => p.TotalPrice);

            var orderQuery = QueryBuilder.CreateOrderQuery<GoodsReceived>(orderByQueryString, GoodsReceived.PropertyInfos);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return goodsReceived.OrderBy(p => p.TotalPrice);

            return goodsReceived.OrderBy(orderQuery);
        }
    }
}
