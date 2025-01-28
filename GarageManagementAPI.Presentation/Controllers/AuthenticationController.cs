using FluentValidation;
using GarageManagementAPI.Presentation.ActionFilters;
using GarageManagementAPI.Presentation.Extensions;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.User;
using Microsoft.AspNetCore.Mvc;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ApiControllerBase
    {
        public AuthenticationController(IServiceManager service) : base(service) { }

        [HttpPost("register")]
        [ServiceFilter(typeof(CheckAdminRoleFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistrationDto)
        {
            var result = await _service.AuthenticationService.RegisterUser(userForRegistrationDto, false);

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

    }
}
