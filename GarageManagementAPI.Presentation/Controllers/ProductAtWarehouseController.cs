using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.ProductAtWarehouse;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;
using Microsoft.AspNetCore.Mvc;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/product-at-warehouse")]
    [ApiController]
    public class ProductAtWarehouseController : ApiControllerBase
    {
        public ProductAtWarehouseController(IServiceManager service) : base(service)
        {
        }
        [HttpGet("{productAtWarehouseId:guid}", Name = "GetProduAtWarehouse")]
        public async Task<IActionResult> GetProductAtWarehouse(Guid productAtHouseId)
        {
            var productAtHouseResult = await _service.ProductAtWarehouseService.GetProductAtWarehouse(productAtHouseId, false);
            return productAtHouseResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }
        [HttpGet]
        public async Task<IActionResult> GetProductWarehouses(ProductAtWarehouseParameters productAtWarehouseParameters)
        {
            var productAtWarehouses = await _service.ProductAtWarehouseService.GetProductAtWarehouses(productAtWarehouseParameters, false);
            return productAtWarehouses.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductAtWareHouse(ProductAtWarehouseDtoForCreation productAtWarehouseDtoForCreation)
        {
            var productAtWarehouseResult = await _service.ProductAtWarehouseService.CreateProductAtWareHouse(productAtWarehouseDtoForCreation);
            return productAtWarehouseResult.Map(
                onSuccess: result =>
                {
                    var createdProduct = productAtWarehouseResult.GetValue<ProductAtWarehouseDto>();
                    return CreatedAtRoute("GetProduAtWarehouse", new { productAtWarehouseId = createdProduct.Id }, productAtWarehouseResult);
                },
                onFailure: ProcessError
                );
        }

        [HttpPut("{productAtWarehouseId: guid}")]
        public async Task<IActionResult> UpdateProductAtWareHouse(Guid productAtWarehouseId, ProductAtWarehouseDtoForUpdate productAtWarehouseDtoForUpdate)
        {
            var productAtWarehouseResult = await _service.ProductAtWarehouseService.UpdateProductAtWareHouse(productAtWarehouseId, productAtWarehouseDtoForUpdate, true);
            return productAtWarehouseResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError);

        }
    }
}
