using Microsoft.AspNetCore.Mvc;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/service/histories")]
    [ApiController]
    public class ServiceHistoryController : ApiControllerBase
    {
        public ServiceHistoryController(IServiceManager service) : base(service)
        {
        }
        [HttpGet("{serviceId:guid}", Name = "GetServiceHistoryById")]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetProductById(Guid serviceId, [FromQuery] ServiceHistoryParameters serviceHisotryParameters)
        {
            var productResult = await _service.ServiceHistoryService.GetServiceHistoryByServiceIdAsync(serviceId, serviceHisotryParameters, trackChanges: false);

            return productResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }
    }
}
