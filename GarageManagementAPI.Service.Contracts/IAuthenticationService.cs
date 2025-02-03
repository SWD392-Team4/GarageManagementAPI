using GarageManagementAPI.Shared.DataTransferObjects.User;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.ResultModel;
using Microsoft.AspNetCore.Identity;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IAuthenticationService
    {
        string GenerateRandomPassword(int length);
        string GenerateUserName(string firstName, string lasName);

        Task<Result> RegisterUser(UserForRegistrationDto userForRegistrationDto, SystemRole role, string password);

        Task<Result> RegisterEmployeeInfo(UserForRegistrationEmployeeDto userForRegistrationEmployeeDto, SystemRole role, string password);

        Task<Result<string>> CreateConfirmEmailUrl(string email);

        Task<Result> ConfirmEmail(UserForConfirmEmail userForConfirmEmail);

        Task<Result> ValidateUser(UserForAuthenticationDto userForAuth);

        Task<Result<TokenDto>> CreateToken(bool populateExp);

        Task<Result<TokenDto>> RefreshToken(TokenDto tokenDto);

        Task<Result<string>> CreateForgotPasswordUrl(string email);

        Task<Result> ResetPassword(UserForResetPasswordDto userForResetPasswordDto);

        Task<Result> ChangePassword(string username, UserForChangePasswordDto userForChangePasswordDto);
    }
}
