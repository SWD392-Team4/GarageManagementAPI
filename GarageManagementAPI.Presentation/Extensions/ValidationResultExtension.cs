using FluentValidation.Results;
using GarageManagementAPI.Shared.ErrorModel;
using GarageManagementAPI.Shared.ResultModel;
using Microsoft.AspNetCore.Mvc;

namespace GarageManagementAPI.Presentation.Extensions
{
    public static class ValidationResultExtension
    {
        public static Task<IActionResult> InvalidResult(this ValidationResult validationResult)
        {
            var errors = validationResult.Errors
                    .Select(ms =>
                        new ErrorsResult()
                        {
                            Code = ms.ErrorCode,
                            Description = ms.ErrorMessage,
                        }
                    ).ToList();

            var errorResult = Result.BadRequest(errors);
            return Task.FromResult<IActionResult>(new BadRequestObjectResult(errorResult));
        }
    }
}
