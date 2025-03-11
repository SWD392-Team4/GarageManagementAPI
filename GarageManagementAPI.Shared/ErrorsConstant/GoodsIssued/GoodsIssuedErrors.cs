using GarageManagementAPI.Shared.ErrorModel;

namespace GarageManagementAPI.Shared.ErrorsConstant.GoodsIssued
{
    public class GoodsIssuedErrors
    {
        #region Goods Issued const errors
        public const string GoodsIssuedNotFound = "Goods issued with id {0} doesn't exist.";
        public const string GoodsIssuedReferenceIsExist = "Goods Issued reference with {0} is exist.";
        public const string WareHourseIsNotFound = "WareHourse with id {0} could not be found.";
        public const string MangersNotFound = "CreatedWarehouseManager with id {0} could not be found.";
        public const string Quantity = "Not enough stock for product ID {0} Available: {1}, Requested: {2}";

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
        public static ErrorsResult GetWareHourseIsNotFoundWithIdError(Guid wareHourseId) =>
    new()
    {
        Code = nameof(WareHourseIsNotFound),
        Description = string.Format(WareHourseIsNotFound, wareHourseId)
    };

        public static ErrorsResult GetMangerIsNotFoundWithIdError(Guid managerId) =>
   new()
   {
       Code = nameof(MangersNotFound),
       Description = string.Format(MangersNotFound, managerId)
   };

        public static ErrorsResult GetGoodsIssuedReferenceIsExist(string referenceName) =>
   new()
   {
       Code = nameof(GoodsIssuedReferenceIsExist),
       Description = string.Format(GoodsIssuedReferenceIsExist, referenceName)
   };
        public static ErrorsResult GetQuantityIsOutOfRange(Guid productId, int availabel, int request)
            => new() { Code = nameof(productId), Description = Quantity };
        #endregion
    }
}
