

using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.ProductImage;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using GarageManagementAPI.Shared.Extension;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/product/images")]
    [ApiController]
    public class ProductImageController : ApiControllerBase
    {
        public ProductImageController(IServiceManager service) : base(service)
        {
        }

        [HttpPost(Name = "CreateProductImage")]
        public async Task<IActionResult> CreateProductImage([FromBody] ProductImageDtoForCreation productHisotryDtoForCreation)
        {
            var result = await _service.ProductImageService.CreateProductImageAsync(productHisotryDtoForCreation);

            return result.Map(
                onSuccess: result =>
                {
                    var createdProduct = result.GetValue<ProductImageDto>();

                    return CreatedAtRoute("GetProductImageById", new { productId = createdProduct.Id }, result);
                },
                onFailure: ProcessError
                );
        }

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
    }
}
