using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Repository.Extensions.Utility;

namespace GarageManagementAPI.Repository.Extensions
{
    public static class GoodsIssuedRepositoryExtensions
    {
        public static IQueryable<GoodsIssued> SearchByTotalCost(this IQueryable<GoodsIssued> goodsIssueds, decimal? minPrice, decimal? maxPrice)
        {
            if (!minPrice.HasValue || !maxPrice.HasValue)
            {
                return goodsIssueds;
            }

            return goodsIssueds.Where(p =>
                    p.TotalCost >= minPrice &&
                    p.TotalCost <= maxPrice
                );
        }

        public static IQueryable<GoodsIssued> SearchByReferenceNumber(this IQueryable<GoodsIssued> goodsIssueds, string? referenceNumber)
        {
            if (string.IsNullOrWhiteSpace(referenceNumber))
            {
                return goodsIssueds;
            }
            return goodsIssueds.Where(b => EF.Functions.Like(b.ReferenceNumber, $"%{referenceNumber}%"));
        }

        public static IQueryable<GoodsIssued> SearchByReInvoiceCode(this IQueryable<GoodsIssued> goodsIssueds, string? invoiceCode)
        {
            if (string.IsNullOrWhiteSpace(invoiceCode))
            {
                return goodsIssueds;
            }
            return goodsIssueds.Where(b => EF.Functions.Like(b.InvoiceCode, $"%{invoiceCode}%"));
        }
        public static IQueryable<GoodsIssued> SearchByStatus(this IQueryable<GoodsIssued> goodsIssueds, GoodsReceivedDetailStatus? status)
        {
            if (status is null)
            {
                return goodsIssueds;
            }

            return goodsIssueds.Where(p => p.Status.ToString().Equals(status.ToString()));
        }

        public static IQueryable<GoodsIssued> SearchByCreateAt(this IQueryable<GoodsIssued> goodsIssueds, DateTimeOffset? createdAt)
        {
            if (!createdAt.HasValue || createdAt.Value == DateTimeOffset.MinValue)
            {
                return goodsIssueds;
            }

            DateTimeOffset startDate = createdAt.Value.Date;
            DateTimeOffset endDate = startDate.AddDays(1).AddTicks(-1);

            // Check for out-of-range values before querying
            if (startDate > DateTimeOffset.MaxValue || endDate > DateTimeOffset.MaxValue)
            {
                throw new ArgumentOutOfRangeException("The specified date range is outside the valid range.");
            }

            return goodsIssueds.Where(b =>
                b.CreatedAt >= startDate &&
                b.CreatedAt <= endDate
            );
        }

        public static IQueryable<GoodsIssued> SearchByUpdateAt(this IQueryable<GoodsIssued> goodsIssueds, DateTimeOffset? createdAt)
        {
            if (!createdAt.HasValue || createdAt.Value == DateTimeOffset.MinValue)
            {
                return goodsIssueds;
            }

            DateTimeOffset startDate = createdAt.Value.Date;
            DateTimeOffset endDate = startDate.AddDays(1).AddTicks(-1);

            // Check for out-of-range values before querying
            if (startDate > DateTimeOffset.MaxValue || endDate > DateTimeOffset.MaxValue)
            {
                throw new ArgumentOutOfRangeException("The specified date range is outside the valid range.");
            }

            return goodsIssueds.Where(b =>
                b.UpdatedAt >= startDate &&
                b.UpdatedAt <= endDate
            );
        }

        public static IQueryable<GoodsIssued> IsInclude(this IQueryable<GoodsIssued> goodsIssueds, string? fieldsString)
        {
            if (string.IsNullOrWhiteSpace(fieldsString))
                return goodsIssueds;

            var fields = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);


            foreach (var field in fields)
            {
                var property = GoodsIssued.PropertyInfos
                    .FirstOrDefault(pi => pi.Name.Equals(field.Trim(), StringComparison.InvariantCultureIgnoreCase));

                if (property != null)
                {
                    goodsIssueds = goodsIssueds.Include(field.Trim());
                }
            }

            return goodsIssueds;
        }

        public static IQueryable<GoodsIssued> Sort(this IQueryable<GoodsIssued> goodsIssueds, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return goodsIssueds.OrderBy(p => p.TotalCost);  

            var orderQuery = QueryBuilder.CreateOrderQuery<GoodsIssued>(orderByQueryString, GoodsReceivedDetail.PropertyInfos);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return goodsIssueds.OrderBy(p => p.TotalCost);  

            return goodsIssueds.OrderBy(orderQuery);
        }

    }
}
