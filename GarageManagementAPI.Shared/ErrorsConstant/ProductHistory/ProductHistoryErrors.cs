using GarageManagementAPI.Shared.DataTransferObjects.ProductHistory;
using GarageManagementAPI.Shared.ErrorModel;

namespace GarageManagementAPI.Shared.ErrorsConstant.ProductHistory
{
    public class ProductHistoryErrors
    {
        #region Product const errors
        public const string ProductHistoryNotFoundError = "Product history with doesn't exist.";
        public const string ProductHistoryNotFoundWithId = "Product history with id {0} doesn't exist.";
        public const string ProductHistoryPrice = "Product history with price already existed.";
        public const string ProductHistoryPriceRequired = "The product history price is required.";
        public const string ProductHistoryStatusRequired = "The product history status is required";
        public const string ProductHistoryStatusInvalid = "Invalid product status.";
        #endregion
        #region static method

        public static ErrorsResult GetProductHistoryNotFoundError() =>
             new()
             {
                Code = nameof(ProductHistoryNotFoundError),
                Description = ProductHistoryNotFoundError
             };
        public static ErrorsResult GetProductHistoryNotFoundWithIdError(Guid productId) =>
             new()
             {
                 Code = nameof(ProductHistoryNotFoundWithId),
                 Description = string.Format(ProductHistoryNotFoundWithId, productId)
             };


        public static ErrorsResult GetProductHistoryPriceAlreadyExistError(decimal? price) =>
             new()
             {
                 Code = nameof(ProductHistoryPrice),
                 Description = string.Format(ProductHistoryPrice, price)
             };
        #endregion
    }
}
