using GarageManagementAPI.Shared.DataTransferObjects.ProductImage;
using GarageManagementAPI.Shared.ErrorModel;

namespace GarageManagementAPI.Shared.ErrorsConstant.ProductImg
{
    public class ProductImgErrors
    {
        #region Product const errors
        public const string ProductImageNotFound= "Product img doesn't exist.";
        public const string ProductImageNotFoundWithId = "Product img with id {0} doesn't exist.";
        public const string ProductImageLink = "Product img with link already existed.";
        public const string ProductImageLinkRequired = "The product img link is required.";
        public const string ProductImageStatusRequired = "The product img status is required";
        public const string ProductImageStatusInvalid = "Invalid product status.";
        #endregion
        #region static method

        public static ErrorsResult GetProductImageNotFoundError() =>
             new()
             {
                Code = nameof(ProductImageNotFound),
                Description = ProductImageNotFound
             };
        public static ErrorsResult GetProductImageNotFoundWithIdError(Guid productImgId) =>
             new()
             {
                Code = nameof(ProductImageNotFoundWithId),
                Description = string.Format(ProductImageNotFoundWithId, productImgId)
              };

        public static ErrorsResult GetProductImageLinkAlreadyExistError(ProductImageDtoForCreation productDtoForCreation) =>
             new()
             {
                 Code = nameof(ProductImageLink),
                 Description = string.Format(ProductImageLink, productDtoForCreation.Link)
             };
        #endregion
    }
}
