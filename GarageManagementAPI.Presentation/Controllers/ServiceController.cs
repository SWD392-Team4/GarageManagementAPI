using FluentValidation;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.DataTransferObjects.Service;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using GarageManagementAPI.Presentation.Extensions;

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

        [HttpGet("{serviceId:guid}", Name = "GetServiceById")]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetServiceById(Guid serviceId, [FromQuery] ServiceParameters serviceParameters)
        {
            var setviceResult = await _service.ServiceService.GetServiceAsync(serviceId, serviceParameters, trackChanges: false);

            return setviceResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpPost(Name = "CreateService")]
        public async Task<IActionResult> CreateService([FromBody] ServiceDtoForCreation serviceDtoForCreation)
        {
            var result = await _service.ServiceService.CreateServiceAsync(serviceDtoForCreation);

            return result.Map(
                onSuccess: result =>
                {
                    var createdService = result.GetValue<ServiceDto>();

                    return CreatedAtRoute("GetServiceById", new { serviceId = createdService.Id }, result);
                },
                onFailure: ProcessError
                );
        }

        [HttpPut("{serviceId:guid}")]
        public async Task<IActionResult> UpdateBrand(Guid serviceId, [FromBody] ServiceDtoForUpdate serviceDtoForUpdate)
        {
            var result = await _service.ServiceService
                .UpdateService(
                serviceId: serviceId,
                serviceDtoForUpdate: serviceDtoForUpdate,
                trackChanges: true
                );

            return result.Map(
                 onSuccess: Ok,
                 onFailure: ProcessError
                 );
        }

        [HttpPatch("{serviceId:guid}")]
        public async Task<IActionResult> PartiallyUpdateService(
                                                Guid serviceId,
                                                [FromBody] JsonPatchDocument<ServiceDtoForUpdate> jsonPatchDocumentDto,
                                                [FromServices] IValidator<ServiceDtoForUpdate> validator)
        {
            // Retrieve the existing brand data
            var serviceDtoForUpdateToPatchResult = await _service.BrandService.GetBrandForPartiallyUpdate(serviceId, trackChanges: false);
            if (!serviceDtoForUpdateToPatchResult.IsSuccess)
                return ProcessError(serviceDtoForUpdateToPatchResult);

            var serviceDtoForUpdateToPatch = serviceDtoForUpdateToPatchResult.GetValue<ServiceDtoForUpdate>();

            // Apply JSON Patch changes and check for errors
            jsonPatchDocumentDto.ApplyTo(serviceDtoForUpdateToPatch, ModelState);

            // Validate ModelState after applying the patch
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Validate the updated DTO
            var validationResult = validator.Validate(serviceDtoForUpdateToPatch);
            if (!validationResult.IsValid)
                return await validationResult.InvalidResult();

            // Update the brand
            var result = await _service.ServiceService.UpdateService(serviceId, serviceDtoForUpdateToPatch, trackChanges: true);

            return result.Map(
                onSuccess: result => NoContent(),
                onFailure: result => ProcessError(result)
            );
        }
    }
}
