using GarageManagementAPI.Presentation.Extensions;
using GarageManagementAPI.Shared.ErrorModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GarageManagementAPI.Presentation.ActionFilters
{
    public class ValidationFilterAttribute : IActionFilter
    {
        public ValidationFilterAttribute()
        { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var method = context.HttpContext.Request.Method;
            if (method.Equals("POST") || method.Equals("PUT"))
            {

                var param = context.ActionArguments
                    .SingleOrDefault(x =>
                    x!.Value!.ToString()!.Contains("Dto")).Value;

                if (param is null)
                {
                    context.Result = new BadRequestObjectResult(new ErrorDetails()
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Message = "Invalid request, object is null."
                    });
                    return;
                }

                if (!context.ModelState.IsValid)
                    context.Result = context.ModelState.InvalidModelSate();
            }

        }
    }
}
