using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.DataTransferObjects.ProductAtGarage;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.ErrorsConstant.ProductAtGarage;
using ZXing.QrCode.Internal;
using GarageManagementAPI.Shared.ErrorsConstant.Product;


namespace GarageManagementAPI.Service.Extension
{
    public static class ProductAtGarageExtension
    {
        public static Result<ProductAtGarageDto> CreateResult(this ProductAtGarageDto productAtGarageDto) 
            => Result<ProductAtGarageDto>.Created(productAtGarageDto);

        public static Result<ProductAtGarage> OkResukt(this ProductAtGarage productAtGarage)
            => Result<ProductAtGarage>.Ok(productAtGarage);

        public static Result<ProductAtGarage> OkResult(this ProductAtGarage productAtGarage)
        => Result<ProductAtGarage>.Ok(productAtGarage);

        public static Result<ProductAtGarage> NotFound(this ProductAtGarage? productAtGarage, Guid productAtWarehouseId) => Result<ProductAtGarage>.NotFound([ProductAtGarageErrors.GetProductAtGarageNotFound(productAtWarehouseId)]);

        public static Result<ProductAtGarage> NotFoundBarCode(this ProductAtGarage? productAtGarage, string barcode)
            => Result<ProductAtGarage>.NotFound([ProductAtGarageErrors.GetProductAtGarageBarcodeNotFound(barcode)]);

        public static Result<ProductAtGarage> NotFoundBarcode(this ProductAtGarage? product, string barcode)
           => Result<ProductAtGarage>.NotFound([ProductErrors.GetProductByBarcodeNotFoundError(barcode)]);
    }
}
