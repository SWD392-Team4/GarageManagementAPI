﻿using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Repository.Extensions.Utility;

namespace GarageManagementAPI.Repository.Extensions
{
    public static class ProductCategoryExtensions
    {
        public static IQueryable<ProductCategory> SearchByDate(this IQueryable<ProductCategory> productCategory, DateTimeOffset? createdAt)
        {
            if (!createdAt.HasValue || createdAt.Value == DateTimeOffset.MinValue)
            {
                return productCategory;  // Skip filtering by date if createdAt is not provided or is MinValue
            }

            DateTimeOffset startDate = createdAt.Value.Date;
            DateTimeOffset endDate = startDate.AddDays(1).AddTicks(-1); // End of day calculation

            // Check for out-of-range values before querying
            if (startDate > DateTimeOffset.MaxValue || endDate > DateTimeOffset.MaxValue)
            {
                throw new ArgumentOutOfRangeException("The specified date range is outside the valid range.");
            }

            return productCategory.Where(b =>
                b.CreatedAt >= startDate &&
                b.CreatedAt <= endDate
            );
        }

        public static IQueryable<ProductCategory> SearchByName(this IQueryable<ProductCategory> productCategory, string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return productCategory;
            }

            var lowerCaseTerm = name.Trim().ToLower();
            return productCategory.Where(p => EF.Functions.Like(p.Category, $"%{name}%"));
        }

        public static IQueryable<ProductCategory> SearchByStatus(this IQueryable<ProductCategory> productCategorys, ProductCategoryStatus? status)
        {
            if (status is null)return productCategorys;
            return productCategorys.Where(p => p.Status.ToString().Equals(status.ToString()));
        }

        //IQueryable xây dựng và thực thi các truy vấn động trên nguồn dữ liệu
        public static IQueryable<ProductCategory> IsInclude(this IQueryable<ProductCategory> productCategory, string? fieldsString)
        {
            if (string.IsNullOrWhiteSpace(fieldsString))
                return productCategory;

            var fields = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);

            foreach (var field in fields)
            {
                // Tìm thuộc tính trong PropertyInfos của lớp ProductCategory
                var property = ProductCategory.PropertyInfos
                    .FirstOrDefault(pi => pi.Name.Equals(field.Trim(), StringComparison.InvariantCultureIgnoreCase));


                // Nếu thuộc tính hợp lệ, thực hiện Include
                if (property != null)
                {
                    //Include trong Entity Framewor tải trước các đối tượng liên kết (related entities) cùng với đối tượng chính trong một truy vấn duy nhất.
                    // Bao gồm các tất cả thuộc tính 
                    productCategory = productCategory.Include(field.Trim());
                }
            }
            return productCategory;
        }

        public static IQueryable<ProductCategory> Sort(this IQueryable<ProductCategory> productCategorys, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return productCategorys.OrderBy(p => p.Category);  // Sắp xếp mặc định theo ProductCategoryName

            // Tạo biểu thức sắp xếp động từ query string
            var orderQuery = QueryBuilder.CreateOrderQuery<ProductCategory>(orderByQueryString, ProductCategory.PropertyInfos);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return productCategorys.OrderBy(p => p.Category);  // Nếu không có chuỗi sắp xếp hợp lệ, sắp xếp theo ProductCategoryName

            // Áp dụng sắp xếp động với biểu thức đã tạo
            return productCategorys.OrderBy(orderQuery);
        }
    }
}
