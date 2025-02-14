using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.DataTransferObjects.ProductHistory;
using Microsoft.AspNetCore.Mvc;
using GarageManagementAPI.Shared.RequestFeatures;


namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/product/histories")]
    [ApiController]
    public class ProductHistoryController : ApiControllerBase
    {
        public ProductHistoryController(IServiceManager service) : base(service)
        {
        }

        [HttpPost(Name = "CreateProductHistory")]
        public async Task<IActionResult> CreateProductHistory([FromBody] ProductHistoryDtoForCreation productHisotryDtoForCreation)
        {
            var result = await _service.ProductHistoryService.CreateProductHistoryAsync(productHisotryDtoForCreation);

            return result.Map(
                onSuccess: result =>
                {
                    var createdProduct = result.GetValue<ProductHistoryDto>();

                    return CreatedAtRoute("GetProductById", new { productId = createdProduct.Id }, result);
                },
                onFailure: ProcessError
                );
        }

        [HttpGet("{productId:guid}", Name = "GetProductHistoryById")]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetProductById(Guid productId, [FromQuery] ProductHistoryParameters productHisotryParameters)
        {
            var productResult = await _service.ProductHistoryService.GetHistoryProductByIdProductAsync(productId, productHisotryParameters, trackChanges: false);

            return productResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpGet]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetProductHistories([FromQuery] ProductHistoryParameters productParameters)
        {
            var productResult = await _service.ProductHistoryService.GetProductHistoriesAsync(productParameters, trackChanges: false);

            return productResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }
    }
}
