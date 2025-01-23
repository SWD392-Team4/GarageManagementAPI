using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.User;
using Microsoft.AspNetCore.Mvc;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ApiControllerBase
    {
        public TokenController(IServiceManager service) : base(service)
        {
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
