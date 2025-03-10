using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.GoodsIssued;
using GarageManagementAPI.Shared.DataTransferObjects.GoodsIssuedDetail;
using GarageManagementAPI.Shared.ErrorsConstant.GoodsIssued;
using GarageManagementAPI.Shared.ErrorsConstant.GoodsIssuedDetail;
using GarageManagementAPI.Shared.ResultModel;

namespace GarageManagementAPI.Service.Extension
{
    public static class GoodsIssuedDetailExtension
    {
        public static Result<GoodsIssuedDetail> OkResult(this GoodsIssuedDetail goodsIssued)
        => Result<GoodsIssuedDetail>.Ok(goodsIssued);

        public static Result<GoodsIssuedDetailDto> OkResult(this GoodsIssuedDetailDto GoodsIssuedDto)
            => Result<GoodsIssuedDetailDto>.Ok(GoodsIssuedDto);

        public static Result<GoodsIssuedDetailDto> CreatedResult(this GoodsIssuedDetailDto GoodsIssuedDto)
            => Result<GoodsIssuedDetailDto>.Created(GoodsIssuedDto);

        public static Result<GoodsIssuedDetail> NotFound(this GoodsIssuedDetail? GoodsIssued, Guid GoodsIssuedId)
            => Result<GoodsIssuedDetail>.NotFound([GoodsIssuedDetailErrors.GetGoodsIssuedDetailNotFoundWithIdError(GoodsIssuedId)]);
    }
}
