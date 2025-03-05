using GarageManagementAPI.Shared.DataTransferObjects.GoodsIssued;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;
using System.Dynamic;

namespace GarageManagementAPI.Service.Contracts
{
    public interface GoodsIssuedService
    {
        public Task<Result<ExpandoObject>> GetGoodsIssuedAsync(Guid goodsIssuedId, GoodsIssuedParameters goodsIssuedParameterdParameters, bool trackChanges, string? include = null);
        public Task<Result<IEnumerable<ExpandoObject>>> GetGoodsIssuedsAsync(GoodsIssuedParameters goodsIssueds, bool trackChanges, string? include = null);
        public Task<Result<GoodsIssuedDto>> CreateGoodsIssuedAsync(GoodsIssuedDtoForCreation goodsIssuedDtoForCreation);
        public Task<Result> UpdateGoodsIssued(Guid goodsIssuedId, GoodsIssuedDtoForUpdate goodsIssuedDtoForUpdate, bool trackChanges);
    }
}
