using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.ServiceImage;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.AspNetCore.Mvc;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/service/images")]
    [ApiController]
    public class ServiceImageController : ApiControllerBase
    {
        public ServiceImageController(IServiceManager service) : base(service)
        {

        }

        [HttpGet("{serviceId:guid}", Name = "GetImageByIdService")]
        public async Task<IActionResult> GetImageByIdService(Guid serviceId, [FromQuery] ServiceImageParameters parameters)
        {
            var serviceImageResult = await _service.ServiceImageService.GetImageByIdService(serviceId, parameters, false);
            return serviceImageResult.Map(
                 onSuccess: Ok,
                onFailure: ProcessError
                );
        }
        [HttpPost("{serviceImageId:guid}", Name = "CreateImage")]
        public async Task<IActionResult> UpdateProductImage(Guid serviceImageId, [FromBody] ServiceImageDtoForUpdate serviceImageDtoforUpdate)
        {
            var serviceImageResult = await _service.ServiceImageService.UpdateServiceImage(serviceImageId, serviceImageDtoforUpdate);
            return serviceImageResult.Map(
                onSuccess: Ok,
               onFailure: ProcessError
               );
        }
    }
}
