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
using Microsoft.AspNetCore.RateLimiting;

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
            var result = await _service.AuthenticationService.RegisterUser(userForRegistrationDto, SystemRole.Customer, userForRegistrationDto.Password!);

            if (!result.IsSuccess)
            {
                return ProcessError(result);
            }

            var resultUrl = await _service.AuthenticationService.CreateConfirmEmailUrl(userForRegistrationDto.Email!);

            var url = resultUrl.GetValue<string>();

            await _service.MailService.SendConfirmEmailEmail(userForRegistrationDto.Email!, url).ConfigureAwait(false);

            return Created();
        }

        [HttpPost("register-employee")]
        [Authorize(Roles = nameof(SystemRole.Administrator))]
        public async Task<IActionResult> RegisterEmployee([FromBody] UserForRegistrationEmployeeDto userForRegistrationEmployeeDto)
        {
            if (userForRegistrationEmployeeDto.Role == SystemRole.Administrator)
            {
                return new ObjectResult(
                        Result.Forbidden(
                        [UserErrors.GetUnAuthorizedToCreateUserErrors()]))
                {
                    StatusCode = StatusCodes.Status403Forbidden
                };
            }

            if (userForRegistrationEmployeeDto.Role == SystemRole.Customer)
            {
                return new BadRequestObjectResult(
                                        Result.Forbidden(
                                        [UserErrors.GetInvalidEndpointError()]));
            }

            userForRegistrationEmployeeDto.Password = _service.AuthenticationService.GenerateRandomPassword(10);
            userForRegistrationEmployeeDto.UserName = _service.AuthenticationService.GenerateUserName(userForRegistrationEmployeeDto.FirstName!, userForRegistrationEmployeeDto.LastName!);

            var resultRegsiterUser = await _service.AuthenticationService.RegisterEmployeeInfo(userForRegistrationEmployeeDto, userForRegistrationEmployeeDto.Role, userForRegistrationEmployeeDto.Password!);

            if (!resultRegsiterUser.IsSuccess)
            {
                return ProcessError(resultRegsiterUser);
            }

            var resultUrl = await _service.AuthenticationService.CreateConfirmEmailUrl(userForRegistrationEmployeeDto.Email!);

            var url = resultUrl.GetValue<string>();

            await _service.MailService.SendConfirmEmailEmployeeEmail(userForRegistrationEmployeeDto, url).ConfigureAwait(false);

            return Created();
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] UserForAuthenticationDto userForAuthenticationDto)
        {
            var result = await _service.AuthenticationService.ValidateUser(userForAuthenticationDto);

            if (!result.IsSuccess)
                return ProcessError(result);

            var tokenDto = await _service.AuthenticationService
                .CreateToken(populateExp: true);

            return tokenDto.Map(
                onSuccess: result => Ok(result),
                onFailure: result => ProcessError(result));
        }


        [HttpPost("resend-confirm-email")]
        [EnableRateLimiting("SendMailConfirmEmailPolicy")]
        public async Task<IActionResult> ResendConfirmEmail([FromBody] UserForResendConfirmEmailDto resendConfirmEmailDto)
        {

            var resultUrl = await _service.AuthenticationService.CreateConfirmEmailUrl(resendConfirmEmailDto.Email!);

            if (!resultUrl.IsSuccess)
                return ProcessError(resultUrl);

            var url = resultUrl.GetValue<string>();

            await _service.MailService.SendConfirmEmailEmail(resendConfirmEmailDto.Email!, url).ConfigureAwait(false);

            return Ok();
        }

        [HttpPost("confirm-email")]
        public async Task<IActionResult> ConfirmEmail([FromBody] UserForConfirmEmail userForConfirmEmailDto)
        {

            var result = await _service.AuthenticationService.ConfirmEmail(userForConfirmEmailDto);

            return result.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpPost("confirm-phone")]
        public async Task<IActionResult> ConfirmPhone()
        {
            throw new NotImplementedException();
        }

        [HttpPost("forgot-password")]
        [EnableRateLimiting("SendMailForgotPasswordPolicy")]
        public async Task<IActionResult> ForgotPassowrd([FromBody] UserForForgotPasswordDto userForForgotPasswordDto)
        {
            var resultUrl = await _service.AuthenticationService.CreateForgotPasswordUrl(userForForgotPasswordDto.Email!);

            if (!resultUrl.IsSuccess)
                return ProcessError(resultUrl);

            var url = resultUrl.GetValue<string>();

            await _service.MailService.SendForgotPasswordEmail(userForForgotPasswordDto.Email!, url).ConfigureAwait(false);
            return Ok();
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassowrd([FromBody] UserForResetPasswordDto userForResetPasswordDto)
        {
            var result = await _service.AuthenticationService.ResetPassword(userForResetPasswordDto);

            return result.Map(
                onSuccess: Ok,
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
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] TokenDto tokenDto)
        {
            var result = await _service.AuthenticationService.RefreshToken(tokenDto);

            return result.Map(
               onSuccess: result => Ok(result),
               onFailure: result => ProcessError(result));
        }
    }
}
