using GarageManagementAPI.Shared.DataTransferObjects.ProductCategory;
using GarageManagementAPI.Shared.ErrorModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagementAPI.Shared.ErrorsConstant.ProductCategory
{
    public class ProductCategoryErrors
    {
        #region ProductCategory const errors
        public const string ProductCategoryNotFound = "Product category with id {0} doesn't exist.";
        public const string ProductCategoryName = "Product category with name already existed.";
        public const string ProductCategorNameRequired = "The product category name is required.";
        public const string ProductCategoryStatusRequired = "The product category status is required";
        public const string ProductCategoryStatusInvalid = "Invalid product category status.";
        public const string ProductCategoryNotFoundWithId = "Can not found product cate gory with id {0}.";
        #endregion

        #region static method
        public static ErrorsResult GetProductCategoryNotFoundWithError()
        {
            return new()
            {
                Code = nameof(ProductCategoryNotFound),
                Description = ProductCategoryNotFound
            };
        }

        public static ErrorsResult GetProductCategoryNotFoundWithIdError(Guid productCategoryId) =>
    new()
    {
        Code = nameof(ProductCategoryNotFoundWithId),
        Description = string.Format(ProductCategoryNotFoundWithId, productCategoryId)
    };

        public static ErrorsResult GetProductCategoryNameAlreadyExistError(ProductCategoryDtoForCreation productCategoryDtoForCreation) =>
             new()
             {
                 Code = nameof(ProductCategoryName),
                 Description = string.Format(ProductCategoryName, productCategoryDtoForCreation.Category)
             };

        public static ErrorsResult GetProductCategoryNameUpdateAlreadyExistError(ProductCategoryDtoForUpdate productCategoryDtoForUpdate) =>
            new()
            {
                Code = nameof(ProductCategoryName),
                Description = string.Format(ProductCategoryName, productCategoryDtoForUpdate.Category)
            };
        #endregion
    }
}
