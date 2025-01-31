using GarageManagementAPI.Shared.DataTransferObjects.User;
using GarageManagementAPI.Shared.ResultModel;
using Microsoft.AspNetCore.Identity;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistrationDto);

        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);

        Task<Result<TokenDto>> CreateToken(bool populateExp);

        Task<Result<TokenDto>> RefreshToken(TokenDto tokenDto);

        Task<Result<string>> ForgotPassword(UserForForgotPasswordDto userForForgotPasswordDto);
    }
}
