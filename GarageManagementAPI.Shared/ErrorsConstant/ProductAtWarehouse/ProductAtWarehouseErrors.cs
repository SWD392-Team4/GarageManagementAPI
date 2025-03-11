using GarageManagementAPI.Shared.ErrorModel;

namespace GarageManagementAPI.Shared.ErrorsConstant.ProductAtWarehouse
{
    public class ProductAtWarehouseErrors
    {
        #region Product const errors
        public const string ProductAtWarehouseNotfound = "Product at ware house with id {0} doesn't exist.";
        public const string ProductGoodsReceivedDetailNotfound = "Goods received detail with id {0} doesn't exist.";
        public const string ProductAtGarageBarcodeNotfound = "Product at garage with barcode {0} doesn't exist.";
        #endregion
        public static ErrorsResult ProductAtWarehouseNotFoundError(Guid Id)
            => new() { Code = ProductAtWarehouseNotfound, Description = string.Format(ProductAtWarehouseNotfound, Id) };
        public static ErrorsResult GoodsReceivedDetailNotFoundError(Guid Id)
         => new() { Code = ProductGoodsReceivedDetailNotfound, Description = string.Format(ProductGoodsReceivedDetailNotfound, Id) };

        public static ErrorsResult ProductAtWarehouseBarcodeNotFound(string barcode)
            => new() { Code = ProductAtGarageBarcodeNotfound, Description = string.Format(ProductAtGarageBarcodeNotfound, barcode) };

    }
}
