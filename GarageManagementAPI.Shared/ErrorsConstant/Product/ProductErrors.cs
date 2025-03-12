using GarageManagementAPI.Shared.DataTransferObjects.Product;
using GarageManagementAPI.Shared.ErrorModel;

namespace GarageManagementAPI.Shared.ErrorsConstant.Product
{
    public class ProductErrors
    {
        #region Product const errors
        public const string ProductNotFound = "Product with id {0} doesn't exist.";
        public const string ProductNameOrBarCode = "Product with name or barcode already existed.";
        public const string NameRequired = "The product name is required.";
        public const string ProductStatusRequired = "The product status is required";
        public const string ProductStatusInvalid = "Invalid product status.";
        public const string ProductNotFoundWithId = "Can not found Product with id {0}.";
        public const string ProductNotFoundWithBarcode = "Can not found Product with barcode {0}.";
        public const string ProductCategoryNotFoundWithId = "Can not found product category with id {0}.";
        public const string BrandNotFoundWithId = "Can not found brand with id {0}.";
        public const string ProductsFoundNotMatchWithIds = "Products found not match with ids {0}.";
        #endregion

        #region static method
        public static ErrorsResult GetProductNotFoundWithError()
        {
            return new()
            {
                Code = nameof(ProductNotFound),
                Description = ProductNotFound
            };
        }

        public static ErrorsResult GetProductNotFoundIdError(Guid productId) =>
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

        public static ErrorsResult GetProductNameAlreadyExistError(ProductDtoForCreation productDtoForCreation) =>
             new()
             {
                 Code = nameof(ProductNameOrBarCode),
                 Description = string.Format(ProductNameOrBarCode, productDtoForCreation.ProductName)
             };

        public static ErrorsResult GetProductCategoryIsNotFound(Guid productCategoryId) =>
            new()
            {
                Code = nameof(ProductCategoryNotFoundWithId),
                Description = string.Format(ProductCategoryNotFoundWithId, productCategoryId)
            };
        public static ErrorsResult GetBrandIsNotFound(Guid brandId) =>
            new()
            {
                Code = nameof(BrandNotFoundWithId),
                Description = string.Format(BrandNotFoundWithId, brandId)
            };

        public static ErrorsResult GetProductsFoundNotMatchWithIdsError(IEnumerable<Guid> notFoundProductIds)
        {
            return new()
            {
                Code = nameof(ProductsFoundNotMatchWithIds),
                Description = string.Format(ProductsFoundNotMatchWithIds, string.Join(", ", notFoundProductIds))
            };
        }
        #endregion
    }
}
