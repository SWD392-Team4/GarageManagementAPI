using GarageManagementAPI.Shared.ErrorModel;

namespace GarageManagementAPI.Shared.ErrorsConstant.GoodsReceivedDetail
{
    public static class GoodsReceivedDetailErrors
    {
        #region GoodsReceived const errors
        public const string GoodsReceivedAndProductIsExist = "Goods received with id {0} and Product with id {1} is existing";
        public const string GoodsReceivedDetailIsExistWithId = "Goods received detail with id {0} is existing";
        #endregion
        public static ErrorsResult GetGoodsReceivedAndProductIsExist(Guid productId, Guid goodsReceived)
            => new()
            {
                Code = nameof(GoodsReceivedAndProductIsExist),
                Description = string.Format(GoodsReceivedAndProductIsExist, goodsReceived, productId)
            };
        public static ErrorsResult GetGoodsReceivedDetailsIsExist(Guid goodsReceivedDetailId)
            => new()
            {
                Code = nameof(GoodsReceivedDetailIsExistWithId),
                Description = string.Format(GoodsReceivedDetailIsExistWithId, goodsReceivedDetailId)
            };

    }
}
