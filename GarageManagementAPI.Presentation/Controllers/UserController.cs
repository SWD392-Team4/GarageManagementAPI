
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.Constant.Authentication;
using GarageManagementAPI.Shared.DataTransferObjects.EmployeeSchedule;
using GarageManagementAPI.Shared.DataTransferObjects.User;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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


        [HttpGet("customers/{userId:guid}")]
        [Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetUsersIsCustomerById(Guid userId, [FromQuery] UserParameters userParameters)
        {
            var userResult = await _service.UserService.GetUserAsync(userId, userParameters, trackChanges: false, "Roles");

            return userResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }


        [HttpGet("employees/{userId:guid}")]
        [Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetUsersIsEmployeeById(Guid userId, [FromQuery] UserParameters userParameters)
        {
            var userResult = await _service.UserService.GetUserAsync(userId, userParameters, trackChanges: false, "EmployeeInfo,Roles");

            return userResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
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

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateUserInfo([FromBody] UserForUpdateDto userForUpdateDto)
        {
            var contextUserId = new Guid(HttpContext.User.FindFirstValue("UserId")!);
            var updateResult = await _service.UserService.UpdateUserAsync(contextUserId, userForUpdateDto, true);

            return updateResult.Map(
                onSuccess: _ => NoContent(),
                onFailure: ProcessError
                );
        }

        [HttpPut("{userId:guid}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> UpdateEmployeeInfo(Guid userId, [FromBody] UserForUpdateEmployeeDto userForUpdateEmployeeDto)
        {
            var updateResult = await _service.UserService.UpdateEmployeeAsync(userId, userForUpdateEmployeeDto, true);

            return updateResult.Map(
                onSuccess: _ => NoContent(),
                onFailure: ProcessError
                );
        }

        [HttpPost("{userId:guid}/image")]
        [Authorize]
        public async Task<IActionResult> UpdateUserImageAsync(Guid userId, [FromForm] IFormFile fileDto)
        {
            var contextUserId = new Guid(HttpContext.User.FindFirstValue("UserId")!);
            var isAdmin = HttpContext.User.IsInRole(nameof(SystemRole.Administrator));

            if (contextUserId != userId && !isAdmin)
                return new ObjectResult(
                         Result.Forbidden(
                         [UserErrors.GetUnAuthorizedToUpdateUserImageErrors()]))
                {
                    StatusCode = StatusCodes.Status403Forbidden
                };

            var uploadFileResult = await _service.MediaService.UploadUserImageAsync(fileDto);

            if (!uploadFileResult.IsSuccess)
                return ProcessError(uploadFileResult);

            var imgTuple = uploadFileResult.GetValue<(string? publicId, string? absoluteUrl)>();

            var updateResult = await _service.UserService.UpdateUserImageAsync(userId, true, imgTuple.publicId!, imgTuple.absoluteUrl!);

            if (!updateResult.IsSuccess)
                return ProcessError(updateResult);

            var oldImageId = updateResult.GetValue<string?>();

            if (oldImageId is null)
                return NoContent();

            var removeResult = await _service.MediaService.RemoveImage(oldImageId);

            return removeResult.Map(
                onSuccess: _ => NoContent(),
                onFailure: ProcessError
                );
        }

        [HttpGet("{userId:guid}/schedule")]
        public async Task<IActionResult> GetEmployeeSchedule(Guid userId, [FromQuery] EmployeeScheduleParameters employeeScheduleParameters)
        {
            var employeeScheduleResult = await _service.EmployeeScheduleService.GetEmployeeSchedulesAsync(userId, employeeScheduleParameters, false);
            return employeeScheduleResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpGet("my-schedule")]
        [Authorize]
        public async Task<IActionResult> GetMyEmployeeSchedule([FromQuery] EmployeeScheduleParameters employeeScheduleParameters)
        {
            var userId = new Guid(HttpContext.User.FindFirstValue("UserId")!);
            var employeeScheduleResult = await _service.EmployeeScheduleService.GetEmployeeSchedulesAsync(userId, employeeScheduleParameters, false);
            return employeeScheduleResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpPost("schedule/{scheduleId:guid}/start")]
        public async Task<IActionResult> StartEmployeeSchedule(Guid scheduleId, EmployeeScheduleDtoForStart employeeScheduleDtoForStart)
        {
            var startResult = await _service.EmployeeScheduleService.StartEmployeeScheduleAsync(scheduleId, employeeScheduleDtoForStart);
            return startResult.Map(
                onSuccess: _ => NoContent(),
                onFailure: ProcessError
                );
        }

        [HttpPost("schedule/{scheduleId:guid}/end")]
        public async Task<IActionResult> EndEmployeeSchedule(Guid scheduleId)
        {
            var endResult = await _service.EmployeeScheduleService.EndEmployeeScheduleAsync(scheduleId);
            return endResult.Map(
                onSuccess: _ => NoContent(),
                onFailure: ProcessError
                );
        }
    }
}
