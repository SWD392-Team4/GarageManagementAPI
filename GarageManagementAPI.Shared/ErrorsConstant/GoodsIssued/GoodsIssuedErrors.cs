using GarageManagementAPI.Shared.ErrorModel;

namespace GarageManagementAPI.Shared.ErrorsConstant.GoodsIssued
{
    public class GoodsIssuedErrors
    {
        #region Goods Issued const errors
        public const string GoodsIssuedNotFound = "Goods issued with id {0} doesn't exist.";
        #endregion
        #region static method
        public static ErrorsResult GetGoodsIssuedNotFoundError() =>
            new()
            {
                Code = nameof(GoodsIssuedNotFound),
                Description = GoodsIssuedNotFound
            };
        public static ErrorsResult GetGoodsIssuedNotFoundWithIdError(Guid goodsIssuedId) =>
            new()
            {
                Code = nameof(GoodsIssuedNotFound),
                Description = string.Format(GoodsIssuedNotFound, goodsIssuedId)
            };
        #endregion
    }
}
