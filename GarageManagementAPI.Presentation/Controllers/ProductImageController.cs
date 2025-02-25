﻿

using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.ProductImage;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.DataTransferObjects.Product;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/product/images")]
    [ApiController]
    public class ProductImageController : ApiControllerBase
    {
        public ProductImageController(IServiceManager service) : base(service)
        {
        }
        /// <summary>
        /// Get img product by id
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="productImageParameters"></param>
        /// <returns></returns>
        [HttpGet("{productId:guid}", Name = "GetProductImageById")]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetProductByIdImage(Guid productId, [FromQuery] ProductImageParameters productImageParameters)
        {
            var productResult = await _service.ProductImageService.GetProductImageByIdProductAsync(productId, productImageParameters, trackChanges: false);

            return productResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }
        /// <summary>
        /// Get all img product
        /// </summary>
        /// <param name="productParameters"></param>
        /// <returns></returns>
        [HttpGet]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetProductImages([FromQuery] ProductImageParameters productParameters)
        {
            var productResult = await _service.ProductImageService.GetProductImagesAsync(productParameters, trackChanges: false);

            return productResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpPut("{productImageId:guid}")]
        public async Task<IActionResult> UpdateProduct(Guid productImageId, [FromBody] ProductImageDtoForUpdate productImageDtoForUpdate)
        {
            var result = await _service.ProductImageService
                .UpdateProductImageAsync(
                productImageId,
                productImageDtoForUpdate,
                trackChanges: true
                );

            return result.Map(
                 onSuccess: Ok,
                 onFailure: ProcessError
                 );
        }
    }
}
