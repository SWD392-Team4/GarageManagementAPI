using GarageManagementAPI.Shared.ErrorModel;

namespace GarageManagementAPI.Shared.ErrorsConstant.ProductAtGarage
{
    public static class ProductAtGarageErrors
    {
        #region Product at garage const
        public const string ProductAtGarageNotFound = "Product at garage not found with id {0}";
        public const string ProductAtGarageBarcodeNotFound = "Product at garage not found with barcode {0}";
        public const string ProductAtGarageOutOfStock = "Product at garage out of stock with id {0}";
        public const string ProductAtGarageNotEnoughQuantity = "Product at garage not enough quantity with id {0}";
        #endregion

        #region Prodct at garage errors
        public static ErrorsResult GetProductAtGarageNotFound(Guid productAtGarageId)
            => new() { Code = ProductAtGarageNotFound, Description = string.Format(ProductAtGarageNotFound, productAtGarageId) };

        public static ErrorsResult GetProductAtGarageBarcodeNotFound(string barcode)
    => new() { Code = ProductAtGarageBarcodeNotFound, Description = string.Format(ProductAtGarageBarcodeNotFound, barcode) };

        public static ErrorsResult GetProductAtGarageOutOfStock(Guid productAtGarageId)
            => new() { Code = nameof(ProductAtGarageOutOfStock), Description = string.Format(ProductAtGarageOutOfStock, productAtGarageId) };

        public static ErrorsResult GetProductAtGarageNotEnoughQuantity(Guid productAtGarageId)
            => new() { Code = nameof(ProductAtGarageNotEnoughQuantity), Description = string.Format(ProductAtGarageNotEnoughQuantity, productAtGarageId) };
        #endregion
    }
}
