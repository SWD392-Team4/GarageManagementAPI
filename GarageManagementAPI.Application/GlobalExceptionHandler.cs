using Microsoft.AspNetCore.Diagnostics;
using GarageManagementAPI.Shared.ErrorModel;
using GarageManagementAPI.Entities.Exceptions.NotFound;

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
                    NotFoundException => StatusCodes.Status404NotFound,
                    _ => StatusCodes.Status500InternalServerError
                };

                var message = "An unexpected error occurred.";

                switch (contextFeature.Error)
                {
                    case NotFoundException ex:
                        httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                        message = ex.Message;
                        break;

                    default:
                        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        break;
                }
                await httpContext.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = httpContext.Response.StatusCode,
                    Message = message
                }.ToString());
            }

            return true;
        }
    }
}
