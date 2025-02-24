using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Presentation.Extensions;
using GarageManagementAPI.Shared.DataTransferObjects.Service;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/services")]
    [ApiController]
    public class ServiceController : ApiControllerBase
    {
        public ServiceController(IServiceManager service) : base(service)
        {
        }
        /// <summary>
        /// Get all service
        /// </summary>
        /// <param name="serviceParameters"></param>
        /// <returns></returns>
        [HttpGet]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetServices([FromQuery] ServiceParameters serviceParameters)
        {
            var include = "CarCategory, CarPart";
            var serviceResult = await _service.ServiceService.GetServicesAsync(serviceParameters, trackChanges: false, include);

            return serviceResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        /// <summary>
        /// Get service by id
        /// </summary>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        [HttpGet("{serviceId:guid}", Name = "GetServiceById")]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetServiceById(Guid serviceId)
        {
            var include = "CarCategory, CarPart";
            var setviceResult = await _service.ServiceService.GetServiceAsync(serviceId, trackChanges: false);

            return setviceResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        /// <summary>
        /// Create service
        /// </summary>
        /// <param name="serviceDtoForCreation"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Update service
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="serviceDtoForUpdate"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Update service by field
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="jsonPatchDocumentDto"></param>
        /// <param name="validator"></param>
        /// <returns></returns>
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
