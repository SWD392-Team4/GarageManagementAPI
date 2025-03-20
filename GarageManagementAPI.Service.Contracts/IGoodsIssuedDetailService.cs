
using System.Dynamic;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IGoodsIssuedDetailService
    {
        public Task<Result<ExpandoObject>> GetGoodsIssuedDetailAsync(Guid goodsIssuedDetailId, GoodsIssuedDetailParameters goodsIssuedDetailParameters, string? include);
        public Task<Result<IEnumerable<ExpandoObject>>> GetGoodsIssuedDetailsAsync(GoodsIssuedDetailParameters goodsIssuedDetailParameters, string? include);
        public Task<Result<IEnumerable<ExpandoObject>>> GetGoodsIssuedDetailsAsync(Guid goodsIssuedDetail, GoodsIssuedDetailParameters goodsIssuedDetailParameters, bool trackChanges, string? include);

        public Task<int> GetSumGoodsIssuedByDate(Guid? warehouseId, DateTimeOffset? startDate = null, DateTimeOffset? endDate = null);
    }
}
