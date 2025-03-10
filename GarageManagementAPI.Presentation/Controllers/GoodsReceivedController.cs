using Microsoft.AspNetCore.Mvc;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.DataTransferObjects.GoodsReceived;
using System.Security.Claims;
using GarageManagementAPI.Shared.Enums;
using Microsoft.AspNetCore.Authorization;

namespace GarageManagementAPI.Presentation.Controllers
{
    [Route("api/goods-received")]
    [ApiController]
    public  class GoodsReceivedController : ApiControllerBase
    {
        public GoodsReceivedController(IServiceManager service) : base(service)
        {
        }

        [HttpGet]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)}, {nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetGoodsReceiveds([FromQuery] GoodsReceivedParameters goodsReceivedParameters)
        {
            var include = "CreatedWarehouseManager, SupplierContact, Warehouse";
            var goodsReceivedResult = await _service.GoodsReceivedService.GetGoodsReceivedsAsync(goodsReceivedParameters, trackChanges: false, include);

            return goodsReceivedResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpGet("{goodsReceivedId:guid}", Name = "GetGoodsReceivedById")]
        //[Authorize(Roles = $"{nameof(SystemRole.Administrator)},{nameof(SystemRole.Cashier)}")]
        public async Task<IActionResult> GetGoodsReceivedById(Guid goodsReceivedId, [FromQuery] GoodsReceivedParameters goodsReceivedParameters)
        {
            var include = "CreatedWarehouseManager, SupplierContact, Warehouse";
            var GoodsReceivedResult = await _service.GoodsReceivedService.GetGoodsReceivedAsync(goodsReceivedId, goodsReceivedParameters, trackChanges: false, include);

            return GoodsReceivedResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [Authorize(Roles = $"{nameof(SystemRole.Cashier)}, {nameof(SystemRole.Administrator)}")]
        [HttpPost(Name = "CreateGoodsReceived")]
        public async Task<IActionResult> CreateGoodsReceived([FromBody] GoodsReceivedDtoForCreation goodsReceivedDtoForCreation)
        {
            var userId = HttpContext.User.FindFirstValue("UserId");
            var result = await _service.GoodsReceivedService.CreateGoodsReceivedAsync(goodsReceivedDtoForCreation, Guid.Parse(userId));

            return result.Map(
                onSuccess: result =>
                {
                    var createdGoodsReceived = result.GetValue<GoodsReceivedDto>();

                    return CreatedAtRoute("GetGoodsReceivedById", new { GoodsReceivedId = createdGoodsReceived.Id }, result);
                },
                onFailure: ProcessError
                );
        }


       // [Authorize(Roles = $"{nameof(SystemRole.Administrator)}")]
        [HttpPut("{goodsReceivedId:guid}")]
        public async Task<IActionResult> UpdateGoodsReceived(Guid goodsReceivedId, [FromBody] GoodsReceivedDtoForUpdate goodsReceivedDtoForUpdate)
        {
            var result = await _service.GoodsReceivedService
                .UpdateGoodsReceived(
                goodsReceivedId,
                goodsReceivedDtoForUpdate,
                trackChanges: true
                );

            return result.Map(
                 onSuccess: Ok,
                 onFailure: ProcessError
                 );
        }
    }
}
