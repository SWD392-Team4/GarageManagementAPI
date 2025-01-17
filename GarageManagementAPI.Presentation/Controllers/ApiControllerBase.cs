using GarageManagementAPI.Shared.ErrorModel;
using GarageManagementAPI.Shared.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GarageManagementAPI.Presentation.Controllers
{
    public class ApiControllerBase : ControllerBase
    {
        public Task<IActionResult> ProcessError(ApiBaseResponse baseResponse)
        {
            return baseResponse switch
            {
                ApiNotFoundResponse notFoundResponse => Task.FromResult<IActionResult>(
                    NotFound(new ErrorDetails
                    {
                        Message = notFoundResponse.Message,
                        StatusCode = StatusCodes.Status404NotFound
                    })
                ),
                ApiBadRequestResponse badRequestResponse => Task.FromResult<IActionResult>(
                    BadRequest(new ErrorDetails
                    {
                        Message = badRequestResponse.Message,
                        StatusCode = StatusCodes.Status400BadRequest
                    })
                ),
                _ => throw new NotImplementedException()
            };
        }
    }
}
