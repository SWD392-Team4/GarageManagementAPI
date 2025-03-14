using Microsoft.AspNetCore.Mvc;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;

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
        [HttpGet("{productAtGarageId:guid}", Name = "GetProductAtWareById")]
        public async Task<IActionResult> GetProductAtGarage(Guid productAtGarageId)
        {
            var product = await _service.ProductAtGarageService.GetProductAtGarage(productAtGarageId, trackChanges: false);
            return product.Map(
                  onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        /// <summary>
        /// Get products at garage
        /// </summary>
        /// <param name="productAtWarehouseParameters"></param>
        /// <returns></returns>
        [HttpGet(Name = "GetProducts")]
        public async Task<IActionResult> GetProductAtGarages([FromRoute]ProductAtGarageParameters productAtWarehouseParameters)
        {
            var productAtWarehouse = await _service.ProductAtGarageService.GetProductAtWarehouses(productAtWarehouseParameters, trackChanges: false);
            return productAtWarehouse.Map(
                 onSuccess: Ok,
               onFailure: ProcessError
               );
        }
    }
}
