using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.ErrorsConstant.GoodsReceived;
using GarageManagementAPI.Shared.DataTransferObjects.GoodsReceived;

namespace GarageManagementAPI.Service.Extension
{
    public static class GoodsReceivedExtension
    {
        public static Result<GoodsReceived> OkResult(this GoodsReceived goodsReceived)
         => Result<GoodsReceived>.Ok(goodsReceived);

        public static Result<GoodsReceivedDto> OkResult(this GoodsReceivedDto goodsReceivedDto)
            => Result<GoodsReceivedDto>.Ok(goodsReceivedDto);

        public static Result<GoodsReceivedDto> CreatedResult(this GoodsReceivedDto goodsReceivedDto)
            => Result<GoodsReceivedDto>.Created(goodsReceivedDto);

        public static Result<GoodsReceived> NotFound(this GoodsReceived? GoodsReceived, Guid goodsReceivedId)
            => Result<GoodsReceived>.NotFound([GoodsReceivedErrors.GetGoodsReceivedNotFoundIdError(goodsReceivedId)]);
        public static Result<GoodsReceived> ExistedWithReferenceName(this GoodsReceived? GoodsReceived, string referenceName)
            => Result<GoodsReceived>.BadRequest([GoodsReceivedErrors.GetGoodsReceivedRefenrenNameIsExistError(referenceName)]);
        public static Result<GoodsReceived> ExistedWithInvoiceCode(this GoodsReceived? GoodsReceived, string invoiceCode)
            => Result<GoodsReceived>.BadRequest([GoodsReceivedErrors.GetGoodsReceivedRefenrenInvoiceCodeIsExistError(invoiceCode)]);
        public static Result<GoodsReceived> ExistedWithAddress(this GoodsReceived? GoodsReceived, GoodsReceived goodsReceivedEntity)
            => Result<GoodsReceived>.BadRequest([GoodsReceivedErrors.GetGoodsReceivedRefenrenAddressIsExistError(goodsReceivedEntity.SourceAddress, goodsReceivedEntity.SourceProvince, goodsReceivedEntity.SourceDistrict, goodsReceivedEntity.SourceWards)]);
    }
}
