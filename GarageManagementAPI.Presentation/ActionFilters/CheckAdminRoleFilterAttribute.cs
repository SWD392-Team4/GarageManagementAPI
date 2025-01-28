using GarageManagementAPI.Shared.DataTransferObjects.User;
using GarageManagementAPI.Shared.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace GarageManagementAPI.Presentation.ActionFilters
{
    public class CheckAdminRoleFilterAttribute : IActionFilter
    {
        public CheckAdminRoleFilterAttribute()
        {
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var userRole = context.HttpContext.User.Claims
            .FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            var request = context.ActionArguments["userForRegistrationDto"] as UserForRegistrationDto;

            if (request != null && request.Role.Equals(SystemRole.Customer.ToString()) && userRole.Equals(SystemRole.Administrator.ToString()))
            {
                context.Result = new ForbidResult("You are not authorized to create users with this role.");

                return;
            }

        }
    }
}
