using GarageManagementAPI.Presentation.Extensions;
using GarageManagementAPI.Shared.Constant.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using GarageManagementAPI.Shared.ResultModel;

namespace GarageManagementAPI.Presentation.ActionFilters
{
    public class ValidationFilterAttribute : IActionFilter
    {
        public ValidationFilterAttribute()
        { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public async void OnActionExecuting(ActionExecutingContext context)
        {
            var method = context.HttpContext.Request.Method;
            if (method.Equals("POST") || method.Equals("PUT") || method.Equals("PATCH"))
            {

                var param = context.ActionArguments
                    .SingleOrDefault(x =>
                    x!.Key!.ToString()!.Contains("Dto")).Value;

                if (param is null)
                {

                    context.Result = new BadRequestObjectResult(Result.BadRequest([RequestErrors.GetInvalidInputError(nameof(param))]));
                    return;
                }

                if (!context.ModelState.IsValid)
                    context.Result = await context.ModelState.InvalidModelSate();
            }

        }
    }
}
