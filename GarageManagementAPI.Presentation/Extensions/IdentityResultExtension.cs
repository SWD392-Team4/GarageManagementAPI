using GarageManagementAPI.Shared.ErrorModel;
using GarageManagementAPI.Shared.ResultModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GarageManagementAPI.Presentation.Extensions
{
    public static class IdentityResultExtension
    {
        public static IActionResult InvalidResult(this IdentityResult identityResult)
        {
            var errors = identityResult.Errors
                    .Select(ms =>
                        new ErrorsResult()
                        {
                            Code = ms.Code,
                            Description = ms.Description,
                        }
                    ).ToList();

            var errorResult = Result.BadRequest(errors);
            return new BadRequestObjectResult(errorResult);
        }
    }
}
