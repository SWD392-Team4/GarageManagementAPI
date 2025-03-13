using System.Dynamic;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.DataTransferObjects.GoodsReceived;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IGoodsReceivedService
    {
        public Task<Result<ExpandoObject>> GetGoodsReceivedAsync(Guid goodsReceivedId, GoodsReceivedParameters goodsReceivedParameterdParameters, bool trackChanges, string? include = null);
        public Task<Result<IEnumerable<ExpandoObject>>> GetGoodsReceivedsAsync(GoodsReceivedParameters goodsReceivedParameterdParameters, bool trackChanges, string? include = null);
        public Task<Result<IEnumerable<ExpandoObject>>> GetGoodsReceivedsAsync(Guid warehouseId, GoodsReceivedParameters goodsReceivedParameterdParameters, bool trackChanges, string? include = null);
        public Task<Result<GoodsReceivedDto>> CreateGoodsReceivedAsync(GoodsReceivedDtoForCreation goodsReceivedDtoForCreation, Guid createdWarehouseManagerId);
        public Task<Result> UpdateGoodsReceived(Guid goodsReceivedId, GoodsReceivedDtoForUpdate goodsReceivedDtoForUpdate, bool trackChanges);
    }
}
