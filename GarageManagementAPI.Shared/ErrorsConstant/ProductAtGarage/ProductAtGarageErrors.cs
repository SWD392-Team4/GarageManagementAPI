using GarageManagementAPI.Shared.ErrorModel;
using System.Reflection.Metadata.Ecma335;

namespace GarageManagementAPI.Shared.ErrorsConstant.ProductAtGarage
{
    public static class ProductAtGarageErrors
    {
        #region Product at garage const
        public const string ProductAtGarageNotFound = "Product at garage not found with id {0}";
        #endregion

        #region Prodct at garage errors
        public static ErrorsResult GetProductAtGarageNotFound(Guid productAtGarageId)
            => new() { Code = ProductAtGarageNotFound, Description = string.Format(ProductAtGarageNotFound, productAtGarageId) };
        #endregion
    }
}
