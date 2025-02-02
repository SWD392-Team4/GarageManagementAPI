using GarageManagementAPI.Shared.DataTransferObjects.User;
using GarageManagementAPI.Shared.ResultModel;
using Microsoft.AspNetCore.Identity;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistrationDto);

        Task<Result<string>> CreateConfirmEmailUrl(string email);

        Task<Result<IdentityResult>> ConfirmEmail(UserForConfirmEmail userForConfirmEmail);

        Task<Result> ValidateUser(UserForAuthenticationDto userForAuth);

        Task<Result<TokenDto>> CreateToken(bool populateExp);

        Task<Result<TokenDto>> RefreshToken(TokenDto tokenDto);

        Task<Result<string>> CreateForgotPasswordUrl(string email);

        Task<Result<IdentityResult>> ResetPassword(UserForResetPasswordDto userForResetPasswordDto);

        Task<Result<IdentityResult>> ChangePassword(string username, UserForChangePasswordDto userForChangePasswordDto);
    }
}
