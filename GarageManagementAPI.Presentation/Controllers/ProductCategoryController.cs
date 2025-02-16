using FluentValidation;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.ProductCategory;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Presentation.Extensions;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/product/categories")]
    [ApiController]
    public class ProductCategoryController : ApiControllerBase
    {
        public ProductCategoryController(IServiceManager service) : base(service)
        {
        }

        [HttpGet]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetProductCategories([FromQuery] ProductCategoryParameters productCategoryParameters)
        {
            var productCategoryResult = await _service.ProductCategoryService.GetProductCategoriesAsync(productCategoryParameters, trackChanges: false);

            return productCategoryResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }
        [HttpGet("{productCategoryId:guid}", Name = "GetProductCategoryById")]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetProductCategoryById(Guid productCategoryId, [FromQuery] ProductCategoryParameters productCategoryParameters)
        {
            var productCategoryResult = await _service.ProductCategoryService.GetProductCategoryByIdAsync(productCategoryId, productCategoryParameters, trackChanges: false);

            return productCategoryResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpGet("products/{productCategoryId:guid}", Name = "GetProductByIdCategory")]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetProductByIdCategory(Guid productCategoryId)
        {
            var include = "Products";
            var productsResult = await _service.ProductCategoryService.GetProductsByIdCategoryAsync(productCategoryId, trackChanges: false, include);

            return productsResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpPost(Name = "CreateProductCategory")]
        public async Task<IActionResult> CreateProductCategory([FromBody] ProductCategoryDtoForCreation productCategoryDtoForCreation)
        {
            var result = await _service.ProductCategoryService.CreateProductCategoryAsync(productCategoryDtoForCreation);

            return result.Map(
                onSuccess: result =>
                {
                    var createdProductCategory = result.GetValue<ProductCategoryDto>();

                    return CreatedAtRoute("GetProductCategoryById", new { ProductCategoryId = createdProductCategory.Id }, result);
                },
                onFailure: ProcessError
                );
        }

        [HttpPut("{ProductCategoryId:guid}")]
        public async Task<IActionResult> UpdateProductCategory(Guid productCategoryId, [FromBody] ProductCategoryDtoForUpdate productCategoryDtoForUpdate)
        {
            var result = await _service.ProductCategoryService
                .UpdateProductCategory(
                productCategoryId,
                productCategoryDtoForUpdate,
                trackChanges: true
                );

            return result.Map(
                 onSuccess: Ok,
                 onFailure: ProcessError
                 );
        }

        [HttpPatch("{ProductCategoryId:guid}")]
        public async Task<IActionResult> PartiallyUpdateProductCategory(
    Guid ProductCategoryId,
    [FromBody] JsonPatchDocument<ProductCategoryDtoForUpdate> jsonPatchDocumentDto,
    [FromServices] IValidator<ProductCategoryDtoForUpdate> validator)
        {
            // Retrieve the existing ProductCategory data
            var productCategoryDtoForUpdateToPatchResult = await _service.ProductCategoryService.GetProductCategoryForPartiallyUpdate(ProductCategoryId, trackChanges: false);
            if (!productCategoryDtoForUpdateToPatchResult.IsSuccess)
                return ProcessError(productCategoryDtoForUpdateToPatchResult);

            var productCategoryDtoForUpdateToPatch = productCategoryDtoForUpdateToPatchResult.GetValue<ProductCategoryDtoForUpdate>();

            // Apply JSON Patch changes and check for errors
            jsonPatchDocumentDto.ApplyTo(productCategoryDtoForUpdateToPatch, ModelState);

            // Validate ModelState after applying the patch
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Validate the updated DTO
            var validationResult = validator.Validate(productCategoryDtoForUpdateToPatch);
            if (!validationResult.IsValid)
                return await validationResult.InvalidResult();

            // Update the ProductCategory
            var result = await _service.ProductCategoryService.UpdateProductCategory(ProductCategoryId, productCategoryDtoForUpdateToPatch, trackChanges: true);

            return result.Map(
                onSuccess: result => NoContent(),
                onFailure: result => ProcessError(result)
            );
        }
    }
}
