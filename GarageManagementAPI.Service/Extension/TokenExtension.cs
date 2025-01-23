using GarageManagementAPI.Shared.Constant.Request;
using GarageManagementAPI.Shared.ResultModel;

namespace GarageManagementAPI.Service.Extension
{
    public static class TokenExtension
    {
        public static Result InvalidTokenBadRequest(this string str)
            => Result.BadRequest([RequestErrors.GetInvalidTokenError()]);
    }
}
