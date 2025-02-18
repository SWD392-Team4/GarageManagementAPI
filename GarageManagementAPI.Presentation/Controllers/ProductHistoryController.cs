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
