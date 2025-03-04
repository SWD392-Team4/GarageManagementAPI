using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using GarageManagementAPI.Shared.Enums;
using Microsoft.AspNetCore.Authorization;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Presentation.Extensions;
using GarageManagementAPI.Shared.DataTransferObjects.Brand;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/brands")]
    [ApiController]
    public class BrandController : ApiControllerBase
    {
        public BrandController(IServiceManager service) : base(service)
        {
        }
        /// <summary>
        /// Get all brands
        /// </summary>
        /// <param name="brandParameters"></param>
        /// <returns></returns>
        [HttpGet]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)}, {nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetBrands([FromQuery] BrandParameters brandParameters)
        {
            var brandResult = await _service.BrandService.GetBrandsAsync(brandParameters, trackChanges: false);

            return brandResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }
        /// <summary>
        /// Get brand by id
        /// </summary>
        /// <param name="brandId"></param>
        /// <param name="brandParameters"></param>
        /// <returns></returns>
        [HttpGet("{brandId:guid}", Name = "GetBrandById")]
        [Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetBrandById(Guid brandId, [FromQuery] BrandParameters brandParameters)
        {
            var brandResult = await _service.BrandService.GetBrandAsync(brandId, brandParameters, trackChanges: false);

            return brandResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        /// <summary>
        /// Create brand
        /// </summary>
        /// <param name="brandDtoForCreation"></param>
        /// <returns></returns>
        [HttpPost(Name = "CreateBrand")]
        public async Task<IActionResult> CreateBrand([FromBody] BrandDtoForCreation brandDtoForCreation)
        {
            var result = await _service.BrandService.CreateBrandAsync(brandDtoForCreation);

            return result.Map(
                onSuccess: result =>
                {
                    var createdBrand = result.GetValue<BrandDto>();

                    return CreatedAtRoute("GetBrandById", new { brandId = createdBrand.Id }, result);
                },
                onFailure: ProcessError
                );
        }

        /// <summary>
        /// Update brand
        /// </summary>
        /// <param name="brandId"></param>
        /// <param name="brandDtoForUpdate"></param>
        /// <returns></returns>
        [Authorize(Roles = $"{nameof(SystemRole.Administrator)}")]
        [HttpPut("{brandId:guid}")]
        public async Task<IActionResult> UpdateBrand(Guid brandId, [FromBody] BrandDtoForUpdate brandDtoForUpdate)
        {
            var result = await _service.BrandService
                .UpdateBrand(
                brandId: brandId,
                brandDtoForUpdate: brandDtoForUpdate,
                trackChanges: true
                );

            return result.Map(
                 onSuccess: Ok,
                 onFailure: ProcessError
                 );
        }
        /// <summary>
        /// Update brand image
        /// </summary>
        /// <param name="brandId"></param>
        /// <param name="fileDto"></param>
        /// <returns></returns>
        [Authorize(Roles = $"{nameof(SystemRole.Administrator)}")]
        [HttpPost("{brandId:guid}/image")]
        public async Task<IActionResult> UpdateBrandImageAsync(Guid brandId, [FromForm] IFormFile fileDto)
        {
            var uploadFileResult = await _service.MediaService.UploadBrandImageAsync(fileDto);

            if (!uploadFileResult.IsSuccess)
                return ProcessError(uploadFileResult);

            var imgTuple = uploadFileResult.GetValue<(string? publicId, string? absoluteUrl)>();

            var updateResult = await _service.BrandService.UpdateBrandImageAsync(brandId, true, imgTuple.publicId!, imgTuple.absoluteUrl!);

            if (!updateResult.IsSuccess)
                return ProcessError(updateResult);

            var oldImageId = updateResult.GetValue<string?>();

            if (oldImageId is null)
                return NoContent();

            var removeResult = await _service.MediaService.RemoveImage(oldImageId);

            return removeResult.Map(
                onSuccess: _ => NoContent(),
                onFailure: ProcessError
                );
        }

        /// <summary>
        /// Update date brand by field
        /// </summary>
        /// <param name="brandId"></param>
        /// <param name="jsonPatchDocumentDto"></param>
        /// <param name="validator"></param>
        /// <returns></returns>
        [HttpPatch("{brandId:guid}")]
        public async Task<IActionResult> PartiallyUpdateBrand(
    Guid brandId,
    [FromBody] JsonPatchDocument<BrandDtoForUpdate> jsonPatchDocumentDto,
    [FromServices] IValidator<BrandDtoForUpdate> validator)
        {
            // Retrieve the existing brand data
            var brandDtoForUpdateToPatchResult = await _service.BrandService.GetBrandForPartiallyUpdate(brandId, trackChanges: false);
            if (!brandDtoForUpdateToPatchResult.IsSuccess)
                return ProcessError(brandDtoForUpdateToPatchResult);

            var brandDtoForUpdateToPatch = brandDtoForUpdateToPatchResult.GetValue<BrandDtoForUpdate>();

            // Apply JSON Patch changes and check for errors
            jsonPatchDocumentDto.ApplyTo(brandDtoForUpdateToPatch, ModelState);

            // Validate ModelState after applying the patch
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Validate the updated DTO
            var validationResult = validator.Validate(brandDtoForUpdateToPatch);
            if (!validationResult.IsValid)
                return await validationResult.InvalidResult();

            // Update the brand
            var result = await _service.BrandService.UpdateBrand(brandId, brandDtoForUpdateToPatch, trackChanges: true);

            return result.Map(
                onSuccess: result => NoContent(),
                onFailure: result => ProcessError(result)
            );
        }
    }
}
