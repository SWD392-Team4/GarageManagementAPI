using GarageManagementAPI.Presentation.Extensions;
using GarageManagementAPI.Shared.Constant.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using GarageManagementAPI.Shared.ResultModel;
using FluentValidation;

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

                foreach (var argument in context.ActionArguments.Values)
                {
                    if (argument is null)
                        continue;

                    var validatorType = typeof(IValidator<>).MakeGenericType(argument.GetType());
                    var validator = context.HttpContext.RequestServices.GetService(validatorType) as IValidator;

                    if (validator != null)
                    {
                        var validationResult = await validator.ValidateAsync(new ValidationContext<object>(argument));

                        if (!validationResult.IsValid)
                        {
                            context.Result = await validationResult.InvalidResult();
                            return;
                        }
                    }
                }

                if (!context.ModelState.IsValid)
                    context.Result = await context.ModelState.InvalidModelSate();
            }

        }
    }
}
