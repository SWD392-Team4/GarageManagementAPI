using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace GarageManagementAPI.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<User?> GetUserByIdAsync(Guid userId, bool trackChanges, string? include = null)
        {
            var user = include is null ?
                await FindByCondition(u => u.Id.Equals(userId), trackChanges).SingleOrDefaultAsync() :
                await FindByCondition(u => u.Id.Equals(userId), trackChanges).IsInclude(include).SingleOrDefaultAsync();

            return user;
        }

        public async Task<PagedList<User>> GetUsersAsync(UserParameters userParameters, bool trackChanges, bool isEmployee, string? include = null)
        {
            var users = await FindByCondition(u => isEmployee ? u.EmployeeInfo != null && !u.Roles.Any(r => r.Name!.Equals(nameof(SystemRole.Administrator))) : u.EmployeeInfo == null, trackChanges)
                .SearchByFirstName(userParameters.FirstName)
                .SearchByLastName(userParameters.LastName)
                .Sort(userParameters.OrderBy)
                .IsInclude(include)
                .Skip((userParameters.PageNumber - 1) * userParameters.PageSize)
                .Take(userParameters.PageSize)
                .ToListAsync();

            var count = await FindByCondition(u => isEmployee ? u.EmployeeInfo != null && !u.Roles.Any(r => r.Name!.Equals(nameof(SystemRole.Administrator))) : u.EmployeeInfo == null, trackChanges)
                .SearchByFirstName(userParameters.FirstName)
                .SearchByLastName(userParameters.LastName)
                .CountAsync();


            return new PagedList<User>(
                users,
                count,
                userParameters.PageNumber,
                userParameters.PageSize);
        }
    }
}
