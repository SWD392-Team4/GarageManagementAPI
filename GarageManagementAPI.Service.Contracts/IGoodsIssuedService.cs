using System.Dynamic;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.DataTransferObjects.GoodsIssued;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IGoodsIssuedService
    {
        public Task<Result<ExpandoObject>> GetGoodsIssuedAsync(Guid goodsIssuedId, GoodsIssuedParameters goodsIssuedParameterdParameters, bool trackChanges, string? include = null);
        public Task<Result<IEnumerable<ExpandoObject>>> GetGoodsIssuedsAsync(GoodsIssuedParameters goodsIssuedParameterdParameters, bool trackChanges, string? include = null);
        public Task<Result<GoodsIssuedDto>> CreateGoodsIssuedAsync(GoodsIssuedDtoForCreation goodsIssuedDtoForCreation);
        public Task<Result> UpdateGoodsIssued(Guid GoodsIssuedId, GoodsIssuedDtoForUpdate goodsIssuedDtoForUpdate, bool trackChanges);
    }
}
