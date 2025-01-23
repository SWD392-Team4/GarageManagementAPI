using Microsoft.AspNetCore.Diagnostics;
using GarageManagementAPI.Shared.ErrorModel;
using GarageManagementAPI.Shared.ResultModel;
using System.Net;

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

                httpContext.Response.StatusCode = contextFeature.Error switch
                {
                    _ => StatusCodes.Status500InternalServerError
                };

                var message = contextFeature.Error.Message;
                var errors = new ErrorsResult()
                {
                    Code = "UNKNOWN",
                    Description = message ?? "Unknown error occurred.",
                };

                await httpContext.Response.WriteAsync(
                    Result.Failure(HttpStatusCode.InternalServerError, [errors])
                    .ToString());
            }

            return true;
        }
    }
}
