using GarageManagementAPI.Shared.DataTransferObjects.User;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;
using System.Dynamic;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IUserService
    {
        public Task<Result<ExpandoObject>> GetUserAsync(Guid userId, UserParameters userParameters, bool trackChanges, string? include = null);

        public Task<Result<IEnumerable<ExpandoObject>>> GetUsersAsync(UserParameters userParameters, bool trackChanges, bool isEmployee, string? include = null);

        public Task<Result> UpdateEmployeeAsync(Guid id, UserForUpdateEmployeeDto userForUpdateEmployeeDto, bool trackChanges);

        public Task<Result> UpdateUserAsync(Guid id, UserForUpdateDto userForUpdateEmployeeDto, bool trackChanges);

        public Task<Result<string?>> UpdateUserImageAsync(Guid id, bool trackChanges, string imgId, string imgUrl);

    }
}
