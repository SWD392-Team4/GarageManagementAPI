using Microsoft.AspNetCore.Mvc;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/goods-issued/detail")]
    [ApiController]
    public class GoodsIssuedDetailController : ApiControllerBase
    {
        public GoodsIssuedDetailController(IServiceManager service) : base(service)
        {
        }
        [HttpGet]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)}, {nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetGoodsIssuedDetails([FromQuery] GoodsIssuedDetailParameters goodsIssuedDetailParameters)
        {
            var isInclude = "GoodsIssued,ProductAtGarage,ProductAtWareHouse";
            var goodsIssuedDetailResult = await _service.GoodsIssuedDetailService.GetGoodsIssuedDetailsAsync(goodsIssuedDetailParameters, isInclude);

            return goodsIssuedDetailResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpGet("{goodsIssuedDetailId:guid}", Name = "GetGoodsIssuedDetailById")]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetGoodsIssuedDetailById(Guid goodsIssuedDetailId, [FromQuery] GoodsIssuedDetailParameters goodsIssuedDetailParameters)
        {
            var isInclude = "GoodsIssued,ProductAtGarage,ProductAtWareHouse";
            var goodsIssuedDetailResult = await _service.GoodsIssuedDetailService.GetGoodsIssuedDetailAsync(goodsIssuedDetailId, goodsIssuedDetailParameters, isInclude);

            return goodsIssuedDetailResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }
    }
}
