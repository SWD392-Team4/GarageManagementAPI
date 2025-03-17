using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Extensions.Utility;

namespace GarageManagementAPI.Repository.Extensions
{
    public static class InvoiceRepositoryExtensions
    {
        public static IQueryable<Invoice> IsInclude(this IQueryable<Invoice> invoices, string? fieldsString)
        {
            if (string.IsNullOrWhiteSpace(fieldsString)) return invoices;
            var fields = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);
            foreach (var field in fields)
            {
                var property = InvoiceSellProduct.PropertyInfos.FirstOrDefault(i => i.Name.Equals(field));
                if (field != null)
                    invoices.Include(field);
            }
            return invoices;
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
