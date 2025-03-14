using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Presentation.Extensions;
using GarageManagementAPI.Shared.DataTransferObjects.Product;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ApiControllerBase
    {
        public ProductController(IServiceManager service) : base(service)
        {
        }
        /// <summary>
        /// Get product by id 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet("product/{productId:guid}", Name = "GetProductById")]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetProductById(Guid productId)
        {
            var isInclude = "Brand,ProductCategory,ProductHistories,ProductImages";
            var productResult = await _service.ProductService.GetProductByIdAsync(productId, trackChanges: false, isInclude);

            return productResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }
        /// <summary>
        /// Get product max price
        /// </summary>
        /// <returns></returns>
        [HttpGet("product/maxprice", Name = "GetProductMaxPrice")]
        public async Task<IActionResult> GetProduct()
        {
            var productResult = await _service.ProductService.GetProductAsync(trackChanges: false);

            return productResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }
        /// <summary>
        /// Get product by barcode
        /// </summary>
        /// <param name="barcode"></param>
        /// <param name="productParameters"></param>
        /// <returns></returns>
        [HttpGet("barcode/{barcode}", Name = "GetProductBarcode")]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetProductByBarcode(string barcode, [FromQuery] ProductParameters productParameters)
        {
            var isInclude = "Brand,ProductCategory,ProductHistories,ProductImages";
            var productResult = await _service.ProductService.GetProductByBarcodeAsync(barcode, productParameters, trackChanges: false, isInclude);

            return productResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        /// <summary>
        /// Get product with warehouse
        /// </summary>
        /// <param name="warehouseId"></param>
        /// <param name="productParameters"></param>
        /// <returns></returns>
        [HttpGet("warehouse/{warehouseId:guid}", Name = "GetProductByWarehouse")]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetProductByWarehouse(Guid warehouseId, [FromQuery] ProductParameters productParameters)
        {
            var productResult = await _service.ProductService.GetProductsByWarehouseIdWithQuantityAsync(warehouseId, trackChanges: false);

            return Ok(productResult);
        }
        /// <summary>
        /// Get all products
        /// </summary>
        /// <param name="productParameters"></param>
        /// <returns></returns>
        [HttpGet]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetProducts([FromQuery] ProductParameters productParameters)
        {
            var isInclude = "Brand,ProductCategory,ProductHistories,ProductImages";
            var productResult = await _service.ProductService.GetProductsAsync(productParameters, trackChanges: false, isInclude);

            return productResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

       
        /// <summary>
        /// Create product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="fileDtos">The list of files to be uploaded with the product.</param>
        /// <returns></returns>
        [HttpPost("{productId:guid}/images", Name = "CreateProductImage")]
        public async Task<IActionResult> CreateProductImage(Guid productId, [FromForm] List<IFormFile> fileDtos)
        {
            var productExists = await _service.ProductService.GetProductByIdAsync(productId, false);
            if (!productExists.IsSuccess) return productExists.Map(onSuccess: Ok,
                                                                   onFailure: ProcessError);
            if (fileDtos == null || !fileDtos.Any())
            {
                return BadRequest("No files were uploaded.");
            }
            var createdProductImages = new List<object>();
            foreach (var fileDto in fileDtos)
            {
                var uploadFileResult = await _service.MediaService.UploadProductImageAsync(fileDto);

                if (!uploadFileResult.IsSuccess) return ProcessError(uploadFileResult);

                var imgTuple = uploadFileResult.GetValue<(string? publicId, string? absoluteUrl)>();

                var updateResult = await _service.ProductImageService.CreateProductImageAsync(productId, imgTuple.publicId!, imgTuple.absoluteUrl!);

                if (!updateResult.IsSuccess) return ProcessError(updateResult);

                createdProductImages.Add(updateResult.Value!.ImageLink);
            }

            return Ok(createdProductImages);
        }
        /// <summary>
        /// Create Product
        /// </summary>
        /// <param name="productDtoForCreation"></param>
        /// <returns></returns>
        [HttpPost(Name = "CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDtoForCreation productDtoForCreation)
        {
            var createProductResult = await _service.ProductService.CreateProductAsync(productDtoForCreation);
            if (!createProductResult.IsSuccess)
            {
                return ProcessError(createProductResult);
            }

            var createdProduct = createProductResult.GetValue<ProductDto>();

            return CreatedAtRoute("GetProductById", new { productId = createdProduct.Id }, createProductResult);
        }

        /// <summary>
        /// Update product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="productDtoForUpdate"></param>
        /// <returns></returns>
        [HttpPut("{productId:guid}")]
        public async Task<IActionResult> UpdateProduct(Guid productId, [FromBody] ProductDtoForUpdate productDtoForUpdate)
        {
            var result = await _service.ProductService
                .UpdateProduct(
                productId,
                productDtoForUpdate,
                trackChanges: true
                );

            return result.Map(
                 onSuccess: Ok,
                 onFailure: ProcessError
                 );
        }

        /// <summary>
        /// Update product by field
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="jsonPatchDocumentDto"></param>
        /// <param name="validator"></param>
        /// <returns></returns>
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
