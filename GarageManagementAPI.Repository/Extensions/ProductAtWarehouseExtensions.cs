using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Extensions.Utility;
using GarageManagementAPI.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace GarageManagementAPI.Repository.Extensions
{
    public static class ProductAtWarehouseExtensions
    {
        public static IQueryable<ProductAtWarehouse> SearchByQuantity (this IQueryable<ProductAtWarehouse> productAtWarehouses, int minQuantity, int? maxQuantity)
        {
            if(!maxQuantity.HasValue && minQuantity == 0) return productAtWarehouses;
         return productAtWarehouses.Where(p => p.Quantity >= minQuantity && p.Quantity <= maxQuantity);
        }

        public static IQueryable<ProductAtWarehouse> SearchByStatus (this IQueryable<ProductAtWarehouse> productAtWarehouses, SystemStatus? status)
        {
            if (status is null) return productAtWarehouses;
            return productAtWarehouses.Where(p => p.Status == status);
        }

        public static IQueryable<ProductAtWarehouse> SerchByCreatedAt(this IQueryable<ProductAtWarehouse> productAtWarehouses, DateTimeOffset? createdAt) {
            if (!createdAt.HasValue) return productAtWarehouses;
            DateTimeOffset startDate = createdAt.Value.Date;
            DateTimeOffset endDate = startDate.AddDays(1).AddTicks(-1);
            if (startDate > DateTimeOffset.MaxValue || endDate > DateTimeOffset.MaxValue)
            {
                throw new ArgumentOutOfRangeException("The specified date range is outside the valid range.");
            }
            return productAtWarehouses.Where(p => p.CreatedAt >= startDate && p.CreatedAt <= endDate);
        }

        public static IQueryable<ProductAtWarehouse> SerchByUpdatedAt(this IQueryable<ProductAtWarehouse> productAtWarehouses, DateTimeOffset? updatedAt)
        {
            if (!updatedAt.HasValue) return productAtWarehouses;
            DateTimeOffset startDate = updatedAt.Value.Date;
            DateTimeOffset endDate = startDate.AddDays(1).AddTicks(-1);
            if (startDate > DateTimeOffset.MaxValue || endDate > DateTimeOffset.MaxValue)
            {
                throw new ArgumentOutOfRangeException("The specified date range is outside the valid range.");
            }
            return productAtWarehouses.Where(p => p.UpdatedAt >= startDate && p.UpdatedAt <= endDate);
        }

        public static IQueryable<ProductAtWarehouse> IsInclude(this IQueryable<ProductAtWarehouse> productAtWareHouse, string fieldsString)
        {
            if (string.IsNullOrEmpty(fieldsString)) return productAtWareHouse;
            var fields = fieldsString.Split(',');
            foreach (var field in fields)
            {
              var property = ProductAtWarehouse.PropertyInfos.FirstOrDefault(p => p.Name.Equals(field, StringComparison.InvariantCultureIgnoreCase));
                if(property != null) productAtWareHouse.Include(field);
            }
            return productAtWareHouse;
        }

        public static IQueryable<ProductAtWarehouse> Sort(this IQueryable<ProductAtWarehouse> productAtWarehouses, string? orderByQueryString)
        {
            if(string.IsNullOrEmpty(orderByQueryString)) return productAtWarehouses.OrderBy("CreatedAt");
            var orderBy = QueryBuilder.CreateOrderQuery<ProductAtWarehouse>(orderByQueryString, ProductAtWarehouse.PropertyInfos);
            if(string.IsNullOrEmpty(orderBy)) return productAtWarehouses.OrderBy("CreatedAt");
            return productAtWarehouses.OrderBy(orderBy);
        }
    }
}
