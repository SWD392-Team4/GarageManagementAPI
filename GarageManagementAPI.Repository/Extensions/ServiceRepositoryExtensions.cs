using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Extensions.Utility;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;


namespace GarageManagementAPI.Repository.Extensions
{
    public static class ServiceRepositoryExtensions
    {
        public static IQueryable<Service> SearchByName(this IQueryable<Service> service, string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return service;
            }

            return service.Where(s => s.ServiceName!.Contains(name.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        public static IQueryable<Service> SearchByWorkNature(this IQueryable<Service> service, string? workNature)
        {
            if (string.IsNullOrWhiteSpace(workNature))
            {
                return service;
            }

            return service.Where(s => s.WorkNature!.Contains(workNature.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        public static IQueryable<Service> SearchByAction(this IQueryable<Service> service, string? action)
        {
            if (string.IsNullOrWhiteSpace(action))
            {
                return service;
            }

            return service.Where(s => s.Action!.Contains(action.Trim(), StringComparison.OrdinalIgnoreCase));
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
            // Check for out-of-range values before querying
            //1 tick = 100 nano giây
            //AddTick(-1) - 0.0000000009s
            DateTimeOffset endDate = startDate.AddDays(1).AddTicks(-1);

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
                return service; 
            }

            DateTimeOffset startDate = updatedAt.Value.Date;
            // End of day calculation
            DateTimeOffset endDate = startDate.AddDays(1).AddTicks(-1); 

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

        public static IQueryable<Service> SearchByCarCategory(this IQueryable<Service> carParts, string? carCategory)
        {
            if (string.IsNullOrWhiteSpace(carCategory))
            {
                return carParts;
            }

            return carParts.Where(s => s.CarCategory != null &&
                                      s.CarCategory.Category.ToLower().Equals(carCategory.ToLower()));
        }

        public static IQueryable<Service> SearchByCarPart(this IQueryable<Service> carParts, string? carPart)
        {
            if (string.IsNullOrWhiteSpace(carPart))
            {
                return carParts;
            }

            return carParts.Where(s => s.CarPart != null &&
                                      s.CarPart.PartName.ToLower().Equals(carPart.ToLower()));
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
                return Services.OrderBy(p => p.ServiceName);  

            // Tạo biểu thức sắp xếp động từ query string
            var orderQuery = QueryBuilder.CreateOrderQuery<Service>(orderByQueryString, Service.PropertyInfos);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return Services.OrderBy(p => p.ServiceName); 

            return Services.OrderBy(orderQuery);
        }
    }
}
