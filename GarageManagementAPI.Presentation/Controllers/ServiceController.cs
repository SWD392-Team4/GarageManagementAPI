using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/services")]
    [ApiController]
    public class ServiceController : ApiControllerBase
    {
        public ServiceController(IServiceManager service) : base(service)
        {
        }
        [HttpGet]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetServices([FromQuery] ServiceParameters serviceParameters)
        {
            var ServiceResult = await _service.ServiceService.GetServicesAsync(serviceParameters, trackChanges: false);

            return ServiceResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }
    }
}
