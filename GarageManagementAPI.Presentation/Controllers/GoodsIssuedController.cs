using Microsoft.AspNetCore.Mvc;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.DataTransferObjects.GoodsIssued;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/goods-issued")]
    [ApiController]
    public class GoodsIssuedController : ApiControllerBase
    {
        public GoodsIssuedController(IServiceManager service) : base(service)
        {
        }

        [HttpGet]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)}, {nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetGoodsIssueds([FromQuery] GoodsIssuedParameters goodsIssuedParameters)
        {
            var goodsIssuedResult = await _service.GoodsIssuedService.GetGoodsIssuedsAsync(goodsIssuedParameters, trackChanges: false);

            return goodsIssuedResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpGet("{goodsIssuedId:guid}", Name = "GetGoodsIssuedById")]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetGoodsIssuedById(Guid goodsIssuedId, [FromQuery] GoodsIssuedParameters goodsIssuedParameters)
        {
            var goodsIssuedResult = await _service.GoodsIssuedService.GetGoodsIssuedAsync(goodsIssuedId, goodsIssuedParameters, trackChanges: false);

            return goodsIssuedResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }


        [HttpPost(Name = "CreateGoodsIssued")]
        public async Task<IActionResult> CreateGoodsIssued([FromBody] GoodsIssuedDtoForCreation goodsIssuedDtoForCreation)
        {
            var goodsIssuedResult = await _service.GoodsIssuedService.CreateGoodsIssuedAsync(goodsIssuedDtoForCreation);

            return goodsIssuedResult.Map(
                onSuccess: result =>
                {
                    var createdGoodsIssued = result.GetValue<GoodsIssuedDto>();

                    return CreatedAtRoute("GetGoodsIssuedById", new { goodsIssuedId = createdGoodsIssued.Id }, goodsIssuedResult);
                },
                onFailure: ProcessError
                );
        }


        // [Authorize(Roles = $"{nameof(SystemRole.Administrator)}")]
        [HttpPut("{goodsIssuedId:guid}")]
        public async Task<IActionResult> UpdateGoodsIssued(Guid goodsIssuedId, [FromBody] GoodsIssuedDtoForUpdate goodsIssuedDtoForUpdate)
        {
            var result = await _service.GoodsIssuedService
                .UpdateGoodsIssued(
                goodsIssuedId,
                goodsIssuedDtoForUpdate,
                trackChanges: true
                );

            return result.Map(
                 onSuccess: Ok,
                 onFailure: ProcessError
                 );
        }
    }
}
