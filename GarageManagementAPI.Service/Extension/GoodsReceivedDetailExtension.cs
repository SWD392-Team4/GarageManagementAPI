using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.GoodsReceivedDetail;
using GarageManagementAPI.Shared.ErrorsConstant.GoodsReceivedDetail;
using GarageManagementAPI.Shared.ResultModel;

namespace GarageManagementAPI.Service.Extension
{
    public static class GoodsReceivedDetailDetailExtension
    {
        public static Result<GoodsReceivedDetail> OkResult(this GoodsReceivedDetail goodsReceivedDetail)
         => Result<GoodsReceivedDetail>.Ok(goodsReceivedDetail);
        public static Result<GoodsReceivedDetailDto> OkResult(this GoodsReceivedDetailDto goodsReceivedDetailDto)
            => Result<GoodsReceivedDetailDto>.Ok(goodsReceivedDetailDto);
        public static Result<GoodsReceivedDetailDto> CreatedResult(this GoodsReceivedDetailDto goodsReceivedDetail)
            => Result<GoodsReceivedDetailDto>.Created(goodsReceivedDetail);
        public static Result<GoodsReceivedDetail> NotFound(this GoodsReceivedDetail? GoodsReceivedDetail, Guid goodsReceivedDetailId)
            => Result<GoodsReceivedDetail>.NotFound([GoodsReceivedDetailErrors.GetGoodsReceivedDetailsIsExist(goodsReceivedDetailId)]);
        public static Result<GoodsReceivedDetail> ExistedWithId(this GoodsReceivedDetail? GoodsReceivedDetail, Guid productId, Guid goodsReceived)
            => Result<GoodsReceivedDetail>.BadRequest([GoodsReceivedDetailErrors.GetGoodsReceivedAndProductIsExist(goodsReceived, productId)]);
    }
}
