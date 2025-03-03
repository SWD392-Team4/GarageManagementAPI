using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Extensions.Utility;
using GarageManagementAPI.Shared.Enums.SystemStatuss;

namespace GarageManagementAPI.Repository.Extensions
{
    public static class ServiceFeebackRepositoryExtensions
    {
        public static IQueryable<ServiceFeedBack> SearchByFeedback(this IQueryable<ServiceFeedBack> serviceFeedBacks, string? feedBack)
        {
            if (string.IsNullOrWhiteSpace(feedBack))
            {
                return serviceFeedBacks;
            }
            return serviceFeedBacks.Where(b => EF.Functions.Like(b.FeedBack, $"%{feedBack}%"));
        }

        public static IQueryable<ServiceFeedBack> SearchByStatus(this IQueryable<ServiceFeedBack> serviceFeedBack, ServiceFeedBackStatus? status)
        {
            if (status is null) return serviceFeedBack;
            return serviceFeedBack.Where(b => b.Status.ToString().Equals(status.ToString()));
        }

        public static IQueryable<ServiceFeedBack> SearchByDate(this IQueryable<ServiceFeedBack> serviceFeedBack, DateTimeOffset? date)
        {
            if (!date.HasValue || date.Value == DateTimeOffset.MinValue)
            {
                return serviceFeedBack;
            }

            DateTimeOffset startDate = date.Value.Date;
            DateTimeOffset endDate = startDate.AddDays(1).AddTicks(-1);

            // Check for out-of-range values before querying
            if (startDate > DateTimeOffset.MaxValue || endDate > DateTimeOffset.MaxValue)
            {
                throw new ArgumentOutOfRangeException("The specified date range is outside the valid range.");
            }

            return serviceFeedBack.Where(b =>
                b.CreatedAt >= startDate &&
                b.CreatedAt <= endDate
            );
        }

        public static IQueryable<ServiceFeedBack> IsInclude(this IQueryable<ServiceFeedBack> serviceFeedBacks, string? fieldsString)
        {
            if (string.IsNullOrWhiteSpace(fieldsString))
                return serviceFeedBacks;

            var fields = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);


            foreach (var field in fields)
            {
                var property = ServiceFeedBack.PropertyInfos
                    .FirstOrDefault(pi => pi.Name.Equals(field.Trim(), StringComparison.InvariantCultureIgnoreCase));

                if (property != null)
                {
                    serviceFeedBacks = serviceFeedBacks.Include(field.Trim());
                }
            }

            return serviceFeedBacks;
        }

        public static IQueryable<ServiceFeedBack> Sort(this IQueryable<ServiceFeedBack> ServiceFeedBacks, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return ServiceFeedBacks.OrderBy(p => p.CreatedAt);

            // Tạo biểu thức sắp xếp động từ query string
            var orderQuery = QueryBuilder.CreateOrderQuery<ServiceFeedBack>(orderByQueryString, ServiceFeedBack.PropertyInfos);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return ServiceFeedBacks.OrderBy(p => p.CreatedAt);

            return ServiceFeedBacks.OrderBy(orderQuery);
        }
    }
}
