
using System.Dynamic;
using GarageManagementAPI.Shared.DataTransferObjects.GoodsIssuedDetail;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IGoodsIssuedDetailService
    {
        public Task<Result<ExpandoObject>> GetGoodsIssuedDetailAsync(Guid goodsIssuedDetailId, GoodsIssuedDetailParameters goodsIssuedDetailParameters, string? include);
        public Task<Result<IEnumerable<ExpandoObject>>> GetGoodsIssuedDetailsAsync(GoodsIssuedDetailParameters goodsIssuedDetailParameters, string? include);
        public Task<Result<IEnumerable<ExpandoObject>>> GetGoodsIssuedDetailsAsync(Guid goodGoodsIssued, GoodsIssuedDetailParameters goodsIssuedDetailParameters, string? include);
    }
}
