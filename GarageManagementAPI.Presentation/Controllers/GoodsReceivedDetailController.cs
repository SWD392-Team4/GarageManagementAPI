using Microsoft.AspNetCore.Mvc;
using GarageManagementAPI.Shared.Enums;
using Microsoft.AspNetCore.Authorization;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.DataTransferObjects.GoodsReceivedDetail;

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

   
        [HttpPost(Name = "CreateGoodsReceivedDetail")]
        public async Task<IActionResult> CreateGoodsReceivedDetail([FromBody] GoodsReceivedDetailDtoForCreation GoodsReceivedDetailDtoForCreation)
        {
            var result = await _service.GoodsReceivedDetailService.CreateGoodsReceivedDetailAsync(GoodsReceivedDetailDtoForCreation);

            return result.Map(
                onSuccess: result =>
                {
                    var createdGoodsReceivedDetail = result.GetValue<GoodsReceivedDetailDto>();

                    return CreatedAtRoute("GetGoodsReceivedDetailById", new { goodsReceivedDetailId = createdGoodsReceivedDetail.Id }, result);
                },
                onFailure: ProcessError
                );
        }

  
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)}")]
        [HttpPut("{goodsReceivedDetailId:guid}")]
        public async Task<IActionResult> UpdateGoodsReceivedDetail(Guid goodsReceivedDetailId, [FromBody] GoodsReceivedDetailDtoForUpdate goodsReceivedDetailDtoForUpdate)
        {
            Console.WriteLine("Hello");
            var result = await _service.GoodsReceivedDetailService
                .UpdateGoodsReceivedDetail(
                goodsReceivedDetailId,
                goodsReceivedDetailDtoForUpdate,
                trackChanges: true
                );

            return result.Map(
                 onSuccess: Ok,
                 onFailure: ProcessError
                 );
        }
    }
}
