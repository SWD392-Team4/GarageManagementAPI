using GarageManagementAPI.Shared.DataTransferObjects.Product;
using GarageManagementAPI.Shared.DataTransferObjects.ProductHistory;
using GarageManagementAPI.Shared.ErrorModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagementAPI.Shared.ErrorsConstant.ProductHistory
{
    public class ProductHistoryErrors
    {
        #region Product const errors
        public const string ProductHistoryNotFound = "Product history with id {0} doesn't exist.";
        public const string ProductHistoryPrice = "Product history with price already existed.";
        public const string ProductHistoryPriceRequired = "The product history price is required.";
        public const string ProductHistoryStatusRequired = "The product history status is required";
        public const string ProductHistoryStatusInvalid = "Invalid product status.";
        public const string ProductHistoryNotFoundWithId = "Can not found product history with id {0}.";
        public const string ProductHistoryNotFoundWithBarcode = "Can not found product history with barcode {0}.";
        #endregion
        #region static method
        public static ErrorsResult GetProductHistoryNotFoundError()
        {
            return new()
            {
                Code = nameof(ProductHistoryNotFoundWithId),
                Description = ProductHistoryNotFoundWithId
            };
        }

        public static ErrorsResult GetProductHistoryNotFoundWithIdError(Guid productId) =>
    new()
    {
        Code = nameof(ProductHistoryNotFoundWithId),
        Description = string.Format(ProductHistoryNotFoundWithId, productId)
    };


        public static ErrorsResult GetProductHistoryPriceAlreadyExistError(ProductHistoryDtoForCreation productDtoForCreation) =>
             new()
             {
                 Code = nameof(ProductHistoryPrice),
                 Description = string.Format(ProductHistoryPrice, productDtoForCreation.ProductPrice)
             };
        #endregion
    }
}
