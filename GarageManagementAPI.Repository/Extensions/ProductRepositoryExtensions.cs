using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Extensions.Utility;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace GarageManagementAPI.Repository.Extensions
{
    public static class ProductRepositoryExtensions
    {
        public static IQueryable<Product> SearchByName(this IQueryable<Product> product, string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return product;
            }

            var lowerCaseTerm = name.Trim().ToLower();
            return product.Where(p => p.ProductName!.ToLower().Contains(name.Trim().ToLower()));
        }

        public static IQueryable<Product> SearchByStatus(this IQueryable<Product> products, ProductStatus? status)
        {
            if (status is null)
            {
                return products;
            }

            return products.Where(p => p.Status.Equals(status));
        }

        //IQueryable xây dựng và thực thi các truy vấn động trên nguồn dữ liệu
        public static IQueryable<Product> IsInclude(this IQueryable<Product> product, string? fieldsString)
        {
            if (string.IsNullOrWhiteSpace(fieldsString))
                return product;

            var fields = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);

            foreach (var field in fields)
            {
                // Tìm thuộc tính trong PropertyInfos của lớp Product
                var property = Product.PropertyInfos
                    .FirstOrDefault(pi => pi.Name.Equals(field.Trim(), StringComparison.InvariantCultureIgnoreCase));

                
                // Nếu thuộc tính hợp lệ, thực hiện Include
                if (property != null)
                {
                    //Include trong Entity Framewor tải trước các đối tượng liên kết (related entities) cùng với đối tượng chính trong một truy vấn duy nhất.
                    // Bao gồm các tất cả thuộc tính 
                    product = product.Include(field.Trim());
                }
            }
            return product;
        }

        public static IQueryable<Product> Sort(this IQueryable<Product> products, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return products.OrderBy(p => p.ProductName);  // Sắp xếp mặc định theo ProductName

            // Tạo biểu thức sắp xếp động từ query string
            var orderQuery = QueryBuilder.CreateOrderQuery<Product>(orderByQueryString, Product.PropertyInfos);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return products.OrderBy(p => p.ProductName);  // Nếu không có chuỗi sắp xếp hợp lệ, sắp xếp theo ProductName

            // Áp dụng sắp xếp động với biểu thức đã tạo
            return products.OrderBy(orderQuery);
        }
    }
}
