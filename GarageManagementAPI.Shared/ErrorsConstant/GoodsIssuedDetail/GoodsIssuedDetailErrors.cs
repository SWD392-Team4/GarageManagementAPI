using GarageManagementAPI.Shared.ErrorModel;
using System;
using System.Collections.Generic;
namespace GarageManagementAPI.Shared.ErrorsConstant.GoodsIssuedDetail
{
    public class GoodsIssuedDetailErrors
    {
        public const string GoodIssuedDetailWithId = "Good issued detail with id {0} does not exist";

        public static ErrorsResult GetGoodsIssuedDetailNotFoundWithIdError(Guid goodsIssuedDetailId) => new()
        {
            Code = GoodIssuedDetailWithId,
            Description = string.Format(GoodIssuedDetailWithId, goodsIssuedDetailId)
        };
    }
}
