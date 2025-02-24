using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Presentation.Extensions;
using GarageManagementAPI.Shared.DataTransferObjects.CarPart;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/car-parts")]
    [ApiController]
    public class CarPartController : ApiControllerBase
    {
        public CarPartController(IServiceManager service) : base(service)
        {
        }
        /// <summary>
        /// Get all car part
        /// </summary>
        /// <param name="carPartParameters"></param>
        /// <returns></returns>
        [HttpGet]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetCarParts([FromQuery] CarPartParameters carPartParameters)
        {
            var CarPartResult = await _service.CarPartService.GetCarPartsAsync(carPartParameters, trackChanges: false);

            return CarPartResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }
        /// <summary>
        /// Get car part by id
        /// </summary>
        /// <param name="carPartId"></param>
        /// <returns></returns>
        [HttpGet("{carPartId:guid}", Name = "GetCarPartById")]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetCarPartById(Guid carPartId, [FromQuery] CarPartParameters carPartParameters)
        {
            var CarPartResult = await _service.CarPartService.GetCarPartAsync(carPartId, carPartParameters, trackChanges: false);

            return CarPartResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        /// <summary>
        /// Create car part
        /// </summary>
        /// <param name="carPartDtoForCreation"></param>
        /// <returns></returns>
        [HttpPost(Name = "CreateCarPart")]
        public async Task<IActionResult> CreateCarPart([FromBody] CarPartDtoForCreation carPartDtoForCreation)
        {
            var result = await _service.CarPartService.CreateCarPartAsync(carPartDtoForCreation);

            return result.Map(
                onSuccess: result =>
                {
                    var createdCarPart = result.GetValue<CarPartDto>();

                    return CreatedAtRoute("GetCarPartById", new { CarPartId = createdCarPart.Id }, result);
                },
                onFailure: ProcessError
                );
        }

        /// <summary>
        /// Update car part
        /// </summary>
        /// <param name="carPartId"></param>
        /// <param name="carPartDtoForUpdate"></param>
        /// <returns></returns>
        [HttpPut("{carPartId:guid}")]
        public async Task<IActionResult> UpdateCarPart(Guid carPartId, [FromBody] CarPartDtoForUpdate carPartDtoForUpdate)
        {
            var result = await _service.CarPartService
                .UpdateCarPart(
                carPartId,
                carPartDtoForUpdate,
                trackChanges: true
                );

            return result.Map(
                 onSuccess: Ok,
                 onFailure: ProcessError
                 );
        }
        /// <summary>
        /// Update car part by field
        /// </summary>
        /// <param name="carPartId"></param>
        /// <param name="jsonPatchDocumentDto"></param>
        /// <param name="validator"></param>
        /// <returns></returns>
        [HttpPatch("{carPartId:guid}")]
        public async Task<IActionResult> PartiallyUpdateCarPart(
                                             Guid carPartId,
                                             [FromBody] JsonPatchDocument<CarPartDtoForUpdate> jsonPatchDocumentDto,
                                              [FromServices] IValidator<CarPartDtoForUpdate> validator)
        {
            // Retrieve the existing CarPart data
            var CarPartDtoForUpdateToPatchResult = await _service.CarPartService.GetCarPartForPartiallyUpdate(carPartId, trackChanges: false);
            if (!CarPartDtoForUpdateToPatchResult.IsSuccess)
                return ProcessError(CarPartDtoForUpdateToPatchResult);

            var CarPartDtoForUpdateToPatch = CarPartDtoForUpdateToPatchResult.GetValue<CarPartDtoForUpdate>();

            // Apply JSON Patch changes and check for errors
            jsonPatchDocumentDto.ApplyTo(CarPartDtoForUpdateToPatch, ModelState);

            // Validate ModelState after applying the patch
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Validate the updated DTO
            var validationResult = validator.Validate(CarPartDtoForUpdateToPatch);
            if (!validationResult.IsValid)
                return await validationResult.InvalidResult();

            var result = await _service.CarPartService.UpdateCarPart(carPartId, CarPartDtoForUpdateToPatch, trackChanges: true);

            return result.Map(
                onSuccess: result => NoContent(),
                onFailure: result => ProcessError(result)
            );
        }
    }
}
