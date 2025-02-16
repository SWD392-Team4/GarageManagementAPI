using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Extensions.Utility;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace GarageManagementAPI.Repository.Extensions
{
    public static class WorkplaceRepositoryExtensions
    {
        public static IQueryable<Workplace> SearchByStatus(this IQueryable<Workplace> workpaces, WorkplaceStatus? status)
        {
            if (status is null || status.Equals(WorkplaceStatus.None))
            {
                return workpaces;
            }

            return workpaces.Where(g => g.Status == status);
        }
        public static IQueryable<Workplace> SearchByType(this IQueryable<Workplace> workpaces, WorkplaceType? type)
        {
            if (type is null || type.Equals(WorkplaceType.None))
            {
                return workpaces;
            }

            return workpaces.Where(g => g.WorkplaceType == type);
        }

        public static IQueryable<Workplace> SearchByName(this IQueryable<Workplace> workpaces, string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return workpaces;
            }

            var lowerCaseTerm = name.Trim().ToLower();
            return workpaces.Where(g => g.Name.ToLower().Contains(name));
        }

        public static IQueryable<Workplace> Sort(this IQueryable<Workplace> workpaces, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return workpaces.OrderBy(e => e.Name);

            var orderQuery = QueryBuilder.CreateOrderQuery<Workplace>(orderByQueryString, Workplace.PropertyInfos);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return workpaces.OrderBy(e => e.Name);

            return workpaces.OrderBy(orderQuery);

        }
    }
}
