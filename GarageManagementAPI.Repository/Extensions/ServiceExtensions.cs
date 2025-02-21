using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Extensions.Utility;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;


namespace GarageManagementAPI.Repository.Extensions
{
    public static class ServiceExtensions
    {
        public static IQueryable<Service> SearchByName(this IQueryable<Service> service, string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return service;
            }

            return service.Where(s => s.ServiceName!.ToLower().Contains(name.Trim().ToLower()));
        }

        public static IQueryable<Service> SearchByWorkNature(this IQueryable<Service> service, string? workNature)
        {
            if (string.IsNullOrWhiteSpace(workNature))
            {
                return service;
            }

            return service.Where(s => s.WorkNature!.ToLower().Contains(workNature.Trim().ToLower()));
        }

        public static IQueryable<Service> SearchByAction(this IQueryable<Service> service, string? action)
        {
            if (string.IsNullOrWhiteSpace(action))
            {
                return service;
            }

            return service.Where(s => s.Action!.ToLower().Contains(action.Trim().ToLower()));
        }


        public static IQueryable<Service> SearchByEstimatedHours(this IQueryable<Service> services, int? estimatedHours)
        {
            if (!estimatedHours.HasValue)
            {
                return services;
            }
            // Thực hiện truy vấn
            return services.Where(s => s.EstimatedHours == estimatedHours);
        }


        public static IQueryable<Service> SearchByStatus(this IQueryable<Service> services, ServiceStatus? status)
        {
            if (status is null)
            {
                return services;
            }

            return services.Where(s => s.Status.ToString().Equals(status.ToString()));
        }

        public static IQueryable<Service> SearchByCreateAt(this IQueryable<Service> service, DateTimeOffset? createdAt)
        {
            if (!createdAt.HasValue || createdAt.Value == DateTimeOffset.MinValue)
            {
                return service;  // Skip filtering by date if createdAt is not provided or is MinValue
            }

            DateTimeOffset startDate = createdAt.Value.Date;
            DateTimeOffset endDate = startDate.AddDays(1).AddTicks(-1); // End of day calculation

            // Check for out-of-range values before querying
            if (startDate > DateTimeOffset.MaxValue || endDate > DateTimeOffset.MaxValue)
            {
                throw new ArgumentOutOfRangeException("The specified date range is outside the valid range.");
            }

            return service.Where(s =>
                s.CreatedAt >= startDate &&
                s.CreatedAt <= endDate
            );
        }

        public static IQueryable<Service> SearchByUpdateAt(this IQueryable<Service> service, DateTimeOffset? updatedAt)
        {
            if (!updatedAt.HasValue || updatedAt.Value == DateTimeOffset.MinValue)
            {
                return service;  // Skip filtering by date if createdAt is not provided or is MinValue
            }

            DateTimeOffset startDate = updatedAt.Value.Date;
            DateTimeOffset endDate = startDate.AddDays(1).AddTicks(-1); // End of day calculation

            // Check for out-of-range values before querying
            if (startDate > DateTimeOffset.MaxValue || endDate > DateTimeOffset.MaxValue)
            {
                throw new ArgumentOutOfRangeException("The specified date range is outside the valid range.");
            }

            return service.Where(s =>
                s.UpdatedAt >= startDate &&
                s.UpdatedAt <= endDate
            );
        }

        //IQueryable xây dựng và thực thi các truy vấn động trên nguồn dữ liệu
        public static IQueryable<Service> IsInclude(this IQueryable<Service> service, string? fieldsString)
        {
            if (string.IsNullOrWhiteSpace(fieldsString))
                return service;

            var fields = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);

            foreach (var field in fields)
            {
                // Tìm thuộc tính trong PropertyInfos của lớp Service
                var property = Service.PropertyInfos
                    .FirstOrDefault(pi => pi.Name.Equals(field.Trim(), StringComparison.InvariantCultureIgnoreCase));


                // Nếu thuộc tính hợp lệ, thực hiện Include
                if (property != null)
                {
                    //Include trong Entity Framewor tải trước các đối tượng liên kết (related entities) cùng với đối tượng chính trong một truy vấn duy nhất.
                    // Bao gồm các tất cả thuộc tính 
                    service = service.Include(field.Trim());
                }
            }
            return service;
        }

        public static IQueryable<Service> Sort(this IQueryable<Service> Services, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return Services.OrderBy(p => p.ServiceName);  // Sắp xếp mặc định theo ServiceName

            // Tạo biểu thức sắp xếp động từ query string
            var orderQuery = QueryBuilder.CreateOrderQuery<Service>(orderByQueryString, Service.PropertyInfos);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return Services.OrderBy(p => p.ServiceName);  // Nếu không có chuỗi sắp xếp hợp lệ, sắp xếp theo ServiceName

            // Áp dụng sắp xếp động với biểu thức đã tạo
            return Services.OrderBy(orderQuery);
        }
    }
}
