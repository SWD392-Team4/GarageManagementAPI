using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User?> GetUserByIdAsync(Guid userId, bool trackChanges, string? include = default);
        Task<User?> GetUserByRoleAsync(Guid userId, bool trackChanges, string? include = default);

        Task<PagedList<User>> GetUsersAsync(UserParameters userParameters, bool trackChanges, bool isEmployee, string? include = default);
        Task<IEnumerable<User>> GetUsersByRoleAsync();
    }
}
