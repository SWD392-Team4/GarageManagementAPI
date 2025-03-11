using Microsoft.AspNetCore.Mvc;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/goods-received-detail")]
    [ApiController]
    public class GoodsReceivedDetailController : ApiControllerBase
    {
        public GoodsReceivedDetailController(IServiceManager service) : base(service)
        {
        }
 
        [HttpGet]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)}, {nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetGoodsReceivedDetails([FromQuery] GoodsReceivedDetailParameters goodsReceivedDetailParameters)
        {
            var isInclude = "GoodsReceived,Product";
            var goodsReceivedDetailResult = await _service.GoodsReceivedDetailService.GetGoodsReceivedDetailsAsync(goodsReceivedDetailParameters, trackChanges: false, isInclude);

            return goodsReceivedDetailResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpGet("{goodsReceivedId:guid}/details")]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)}, {nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetGoodsReceivedDetailsByGoodsReceived(Guid goodsReceivedId, [FromQuery] GoodsReceivedDetailParameters goodsReceivedDetailParameters)
        {
            var isInclude = "GoodsReceived,Product";
            var goodsReceivedDetailResult = await _service.GoodsReceivedDetailService.GetGoodsReceivedDetailsAsync(goodsReceivedId, goodsReceivedDetailParameters, trackChanges: false, isInclude);

            return goodsReceivedDetailResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpGet("{goodsReceivedDetailId:guid}", Name = "GetGoodsReceivedDetailById")]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetGoodsReceivedDetailById(Guid goodsReceivedDetailId, [FromQuery] GoodsReceivedDetailParameters goodsReceivedDetailParameters)
        {
            var isInclude = "GoodsReceived,Product";
            var goodsReceivedDetailResult = await _service.GoodsReceivedDetailService.GetGoodsReceivedDetailAsync(goodsReceivedDetailId, goodsReceivedDetailParameters, trackChanges: false, isInclude);

            return goodsReceivedDetailResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }
    }
}
