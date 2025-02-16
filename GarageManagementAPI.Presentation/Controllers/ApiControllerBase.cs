using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.ResultModel;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GarageManagementAPI.Presentation.Controllers
{
    public class ApiControllerBase : ControllerBase
    {
        protected readonly IServiceManager _service;
        public ApiControllerBase(IServiceManager service)
        {
            _service = service;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult ProcessError(Result result)
        {

            return result.StatusCode switch
            {
                HttpStatusCode.NotFound => NotFound(result),
                HttpStatusCode.BadRequest => BadRequest(result),
                HttpStatusCode.Unauthorized => Unauthorized(result)
                ,
                _ => throw new NotImplementedException()
            };
        }
    }
}
