using GarageManagementAPI.Shared.ErrorModel;
using GarageManagementAPI.Shared.ResultModel;
using Microsoft.AspNetCore.Mvc;

namespace GarageManagementAPI.Presentation.Extensions
{
    //public static class SignInResultExtension
    //{
    //    public static Task<IActionResult> InvalidResult(this SignInResult identityResult)
    //    {
    //        var errors = identityResult.Errors
    //                .Select(ms =>
    //                    new ErrorsResult()
    //                    {
    //                        Code = ms.Code,
    //                        Description = ms.Description,
    //                    }
    //                ).ToList();

    //        var errorResult = Result.BadRequest(errors);
    //        return Task.FromResult<IActionResult>(new BadRequestObjectResult(errorResult));
    //    }
    //}
}
