using GarageManagementAPI.Shared.ErrorModel;
using GarageManagementAPI.Shared.ResultModel;
using Microsoft.AspNetCore.Identity;

namespace GarageManagementAPI.Service.Extension
{
    public static class IdentityResultExtension
    {
        public static Result InvalidResult(this IdentityResult identityResult)
        {
            var errors = identityResult.Errors
                    .Select(ms =>
                        new ErrorsResult()
                        {
                            Code = ms.Code,
                            Description = ms.Description,
                        }
                    ).ToList();

            return Result.BadRequest(errors);
        }
    }
}
