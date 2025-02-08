using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.Brand;
using GarageManagementAPI.Shared.DataTransferObjects.Workplace;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User?> GetUserByIdAsync(Guid userId, bool trackChanges, string? include = default);

        Task<PagedList<User>> GetUsersAsync(UserParameters userParameters, bool trackChanges, bool isEmployee, string? include = default);
    }
}
