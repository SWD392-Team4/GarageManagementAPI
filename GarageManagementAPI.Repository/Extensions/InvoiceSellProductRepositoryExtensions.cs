using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Extensions.Utility;

namespace GarageManagementAPI.Repository.Extensions
{
    public static class InvoiceSellProductRepositoryExtensions
    {
        public static IQueryable<InvoiceSellProduct> SearchByQuantity(this IQueryable<InvoiceSellProduct> invoiceSellProducts, int minQuantity, int? maxQuantity)
        {
            if (minQuantity == 0 && !maxQuantity.HasValue) return invoiceSellProducts;
            return invoiceSellProducts.Where(i => i.Quantity > minQuantity && i.Quantity < maxQuantity);
        }

        public static IQueryable<InvoiceSellProduct> IsInclude(this IQueryable<InvoiceSellProduct> invoiceSellProducts, string? fieldsString)
        {
            if(string.IsNullOrWhiteSpace(fieldsString)) return invoiceSellProducts;
            var fields = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);
            foreach (var field in fields) {
                var property = InvoiceSellProduct.PropertyInfos.FirstOrDefault(i => i.Name.Equals(field));
                if (field != null)
                    invoiceSellProducts.Include(field);
            }
            return invoiceSellProducts;
        }

        public static IQueryable<InvoiceSellProduct> Sort(this IQueryable<InvoiceSellProduct> invoiceSellProducts, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return invoiceSellProducts.OrderBy(i => i.CreatedAt);

            var orderQuery = QueryBuilder.CreateOrderQuery<InvoiceSellProduct>(orderByQueryString, InvoiceSellProduct.PropertyInfos);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return invoiceSellProducts.OrderBy(p => p.CreatedAt);

            return invoiceSellProducts.OrderBy(orderQuery);
        }
    }
}
