using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Extensions.Utility;
using GarageManagementAPI.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Reflection;

namespace GarageManagementAPI.Repository.Extensions
{
    public static class UserRepositoryExtensions
    {
        public static IQueryable<User> SearchByFirstName(this IQueryable<User> user, string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return user;
            }

            var lowerCaseTerm = name.Trim().ToLower();
            return user.Where(g => g.FirstName!.ToLower().Contains(name));
        }

        public static IQueryable<User> SearchByLastName(this IQueryable<User> user, string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return user;
            }

            var lowerCaseTerm = name.Trim().ToLower();
            return user.Where(g => g.LastName!.ToLower().Contains(name));
        }

        public static IQueryable<User> Sort(this IQueryable<User> user, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return user.OrderBy(e => e.FirstName);

            var orderQuery = QueryBuilder.CreateOrderQuery<User>(orderByQueryString, User.PropertyInfos);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return user.OrderBy(e => e.FirstName);

            return user.OrderBy(orderQuery);

        }

        public static IQueryable<User> FilterByRole(this IQueryable<User> user, SystemRole? role)
        {
            if (role is null)
                return user;

            return user.Where(u => u.Roles.Any(r => r.Name!.Equals(role.Value.ToString())));

        }

        public static IQueryable<User> IsInclude(this IQueryable<User> user, string? fieldsString)
        {
            if (string.IsNullOrWhiteSpace(fieldsString))
                return user;

            var fields = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);


            foreach (var field in fields)
            {
                var property = User.PropertyInfos
                    .FirstOrDefault(pi => pi.Name.Equals(field.Trim(), StringComparison.InvariantCultureIgnoreCase));

                if (property != null)
                {
                    user = user.Include(field.Trim());
                }
            }

            return user;
        }
    }
}
