using FluentValidation;
using GarageManagementAPI.Presentation.ActionFilters;
using GarageManagementAPI.Presentation.Extensions;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.Constant.Authentication;
using GarageManagementAPI.Shared.DataTransferObjects;
using GarageManagementAPI.Shared.DataTransferObjects.User;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.ResultModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ApiControllerBase
    {
        public AuthenticationController(IServiceManager service) : base(service) { }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistrationDto)
        {
            var userRole = HttpContext.User.Claims
           .FirstOrDefault(c => c.Type == "Role")?.Value;


            if (
                userRole == null && userForRegistrationDto.Role != SystemRole.Customer ||
                userRole != null && userForRegistrationDto.Role == SystemRole.Administrator ||
                userRole != null && userForRegistrationDto.Role != SystemRole.Customer && !userRole.Equals(SystemRole.Administrator.ToString()))
            {
                return new ObjectResult(
                        Result.Forbidden(
                        [UserErrors.GetUnAuthorizedToCreateUserErrors()]))
                {
                    StatusCode = StatusCodes.Status403Forbidden
                };
            }


            var result = await _service.AuthenticationService.RegisterUser(userForRegistrationDto);

            if (!result.Succeeded)
            {
                return result.InvalidResult();
            }

            var resultUrl = await _service.AuthenticationService.CreateConfirmEmailUrl(userForRegistrationDto.Email!);

            var url = resultUrl.GetValue<string>();

            await _service.MailService.SendConfirmEmailEmail(userForRegistrationDto.Email!, url).ConfigureAwait(false);

            return Created();
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] UserForAuthenticationDto userForAuthenticationDto)
        {
            var result = await _service.AuthenticationService.ValidateUser(userForAuthenticationDto);

            if(!result.IsSuccess)
                return ProcessError(result);

            var tokenDto = await _service.AuthenticationService
                .CreateToken(populateExp: true);

            return tokenDto.Map(
                onSuccess: result => Ok(result),
                onFailure: result => ProcessError(result));
        }


        [HttpPost("resend-confirm-email")]
        public async Task<IActionResult> ResendConfirmEmail([FromBody] UserForResendConfirmEmailDto resendConfirmEmailDto)
        {

            var resultUrl = await _service.AuthenticationService.CreateConfirmEmailUrl(resendConfirmEmailDto.Email!);

            var url = resultUrl.GetValue<string>();

            await _service.MailService.SendConfirmEmailEmail(resendConfirmEmailDto.Email!, url).ConfigureAwait(false);

            return Ok();
        }

        [HttpPost("confirm-email")]
        public async Task<IActionResult> ConfirmEmail([FromBody] UserForConfirmEmail userForConfirmEmailDto)
        {

            var result = await _service.AuthenticationService.ConfirmEmail(userForConfirmEmailDto);

            return result.Map(
                onSuccess: result =>
                {
                    var identityResult = result.GetValue<IdentityResult>();
                    if (!identityResult.Succeeded) return identityResult.InvalidResult();

                    return Ok();
                },
                onFailure: ProcessError
                );
        }

        [HttpPost("confirm-phone")]
        public async Task<IActionResult> ConfirmPhone()
        {
            throw new NotImplementedException();
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassowrd([FromBody] UserForForgotPasswordDto userForForgotPasswordDto)
        {
            var resultUrl = await _service.AuthenticationService.CreateForgotPasswordUrl(userForForgotPasswordDto.Email!);

            if (!resultUrl.IsSuccess)
                return ProcessError(resultUrl);

            var url = resultUrl.GetValue<string>();

           await _service.MailService.SendForgotPasswordEmail(userForForgotPasswordDto.Email!, url).ConfigureAwait(false);
            return Ok() ;
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassowrd([FromBody] UserForResetPasswordDto userForResetPasswordDto)
        {
            var result = await _service.AuthenticationService.ResetPassword(userForResetPasswordDto);

            return result.Map(
                onSuccess: result =>
                {
                    var identityResult = result.GetValue<IdentityResult>();
                    if (!identityResult.Succeeded) return identityResult.InvalidResult();

                    return Ok();
                },
                onFailure: ProcessError
                );
        }

        [HttpPost("change-password")]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] UserForChangePasswordDto userForChangePasswordDto)
        {
            var username = HttpContext.User.Identity!.Name;
            var result = await _service.AuthenticationService.ChangePassword(username!, userForChangePasswordDto);

            return result.Map(
                onSuccess: result =>
                {
                    var identityResult = result.GetValue<IdentityResult>();
                    if (!identityResult.Succeeded) return identityResult.InvalidResult();

                    return Ok();
                },
                onFailure: ProcessError
                );
        }
    }
}
