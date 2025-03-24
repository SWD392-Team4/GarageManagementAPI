using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Extensions.Utility;

namespace GarageManagementAPI.Repository.Extensions
{
    public static class InvoiceRepositoryExtensions
    {

        public static IQueryable<Invoice> SearchByDate(this IQueryable<Invoice> invoices, DateTimeOffset? startDate, DateTimeOffset? endDate)
        {
            if (!startDate.HasValue || startDate == DateTimeOffset.MinValue)
                return invoices;

            if (startDate != DateTimeOffset.MinValue && !endDate.HasValue || endDate == DateTimeOffset.MinValue)
                return invoices.Where(b =>
                b.CreatedAt >= startDate.Value.Date &&
                b.CreatedAt <= startDate.Value.Date.AddDays(1).AddTicks(-1)
            );

            return invoices.Where(b =>
                b.CreatedAt >= startDate.Value.Date &&
                b.CreatedAt <= endDate.Value.Date
            );
        }
        public static IQueryable<Invoice> IsInclude(this IQueryable<Invoice> invoice, string? fieldsString)
        {
            if (string.IsNullOrWhiteSpace(fieldsString))
                return invoice;

            var fields = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);


            foreach (var field in fields)
            {
                var property = Invoice.PropertyInfos
                    .FirstOrDefault(pi => pi.Name.Equals(field.Trim(), StringComparison.InvariantCultureIgnoreCase));

                if (property != null)
                {
                    invoice = invoice.Include(field.Trim());
                }
            }

            return invoice;
        }

        public static IQueryable<Invoice> Sort(this IQueryable<Invoice> invoices, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return invoices.OrderBy(i => i.CreatedAt);

            var orderQuery = QueryBuilder.CreateOrderQuery<Invoice>(orderByQueryString, Invoice.PropertyInfos);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return invoices.OrderBy(p => p.CreatedAt);

            return invoices.OrderBy(orderQuery);
        }
    }
}
