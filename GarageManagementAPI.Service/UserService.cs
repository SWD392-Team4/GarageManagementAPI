using AutoMapper;
using System.Dynamic;
using Microsoft.AspNetCore.Identity;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Service.Extension;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.Constant.Authentication;
using GarageManagementAPI.Shared.DataTransferObjects.User;
using GarageManagementAPI.Shared.ErrorsConstant.Workplace;
using GarageManagementAPI.Shared.ResultModel;

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

        private async Task<Result> CheckIfWorkplaceExist(Guid workplaceId)
        {
            var workplace = await _repoManager.Workplace.GetWorkplaceByIdAsync(workplaceId, false);
            if (workplace is null)
                return Result.NotFound([WorkplaceErrors.GetWorkplaceNotFoundError(workplaceId)]);

            return Result.Ok();
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

        public async Task<Result> UpdateEmployeeAsync(Guid id, UserForUpdateEmployeeDto userForUpdateEmployeeDto, bool trackChanges)
        {
            var resultCheck = await GetAndCheckIfUserExist(id, trackChanges, "EmployeeInfo");

            var resultWorkplaceCheck = await CheckIfWorkplaceExist((Guid)userForUpdateEmployeeDto.WorkplaceId!);

            if (!resultCheck.IsSuccess || !resultWorkplaceCheck.IsSuccess) return Result.BadRequest(resultCheck.Errors ?? resultWorkplaceCheck.Errors!);
            var userEntity = resultCheck.GetValue<User>();


            _mapper.Map(userForUpdateEmployeeDto, userEntity);
            _mapper.Map(userForUpdateEmployeeDto, userEntity.EmployeeInfo);

            userEntity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            await _repoManager.SaveAsync();

            return Result.NoContent();

        }

        public async Task<Result<string?>> UpdateUserImageAsync(Guid id, bool trackChanges, string imgId, string imgUrl)
        {
            var resultCheck = await GetAndCheckIfUserExist(id, trackChanges);

            if (!resultCheck.IsSuccess) return Result<string?>.BadRequest(resultCheck.Errors!);
            var userEntity = resultCheck.GetValue<User>();
            var oldImage = userEntity.ImageId;
            userEntity.ImageId = imgId;
            userEntity.ImageLink = imgUrl;

            userEntity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            await _repoManager.SaveAsync();

            return Result<string?>.Ok(oldImage);
        }

        public async Task<Result> UpdateUserAsync(Guid id, UserForUpdateDto userForUpdateEmployeeDto, bool trackChanges)
        {
            var resultCheck = await GetAndCheckIfUserExist(id, trackChanges);

            if (!resultCheck.IsSuccess) return Result.BadRequest(resultCheck.Errors!);

            var userEntity = resultCheck.GetValue<User>();


            _mapper.Map(userForUpdateEmployeeDto, userEntity);

            userEntity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            await _repoManager.SaveAsync();

            return Result.NoContent();
        }
    }
}
