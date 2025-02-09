using GarageManagementAPI.Shared.DataTransferObjects.Product;
using GarageManagementAPI.Shared.ErrorModel;

namespace GarageManagementAPI.Shared.ErrorsConstant.Product
{
    public class ProductErrors
    {
        #region Product const errors
        public const string ProductNotFound = "Work place with id {0} doesn't exist.";
        public const string ProductName = "Product with name already existed.";
        public const string NameRequired = "The work place name is required.";
        public const string ProductStatusRequired = "The product status is required";
        public const string ProductStatusInvalid = "Invalid product status.";
        public const string ProductNotFoundWithId = "Can not found Product with id {0}.";
        public const string ProductNotFoundWithBarcode = "Can not found Product with barcode {0}.";
        #endregion

        #region static method
        public static ErrorsResult GetProductNotFoundWithIdError()
        {
            return new()
            {
                Code = nameof(ProductNotFoundWithId),
                Description = ProductNotFoundWithId
            };
        }

        public static ErrorsResult GetProductNotFoundError(Guid productId) =>
    new()
    {
        Code = nameof(ProductNotFoundWithId),
        Description = string.Format(ProductNotFoundWithId, productId)
    };

        public static ErrorsResult GetProductByBarcodeNotFoundError(string barcode) =>
        new()
        {
            Code = nameof(ProductNotFoundWithBarcode),
            Description = string.Format(ProductNotFoundWithBarcode, barcode)
        };

        public static ErrorsResult GetProductNameAlreadyExistError(ProductDtoForCreation productDtoForCreation)
        {

            return new()
            {
                Code = nameof(ProductName),
                Description = string.Format(ProductName, productDtoForCreation.ProductName)
            };
        }
        #endregion
    }
}
