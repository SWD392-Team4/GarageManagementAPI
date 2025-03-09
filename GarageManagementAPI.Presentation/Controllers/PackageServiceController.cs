using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.PackageDetail;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.AspNetCore.Mvc;

namespace GarageManagementAPI.Presentation.Controllers
{
    [ApiController]
    public class PackageServiceController : ApiControllerBase
    {
        public PackageServiceController(IServiceManager service) : base(service)
        {
        }

        [HttpGet("api/packages/{packageId:guid}/services")]
        public async Task<IActionResult> GetServicesOfPackage(Guid packageId, [FromQuery] ServiceParameters serviceParameters)
        {
            var result = await _service.PackageService.GetServiceOfPackageAsync(packageId, serviceParameters);

            return result.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }


        [HttpGet("api/services/{serviceId:guid}/packages")]
        public async Task<IActionResult> GetPackagesOfService(Guid serviceId, [FromQuery] PackageParameters packageParameters)
        {
            var result = await _service.ServiceService.GetPackgeOfServiceAsync(serviceId, packageParameters);

            return result.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

    }
}
