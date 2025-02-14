
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Extensions.Utility;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace GarageManagementAPI.Repository.Extensions
{
    public static class ProductImageRepositoryExtensions
    {
        public static IQueryable<ProductImage> SearchByStatus(this IQueryable<ProductImage> products, ProductImageStatus? status)
        {
            if (status is null || status.Equals(ProductImageStatus.None))
            {
                return products;
            }

            return products.Where(p => p.Status == status);
        }

        public static IQueryable<ProductImage> IsInclude(this IQueryable<ProductImage> products, string? fieldsString)
        {
            if (string.IsNullOrWhiteSpace(fieldsString))
                return products;

            var fields = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);

            foreach (var field in fields)
            {
                // Tìm thuộc tính trong PropertyInfos của lớp ProductImage
                var property = ProductImage.PropertyInfos
                    .FirstOrDefault(pi => pi.Name.Equals(field.Trim(), StringComparison.InvariantCultureIgnoreCase));

                // Nếu thuộc tính hợp lệ, thực hiện Include
                if (property != null)
                {
                    // Bao gồm các tất cả thuộc tính 
                    products = products.Include(field.Trim());
                }
            }
            return products;
        }


        public static IQueryable<ProductImage> Sort(this IQueryable<ProductImage> products, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return products.OrderBy(p => p.Status);  // Sắp xếp mặc định theo ProductName
            
            // Tạo biểu thức sắp xếp động từ query string
            var orderQuery = QueryBuilder.CreateOrderQuery<ProductImage>(orderByQueryString, ProductImage.PropertyInfos);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return products.OrderBy(p => p.Status);  // Nếu không có chuỗi sắp xếp hợp lệ, sắp xếp theo ProductName

            // Áp dụng sắp xếp động với biểu thức đã tạo
            return products.OrderBy(orderQuery);
        }
    }
}
