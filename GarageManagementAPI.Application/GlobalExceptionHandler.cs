using Microsoft.AspNetCore.Diagnostics;
using GarageManagementAPI.Shared.ErrorModel;
using GarageManagementAPI.Shared.ResultModel;
using System.Net;
using Microsoft.IdentityModel.Tokens;
using GarageManagementAPI.Entities.Exceptions.NotFound;
using GarageManagementAPI.Shared.Constant.Request;

namespace GarageManagementAPI.Application
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            httpContext.Response.ContentType = "application/json";

            var contextFeature = httpContext.Features.Get<IExceptionHandlerFeature>();
            if (contextFeature != null)
            {
                var code = "UNKNOWN";
                var message = "Unknown error occurred.";

                switch (contextFeature.Error)
                {

                    case SecurityTokenExpiredException ex:
                        httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        code = nameof(RequestErrors.AccessTokenExpired);
                        message = RequestErrors.AccessTokenExpired;
                        break;

                    default:
                        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        message = contextFeature.Error.Message;
                        break;
                }
                var errors = new ErrorsResult()
                {
                    Code = code,
                    Description = message,
                };

                await httpContext.Response.WriteAsync(
                    Result.Failure(HttpStatusCode.InternalServerError, [errors])
                    .ToString());
            }

            return true;
        }
    }
}
