using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.ErrorsConstant.GoodsIssued;
using GarageManagementAPI.Shared.DataTransferObjects.GoodsIssued;

namespace GarageManagementAPI.Service.Extension
{
    public static class GoodsIssuedExtension
    {
        public static Result<GoodsIssued> OkResult(this GoodsIssued GoodsIssued)
          => Result<GoodsIssued>.Ok(GoodsIssued);

        public static Result<GoodsIssuedDto> OkResult(this GoodsIssuedDto GoodsIssuedDto)
            => Result<GoodsIssuedDto>.Ok(GoodsIssuedDto);

        public static Result<GoodsIssuedDto> CreatedResult(this GoodsIssuedDto GoodsIssuedDto)
            => Result<GoodsIssuedDto>.Created(GoodsIssuedDto);

        public static Result<GoodsIssued> NotFound(this GoodsIssued? GoodsIssued, Guid GoodsIssuedId)
            => Result<GoodsIssued>.NotFound([GoodsIssuedErrors.GetGoodsIssuedNotFoundWithIdError(GoodsIssuedId)]);
    }
}
