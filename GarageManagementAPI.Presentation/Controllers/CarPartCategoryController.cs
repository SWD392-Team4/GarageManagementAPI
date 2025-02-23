using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Presentation.Extensions;
using GarageManagementAPI.Shared.DataTransferObjects.CarPartCategory;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/carpart/category")]
    [ApiController]
    public class CarPartCategoryController : ApiControllerBase
    {


        public CarPartCategoryController(IServiceManager service) : base(service)
        {
        }

        /// <summary>
        /// Get all car part caterory
        /// </summary>
        /// <param name="carPartCategoryParameters"></param>
        /// <returns></returns>
        [HttpGet]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetCarPartCategoriess([FromQuery] CarPartCategoryParameters carPartCategoryParameters)
        {
            var CarPartCategoryResult = await _service.CarPartCategoryService.GetCarPartCategoriesAsync(carPartCategoryParameters, trackChanges: false);

            return CarPartCategoryResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }
        /// <summary>
        /// Get car part caterogy by id
        /// </summary>
        /// <param name="carPartCategoryId"></param>
        /// <returns></returns>
        [HttpGet("{carPartCategoryId:guid}", Name = "GetCarPartCategoryById")]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetCarPartCategoryById(Guid carPartCategoryId)
        {
            var CarPartCategoryResult = await _service.CarPartCategoryService.GetCarPartCategoryAsync(carPartCategoryId, trackChanges: false);

            return CarPartCategoryResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        /// <summary>
        /// Create car part category
        /// </summary>
        /// <param name="carPartCategoryDtoForCreation"></param>
        /// <returns></returns>
        [HttpPost(Name = "CreateCarPartCategory")]
        public async Task<IActionResult> CreateCarPartCategory([FromBody] CarPartCategoryDtoForCreation carPartCategoryDtoForCreation)
        {
            var result = await _service.CarPartCategoryService.CreateCarPartCategoryAsync(carPartCategoryDtoForCreation);

            return result.Map(
                onSuccess: result =>
                {
                    var createdCarPartCategory = result.GetValue<CarPartCategoryDto>();

                    return CreatedAtRoute("GetCarPartCategoryById", new { CarPartCategoryId = createdCarPartCategory.Id }, result);
                },
                onFailure: ProcessError
                );
        }

        /// <summary>
        /// Update car part category
        /// </summary>
        /// <param name="carPartCategoryId"></param>
        /// <param name="carPartCategoryDtoForUpdate"></param>
        /// <returns></returns>
        [HttpPut("{carPartCategoryId:guid}")]
        public async Task<IActionResult> UpdateCarPartCategory(Guid carPartCategoryId, [FromBody] CarPartCategoryDtoForUpdate carPartCategoryDtoForUpdate)
        {
            var result = await _service.CarPartCategoryService
                .UpdateCarPartCategory(
                carPartCategoryId,
                carPartCategoryDtoForUpdate,
                 true
                );

            return result.Map(
                 onSuccess: Ok,
                 onFailure: ProcessError
                 );
        }

        /// <summary>
        /// Update car part category by field
        /// </summary>
        /// <param name="carPartCategoryId"></param>
        /// <param name="jsonPatchDocumentDto"></param>
        /// <param name="validator"></param>
        /// <returns></returns>
        [HttpPatch("{carPartCategoryId:guid}")]
        public async Task<IActionResult> PartiallyUpdateCarPartCategory(
    Guid carPartCategoryId,
    [FromBody] JsonPatchDocument<CarPartCategoryDtoForUpdate> jsonPatchDocumentDto,
    [FromServices] IValidator<CarPartCategoryDtoForUpdate> validator)
        {
            // Retrieve the existing CarPartCategory data
            var carPartCategoryDtoForUpdateToPatchResult = await _service.CarPartCategoryService.GetCarPartCategoryForPartiallyUpdate(carPartCategoryId, trackChanges: false);
            if (!carPartCategoryDtoForUpdateToPatchResult.IsSuccess)
                return ProcessError(carPartCategoryDtoForUpdateToPatchResult);

            var carPartCategoryDtoForUpdateToPatch = carPartCategoryDtoForUpdateToPatchResult.GetValue<CarPartCategoryDtoForUpdate>();

            // Apply JSON Patch changes and check for errors
            jsonPatchDocumentDto.ApplyTo(carPartCategoryDtoForUpdateToPatch, ModelState);

            // Validate ModelState after applying the patch
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Validate the updated DTO
            var validationResult = validator.Validate(carPartCategoryDtoForUpdateToPatch);
            if (!validationResult.IsValid)
                return await validationResult.InvalidResult();

            // Update the CarPartCategory
            var result = await _service.CarPartCategoryService.UpdateCarPartCategory(carPartCategoryId, carPartCategoryDtoForUpdateToPatch,  true);

            return result.Map(
                onSuccess: result => NoContent(),
                onFailure: result => ProcessError(result)
            );
        }
    }
}
