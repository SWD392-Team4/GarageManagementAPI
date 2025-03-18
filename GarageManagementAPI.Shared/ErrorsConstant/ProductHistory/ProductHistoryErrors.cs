using GarageManagementAPI.Shared.DataTransferObjects.ProductHistory;
using GarageManagementAPI.Shared.ErrorModel;

namespace GarageManagementAPI.Shared.ErrorsConstant.ProductHistory
{
    public class ProductHistoryErrors
    {
        #region Product const errors
        public const string ProductHistoryNotFoundError = "Product history of product {0} doesn't exist.";
        public const string ProductHistoryNotFoundWithId = "Product history with id {0} doesn't exist.";
        public const string ProductHistoryPrice = "Product history with price already existed.";
        public const string ProductHistoryPriceRequired = "The product history price is required.";
        public const string ProductHistoryStatusRequired = "The product history status is required";
        public const string ProductHistoryStatusInvalid = "Invalid product status.";
        public const string ProductHistoryNotMatchWithProductId = "Product history found not match with product id {0}.)";
        #endregion
        #region static method

        public static ErrorsResult GetProductHistoryNotFoundError(Guid productId) =>
             new()
             {
                 Code = nameof(ProductHistoryNotFoundError),
                 Description = string.Format(ProductHistoryNotFoundError, productId)
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

        public static ErrorsResult GetProductHistoryNotMatchWithProductId(IEnumerable<Guid> ids)
            => new()
            {
                Code = nameof(ProductHistoryNotMatchWithProductId),
                Description = string.Format(ProductHistoryNotMatchWithProductId, string.Join(", ", ids))
            };
        #endregion
    }
}
