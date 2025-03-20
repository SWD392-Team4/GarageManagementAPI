using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;

using Microsoft.AspNetCore.Mvc;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/product-at-garages")]
    [ApiController]
    public class ProductAtGarageController : ApiControllerBase
    {
        public ProductAtGarageController(IServiceManager service) : base(service)
        {

        }

        /// <summary>
        /// Get product at garage by Id
        /// </summary>
        /// <param name="productAtGarageId"></param>
        /// <returns></returns>
        [HttpGet("{productAtGarageId:guid}", Name = "GetProductAtGarageById")]
        public async Task<IActionResult> GetProductAtGarage(Guid productAtGarageId)
        {
            var include = "Product";
            var product = await _service.ProductAtGarageService.GetProductAtGarage(productAtGarageId, trackChanges: false, include);
            return product.Map(
                  onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        /// <summary>
        /// Get all product at all garage
        /// </summary>
        /// <param name="productAtWarehouseParameters"></param>
        /// <returns></returns>
        [HttpGet(Name = "GetProducts")]
        public async Task<IActionResult> GetProductAtGarages([FromRoute] ProductAtGarageParameters productAtWarehouseParameters)
        {
            var include = "Product";
            var productAtWarehouse = await _service.ProductAtGarageService.GetProductAtGarages(productAtWarehouseParameters, trackChanges: false, include);
            return productAtWarehouse.Map(
                 onSuccess: Ok,
               onFailure: ProcessError
               );

        }
        /// <summary>
        /// Get product specific
        /// </summary>
        /// <param name="garageId"></param>
        /// <param name="productAtWarehouseParameters"></param>
        /// <returns></returns>
        [HttpGet("product/{garageId:guid}", Name = "GetProductsAtGarageSpecific")]
        public async Task<IActionResult> GetProductAtGarageSpecefics(Guid garageId, [FromQuery] ProductAtGarageParameters productAtWarehouseParameters)
        {
            var include = "Product";
            var productAtWarehouse = await _service.ProductAtGarageService.GetProductsAtGarage(garageId, productAtWarehouseParameters, trackChanges: false, include);
            return productAtWarehouse.Map(
                 onSuccess: Ok,
               onFailure: ProcessError
               );
        }
    }
}
