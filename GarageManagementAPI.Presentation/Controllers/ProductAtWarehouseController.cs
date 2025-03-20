using Microsoft.AspNetCore.Mvc;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.DataTransferObjects.ProductAtWarehouse;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/product-at-warehouses")]
    [ApiController]
    public class ProductAtWarehouseController : ApiControllerBase
    {
        public ProductAtWarehouseController(IServiceManager service) : base(service)
        {
        }
        [HttpGet("{productAtWarehouseId:guid}", Name = "GetProduAtWarehouse")]
        public async Task<IActionResult> GetProductAtWarehouse(Guid productAtWarehouseId)
        {
            var productAtHouseResult = await _service.ProductAtWarehouseService.GetProductAtWarehouse(productAtWarehouseId, false);
            return productAtHouseResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpGet("product/{warehourseId}")]
        public async Task<IActionResult> GetProductWarehouses(Guid warehourseId, [FromQuery] ProductAtWarehouseParameters productAtWarehouseParameters)
        {
            var productAtWarehouses = await _service.ProductAtWarehouseService.GetProductAtWarehouses(warehourseId , productAtWarehouseParameters, false);
            return productAtWarehouses.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpPut("{productAtWarehouseId:guid}")]
        public async Task<IActionResult> UpdateProductAtWareHouse(Guid productAtWarehouseId, ProductAtWarehouseDtoForUpdate productAtWarehouseDtoForUpdate)
        {
            var productAtWarehouseResult = await _service.ProductAtWarehouseService.UpdateProductAtWareHouse(productAtWarehouseId, productAtWarehouseDtoForUpdate, true);
            return productAtWarehouseResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError);

        }
    }
}
