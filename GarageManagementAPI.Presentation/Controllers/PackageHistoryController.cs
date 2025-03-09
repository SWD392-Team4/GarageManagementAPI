using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.AspNetCore.Mvc;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/packages/{packageId:guid}/histories")]
    [ApiController]
    public class PackageHistoryController : ApiControllerBase
    {
        public PackageHistoryController(IServiceManager service) : base(service)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetPackageHistories(Guid packageId, [FromQuery] PackageHistoryParameters packageHistoryParameters)
        {
            var result = await _service.PackageService.GetHistoriesOfPackageAsync(packageId, packageHistoryParameters, false);
            return result.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }
    }
}
