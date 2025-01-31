using FluentValidation;
using GarageManagementAPI.Presentation.ActionFilters;
using GarageManagementAPI.Presentation.Extensions;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.Constant.Authentication;
using GarageManagementAPI.Shared.DataTransferObjects;
using GarageManagementAPI.Shared.DataTransferObjects.User;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.ResultModel;
using Microsoft.AspNetCore.Http;
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
                        Result.Failure(HttpStatusCode.Forbidden,
                        [UserErrors.GetUnAuthorizedToCreateUserErrors()]))
                {
                    StatusCode = StatusCodes.Status403Forbidden
                };
            }


            var result = await _service.AuthenticationService.RegisterUser(userForRegistrationDto);

            if (!result.Succeeded)
            {
                return await result.InvalidResult();
            }

            return Created();
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] UserForAuthenticationDto userForAuthenticationDto)
        {
            if (!await _service.AuthenticationService.ValidateUser(userForAuthenticationDto))
                return Unauthorized();

            var tokenDto = await _service.AuthenticationService
                .CreateToken(populateExp: true);

            return tokenDto.Map(
                onSuccess: result => Ok(result),
                onFailure: result => ProcessError(result));
        }

        [HttpPost("confirm")]
        public async Task<IActionResult> ConfirmAccount()
        {

            throw new NotImplementedException();
        }

        [HttpPost("confirm-email")]
        public async Task<IActionResult> ConfirmEmail()
        {

            throw new NotImplementedException();
        }

        [HttpPost("confirm-phone")]
        public async Task<IActionResult> ConfirmPhone()
        {
            throw new NotImplementedException();
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassowrd([FromBody] UserForForgotPasswordDto userForForgotPasswordDto)
        {
            var resultUrl = await _service.AuthenticationService.ForgotPassword(userForForgotPasswordDto);

            if (!resultUrl.IsSuccess)
                return ProcessError(resultUrl);

            return Ok(resultUrl);
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassowrd()
        {
            throw new NotImplementedException();
        }
    }
}
