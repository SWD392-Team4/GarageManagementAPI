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
        public async Task<User?> GetUserByRoleAsync(Guid userId, bool trackChanges, string? include = null)
        {
            var user = include is null ?
                await FindByCondition(u => u.Id.Equals(userId) && u.Roles.Any(r => r.Name!.Equals(nameof(SystemRole.Cashier))), trackChanges).SingleOrDefaultAsync() :
                await FindByCondition(u => u.Id.Equals(userId) && u.Roles.Any(r => r.Name!.Equals(nameof(SystemRole.Cashier))), trackChanges).IsInclude(include).SingleOrDefaultAsync();

            return user;
        }
        public async Task<PagedList<User>> GetUsersAsync(UserParameters userParameters, bool trackChanges, bool isEmployee, string? include = null)
        {
            var users = await FindByCondition(u => isEmployee ? u.EmployeeInfo != null && !u.Roles.Any(r => r.Name!.Equals(nameof(SystemRole.Administrator))) : u.EmployeeInfo == null, trackChanges)
                .SearchByFirstName(userParameters.FirstName)
                .SearchByLastName(userParameters.LastName)
                .FilterByRole(userParameters.Role)
                .FilterByPhoneNumber(userParameters.PhoneNumber)
                .FilterByWorkplace(userParameters.WorkplaceId)
                .Sort(userParameters.OrderBy)
                .IsInclude(include)
                .Skip((userParameters.PageNumber - 1) * userParameters.PageSize)
                .Take(userParameters.PageSize)
                .ToListAsync();

            var count = await FindByCondition(u => isEmployee ? u.EmployeeInfo != null && !u.Roles.Any(r => r.Name!.Equals(nameof(SystemRole.Administrator))) : u.EmployeeInfo == null, trackChanges)
                .SearchByFirstName(userParameters.FirstName)
                .SearchByLastName(userParameters.LastName)
                .FilterByRole(userParameters.Role)
                .CountAsync();


            return new PagedList<User>(
                users,
                count,
                userParameters.PageNumber,
                userParameters.PageSize);
        }

        public async Task<IEnumerable<User>> GetUsersByRoleAsync()
        {
            var users = await FindByCondition(u => u.Roles.Any(r => r.Name!.Equals(nameof(SystemRole.Cashier))), false).ToListAsync();
            return users!;
        }

        public async Task<User?> GetUserByEmailAndPhone(string email, string phone, bool trackChanges, string? include = null)
        {
            var customer = await FindByCondition(u => u.PhoneNumber!.Equals(phone) && u.Email!.ToLower().Equals(email.ToLower()), trackChanges).SingleOrDefaultAsync();
            return customer;
        }
    }
}
