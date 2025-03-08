using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.GoodsIssuedDetail;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using GarageManagementAPI.Shared.Extension;

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


        [HttpPost(Name = "CreateGoodsIssuedDetail")]
        public async Task<IActionResult> CreateGoodsIssuedDetail([FromBody] GoodsIssuedDetailDtoForCreation goodsIssuedDetailDtoForCreation)
        {
            var result = await _service.GoodsIssuedDetailService.CreateGoodsIssuedDetailAsync(goodsIssuedDetailDtoForCreation);

            return result.Map(
                onSuccess: result =>
                {
                    var createdGoodsIssuedDetail = result.GetValue<GoodsIssuedDetailDto>();

                    return CreatedAtRoute("GetGoodsIssuedDetailById", new { goodsIssuedDetailId = createdGoodsIssuedDetail.Id }, result);
                },
                onFailure: ProcessError
                );
        }


        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)}")]
        [HttpPut("{goodsIssuedDetailId:guid}")]
        public async Task<IActionResult> UpdateGoodsIssuedDetail(Guid goodsIssuedDetailId, [FromBody] GoodsIssuedDetailDtoForUpdate goodsIssuedDetailDtoForUpdate)
        {
            Console.WriteLine("Hello");
            var result = await _service.GoodsIssuedDetailService
                .UpdateGoodsIssuedDetailAsync(
                goodsIssuedDetailId,
                goodsIssuedDetailDtoForUpdate
                );

            return result.Map(
                 onSuccess: Ok,
                 onFailure: ProcessError
                 );
        }
    }
}
