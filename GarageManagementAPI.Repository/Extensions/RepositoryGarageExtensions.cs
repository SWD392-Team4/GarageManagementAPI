using GarageManagementAPI.Entities.NewModels;
using GarageManagementAPI.Repository.Extensions.Utility;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace GarageManagementAPI.Repository.Extensions
{
    public static class RepositoryGarageExtensions
    {
        public static IQueryable<Garage> Search(this IQueryable<Garage> garages, string? searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return garages;
            }

            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return garages.Where(g => g.Name.ToLower().Contains(lowerCaseTerm));
        }

        public static IQueryable<Garage> Sort(this IQueryable<Garage> garages, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return garages.OrderBy(e => e.Name);

            var orderQuery = QueryBuilder.CreateOrderQuery<Garage>(orderByQueryString, Garage.PropertyInfos);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return garages.OrderBy(e => e.Name);

            return garages.OrderBy(orderQuery);

        }

        public static IQueryable<Garage> Includes(this IQueryable<Garage> garages, string? fieldsString)
        {
            if (string.IsNullOrWhiteSpace(fieldsString))
            {
                return garages;
            }

            var fields = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);

            foreach (var field in fields)
            {
                if (Garage.PropertyInfos.Any(pi =>
                pi.Name
                .Equals(
                    field.Trim(),
                    StringComparison.InvariantCultureIgnoreCase)))
                    garages = garages.Include(field);
            }

            return garages;
        }
    }
}
