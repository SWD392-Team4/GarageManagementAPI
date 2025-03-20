using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Repository.Extensions.Utility;

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

            return product.Where(p => EF.Functions.Like(p.ProductName, $"%{name}%"));
        }
        public static IQueryable<Product> SearchByPrice(this IQueryable<Product> products, decimal? minPrice, decimal? maxPrice)
        {
            if (minPrice == 0 && !maxPrice.HasValue)
            {
                return products;
            }

            if(minPrice > 0 && !maxPrice.HasValue) return products.Where(p => p.ProductPrice >= minPrice);

            return products.Where(p => p.ProductPrice >= minPrice && p.ProductPrice <= maxPrice);
        }

        public static IQueryable<Product> SearchByBarCode(this IQueryable<Product> products, string? barcode)
        {
            if (string.IsNullOrWhiteSpace(barcode)) return products;
            return products.Where(p => p.ProductBarcode.Equals(barcode));
        }


        public static IQueryable<Product> SearchByCategory(this IQueryable<Product> products, string? category)
        {
            if (string.IsNullOrWhiteSpace(category))
            {
                return products;
            }

            return products.Where(p => p.ProductCategory != null &&
                                      p.ProductCategory.Category.ToLower().Equals(category.ToLower()));

        }
        public static IQueryable<Product> SearchByBrand(this IQueryable<Product> products, string? brand)
        {
            if (string.IsNullOrWhiteSpace(brand))
            {
                return products;
            }

            return products.Where(p => p.Brand != null &&
                                      p.Brand.BrandName.ToLower().Equals(brand.ToLower()));
        }

        public static IQueryable<Product> SearchByStatus(this IQueryable<Product> products, ProductStatus? status)
        {
            if (status is null)
            {
                return products;
            }

            return products.Where(p => p.Status.ToString().Equals(status.ToString()));
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

            return products.OrderBy(orderQuery);
        }
    }
}
