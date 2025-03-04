using GarageManagementAPI.Shared.ErrorModel;

namespace GarageManagementAPI.Shared.ErrorsConstant.GoodsReceived
{
    public static class GoodsReceivedErrors
    {
        #region GoodsReceived const errors
        public const string GoodsReceivedNotFound = "Goods Received with id {0} doesn't exist.";
        public const string GoodsReceivedRequired = "The Goods Received name is required.";
        public const string GoodsReceivedReferenName = "The goods received reference name {0} already exist";
        public const string GoodsReceivedInvoiceCode = "The goods received invoiceCode {0} already exist";
        public const string GoodsReceivedStatusRequired = "The Goods Received status is required";
        public const string GoodsReceivedStatusInvalid = "Invalid Goods Received status.";
        public const string GoodsReceivedNotFoundWithId = "Can not found Goods Received with id {0}.";
        public const string GoodsReceivedNotFoundWithBarcode = "Can not found Goods Received with barcode {0}.";
        public const string GoodsReceivedFullAdressAlreadyExist = "Goods received with address {0}, province {1}, district {2} and wards {3} already existed.";
        #endregion

        #region static method
        public static ErrorsResult GetGoodsReceivedNotFoundWithError()
        {
            return new()
            {
                Code = nameof(GoodsReceivedNotFound),
                Description = GoodsReceivedNotFound
            };
        }

        public static ErrorsResult GetGoodsReceivedNotFoundIdError(Guid goodsReceivedId) =>
        new()
        {
            Code = nameof(GoodsReceivedNotFoundWithId),
            Description = string.Format(GoodsReceivedNotFoundWithId, goodsReceivedId)
        };

        public static ErrorsResult GetGoodsReceivedRefenrenNameIsExistError(string refenrenName) =>
         new()
         {
             Code = nameof(GoodsReceivedReferenName),
             Description = string.Format(GoodsReceivedReferenName, refenrenName)
         };

        public static ErrorsResult GetGoodsReceivedRefenrenInvoiceCodeIsExistError(string invoiceName) =>
         new()
         {
             Code = nameof(GoodsReceivedInvoiceCode),
             Description = string.Format(GoodsReceivedInvoiceCode, invoiceName)
         };

        public static ErrorsResult GetGoodsReceivedRefenrenAddressIsExistError(string address, string province, string district, string wards) =>
                new ()
                {
                    Code = nameof(GoodsReceivedFullAdressAlreadyExist),
                    Description = string.Format(GoodsReceivedFullAdressAlreadyExist, address, province, district, wards)
                };


    #endregion
}
}
