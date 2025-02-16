using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Extensions.Utility;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace GarageManagementAPI.Repository.Extensions
{
    public static class ProductCategoryExtensions
    {
        public static IQueryable<ProductCategory> SearchByName(this IQueryable<ProductCategory> productCategory, string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return productCategory;
            }

            var lowerCaseTerm = name.Trim().ToLower();
            return productCategory.Where(p => p.Category!.ToLower().Contains(name.Trim().ToLower()));
        }

        public static IQueryable<ProductCategory> SearchByStatus(this IQueryable<ProductCategory> productCategorys, ProductCategoryStatus? status)
        {
            if (status is null)return productCategorys;
            return productCategorys.Where(p => p.Status.Equals(status));
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
