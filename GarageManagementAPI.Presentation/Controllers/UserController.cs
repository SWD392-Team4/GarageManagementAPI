
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ApiControllerBase
    {
        public UserController(IServiceManager service) : base(service)
        {
        }

        [HttpGet("info")]
        [Authorize]
        public async Task<IActionResult> GetUserInfo([FromQuery] UserParameters userParameters)
        {
            var userId = HttpContext.User.FindFirstValue("UserId");
            var isCustomer = HttpContext.User.IsInRole(nameof(SystemRole.Customer));
            var include = isCustomer ? "Roles" : "EmployeeInfo,Roles";

            var user = await _service.UserService.GetUserAsync(new Guid(userId!), userParameters, !isCustomer, include);

            return Ok(user);

        }

        [HttpGet("customers")]
        [Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetUsersIsCustomer([FromQuery] UserParameters userParameters)
        {
            var userResult = await _service.UserService.GetUsersAsync(userParameters, trackChanges: false, isEmployee: false, "Roles");

            return userResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpGet("employees")]
        [Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetUsersIsEmployee([FromQuery] UserParameters userParameters)
        {
            var userResult = await _service.UserService.GetUsersAsync(userParameters, trackChanges: false, isEmployee: true, "EmployeeInfo,Roles");

            return userResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }
    }
}
