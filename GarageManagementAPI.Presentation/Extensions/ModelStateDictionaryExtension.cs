using GarageManagementAPI.Shared.ErrorModel;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using GarageManagementAPI.Shared.ResultModel;
using System.Net;

namespace GarageManagementAPI.Presentation.Extensions
{
    public static class ModelStateDictionaryExtension
    {
        public static Task<IActionResult> InvalidModelSate(this ModelStateDictionary modelState)
        {
            var errors = modelState
                .Where(ms => ms.Value!.Errors.Any())
                .Select(ms => new ErrorsResult
                {
                    Code = ms.Key,
                    Description = string.Join(Environment.NewLine, ms.Value!.Errors.Select(e => e.ErrorMessage))
                }).ToList();
            var errorResult = Result.Failure(HttpStatusCode.UnprocessableEntity, errors);
            return Task.FromResult<IActionResult>(new UnprocessableEntityObjectResult(errorResult));
        }
    }
}
