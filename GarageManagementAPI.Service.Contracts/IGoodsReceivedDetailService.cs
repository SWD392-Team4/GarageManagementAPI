using System.Dynamic;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.DataTransferObjects.GoodsReceivedDetail;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IGoodsReceivedDetailService
    {
        public Task<Result<ExpandoObject>> GetGoodsReceivedDetailAsync(Guid goodsReceivedDetailId, GoodsReceivedDetailParameters goodsReceivedDetailParameterdParameters, bool trackChanges, string? include = null);
        public Task<Result<IEnumerable<ExpandoObject>>> GetGoodsReceivedDetailsAsync(GoodsReceivedDetailParameters goodsReceivedDetails, bool trackChanges, string? include = null);
        public Task<Result<GoodsReceivedDetailDto>> CreateGoodsReceivedDetailAsync(GoodsReceivedDetailDtoForCreation goodsReceivedDetailDtoForCreation);
        public Task<Result> UpdateGoodsReceivedDetail(Guid GoodsReceivedDetailId, GoodsReceivedDetailDtoForUpdate goodsReceivedDetailDtoForUpdate, bool trackChanges);
    }
}
