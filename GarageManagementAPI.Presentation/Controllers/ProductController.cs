using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.DataTransferObjects.Product;
using Microsoft.AspNetCore.Mvc;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.Enums;
using Microsoft.AspNetCore.Authorization;
using FluentValidation;
using Microsoft.AspNetCore.JsonPatch;
using GarageManagementAPI.Presentation.Extensions;


namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ApiControllerBase
    {
        public ProductController(IServiceManager service) : base(service)
        {
        }

        [HttpGet("product/{productId:guid}", Name = "GetProductById")]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetProductById(Guid productId, [FromQuery] ProductParameters productParameters)
        {
            var productResult = await _service.ProductService.GetProductAsync(productId, productParameters, trackChanges: false);

            return productResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpGet("barcode/{barcode}", Name = "GetProductBarcode")]
        [Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetProductByBarcode(string barcode, [FromQuery] ProductParameters productParameters)
        {
            var productResult = await _service.ProductService.GetProductByBarcode1Async(barcode, productParameters, trackChanges: false);

            return productResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpGet]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetProducts([FromQuery] ProductParameters productParameters)
        {
            var isInclude = "ProductHistories"; 
            var productResult = await _service.ProductService.GetProductsAsync(productParameters, trackChanges: false, isInclude);

            return productResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpPost(Name = "CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDtoForCreation productDtoForCreation)
        {
            var result = await _service.ProductService.CreateProductAsync(productDtoForCreation);

            return result.Map(
                onSuccess: result =>
                {
                    var createdProduct = result.GetValue<ProductDto>();

                    return CreatedAtRoute("GetProductById", new { productId = createdProduct.Id }, result);
                },
                onFailure: ProcessError
                );
        }

        [HttpPut("{productId:guid}")]
        public async Task<IActionResult> UpdateProduct(Guid productId, [FromBody] ProductDtoForUpdate prductDtoForUpdate)
        {
            var result = await _service.ProductService
                .UpdateProduct(
                productId,
                prductDtoForUpdate,
                trackChanges: true
                );

            return result.Map(
                 onSuccess: Ok,
                 onFailure: ProcessError
                 );
        }

        [HttpPatch("{productId:guid}")]
        public async Task<IActionResult> PartiallyUpdateProduct(Guid productId, [FromBody] JsonPatchDocument<ProductDtoForUpdate> jsonPatchDocumentDto, IValidator<ProductDtoForUpdate> validator)
        {
            var productDtoForUpdateToPatchResult = await _service.ProductService.GetProductForPartiallyUpdate(productId, false);

            if (!productDtoForUpdateToPatchResult.IsSuccess)
                return ProcessError(productDtoForUpdateToPatchResult);

            var productDtoForUpdateToPatch = productDtoForUpdateToPatchResult.GetValue<ProductDtoForUpdate>();

            jsonPatchDocumentDto.ApplyTo(productDtoForUpdateToPatch, ModelState);

            var validationResult = validator.Validate(productDtoForUpdateToPatch);
            if (!validationResult.IsValid)
                return await validationResult.InvalidResult();

            var result = await _service.ProductService
                .UpdateProduct(
                productId,
                productDtoForUpdateToPatch,
                trackChanges: true
                );

            return result.Map(
                onSuccess: result => NoContent(),
                onFailure: result => ProcessError(result));
        }

    }
}
