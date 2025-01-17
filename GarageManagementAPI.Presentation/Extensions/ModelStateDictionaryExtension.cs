using GarageManagementAPI.Shared.ErrorModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;

namespace GarageManagementAPI.Presentation.Extensions
{
    public static class ModelStateDictionaryExtension
    {
        public static IActionResult InvalidModelSate(this ModelStateDictionary modelState)
        {
            var errors = modelState
            .Where(ms => ms.Value!.Errors.Count > 0)
            .SelectMany(ms =>
                ms.Value!.Errors.Select(e => e.ErrorMessage)
            ).ToList();

            return new UnprocessableEntityObjectResult(new ErrorDetails
            {
                StatusCode = StatusCodes.Status422UnprocessableEntity,
                Message = string.Join(Environment.NewLine, errors)
            });
        }
    }
}
