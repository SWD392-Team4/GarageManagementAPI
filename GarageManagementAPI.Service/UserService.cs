using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Service.Extension;
using GarageManagementAPI.Shared.Constant.Authentication;
using GarageManagementAPI.Shared.DataTransferObjects.User;
using GarageManagementAPI.Shared.DataTransferObjects.Workplace;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;
using Microsoft.AspNetCore.Identity;
using System.Dynamic;

namespace GarageManagementAPI.Service
{
    public class UserService : IUserService
    {
        private readonly IRepositoryManager _repoManager;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IDataShaperManager _dataShaper;

        public UserService(IRepositoryManager repoManager, IMapper mapper, UserManager<User> userManager, IDataShaperManager dataShaperManager)
        {
            _repoManager = repoManager;
            _mapper = mapper;
            _userManager = userManager;
            _dataShaper = dataShaperManager;
        }

        private async Task<Result<User>> GetAndCheckIfUserExist(Guid userId, bool trackChanges, string? include = null)
        {
            var user = await _repoManager.User.GetUserByIdAsync(userId, trackChanges, include);

            if (user is null)
                return Result<User>.NotFound([UserErrors.GetUserNotFoundWithIdError()]);

            return Result<User>.Ok(user);
        }

        public async Task<Result<ExpandoObject>> GetUserAsync(Guid userId, UserParameters userParameters, bool trackChanges, string? include = null)
        {
            var userResult = await GetAndCheckIfUserExist(userId, trackChanges, include);

            if (!userResult.IsSuccess)
                return Result<ExpandoObject>.NotFound(userResult.Errors!);

            var userEntity = userResult.GetValue<User>();

            var userDto = _mapper.Map<UserDto>(userEntity);

            var userShaped = _dataShaper.User.ShapeData(userDto, userParameters.Fields);

            return Result<ExpandoObject>.Ok(userShaped);
        }

        public async Task<Result<IEnumerable<ExpandoObject>>> GetUsersAsync(UserParameters userParameters, bool trackChanges, bool isEmployee, string? include = null)
        {
            var usersWithMetadata = await _repoManager.User.GetUsersAsync(userParameters, trackChanges, isEmployee, include);

            var usersDto = _mapper.Map<IEnumerable<UserDto>>(usersWithMetadata);

            var usersShaped = _dataShaper.User.ShapeData(usersDto, userParameters.Fields);

            return Result<IEnumerable<ExpandoObject>>.Ok(usersShaped, usersWithMetadata.MetaData);
        }

        public async Task<Result> UpdateEmployeeAsync(Guid id, UserForUpdateEmployeeDto userForUpdateEmployeeDto, bool trackChanges, string? imgUrl = null)
        {
            var resultCheck = await GetAndCheckIfUserExist(id, trackChanges, "EmployeeInfo");

            if (!resultCheck.IsSuccess) return Result.BadRequest(resultCheck.Errors!);
            var userEntity = resultCheck.GetValue<User>();

            _mapper.Map(userForUpdateEmployeeDto, userEntity);
            _mapper.Map(userForUpdateEmployeeDto, userEntity.EmployeeInfo);

            userEntity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            userEntity.EmployeeInfo!.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            await _repoManager.SaveAsync();

            return Result.NoContent();

        }
    }
}
