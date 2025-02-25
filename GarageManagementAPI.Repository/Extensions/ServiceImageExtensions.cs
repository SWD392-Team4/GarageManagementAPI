using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Repository.Extensions.Utility;

namespace GarageManagementAPI.Repository.Extensions
{
    public static class ServiceImageExtensions
    {
        public static IQueryable<ServiceImage> SearchByStatus(this IQueryable<ServiceImage> serivices, ServiceImageStatus? status)
        {
            if (status is null) return serivices;

            return serivices.Where(p => p.Status == status);
        }

        public static IQueryable<ServiceImage> IsInclude(this IQueryable<ServiceImage> services, string? fieldsString)
        {
            if (string.IsNullOrWhiteSpace(fieldsString)) return services;

            var fields = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);

            foreach (var field in fields)
            {
                // Tìm thuộc tính trong PropertyInfos của lớp ServiceImage
                var property = ServiceImage.PropertyInfos
                    .FirstOrDefault(pi => pi.Name.Equals(field.Trim(), StringComparison.InvariantCultureIgnoreCase));

                // Nếu thuộc tính hợp lệ, thực hiện Include
                if (property != null)
                {
                    // Bao gồm các tất cả thuộc tính 
                    services = services.Include(field.Trim());
                }
            }
            return services;
        }


        public static IQueryable<ServiceImage> Sort(this IQueryable<ServiceImage> services, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return services.OrderBy(p => p.Status);  // Sắp xếp mặc định theo ProductName

            // Tạo biểu thức sắp xếp động từ query string
            var orderQuery = QueryBuilder.CreateOrderQuery<ServiceImage>(orderByQueryString, ServiceImage.PropertyInfos);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return services.OrderBy(p => p.Status);  // Nếu không có chuỗi sắp xếp hợp lệ, sắp xếp theo ProductName

            // Áp dụng sắp xếp động với biểu thức đã tạo
            return services.OrderBy(orderQuery);
        }
    }
}
