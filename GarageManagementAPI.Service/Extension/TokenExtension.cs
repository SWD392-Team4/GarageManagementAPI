using GarageManagementAPI.Shared.Constant.Request;
using GarageManagementAPI.Shared.ResultModel;

namespace GarageManagementAPI.Service.Extension
{
    public static class TokenExtension
    {
        public static Result<T> InvalidTokenBadRequest<T>(this string str)
            => Result<T>.BadRequest([RequestErrors.GetInvalidTokenError()]);
    }
}
