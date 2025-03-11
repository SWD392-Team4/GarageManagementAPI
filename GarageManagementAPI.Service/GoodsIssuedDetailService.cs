using AutoMapper;
using System.Dynamic;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Service.Extension;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.DataTransferObjects.GoodsIssuedDetail;

namespace GarageManagementAPI.Service
{
    public class GoodsIssuedDetailService : IGoodsIssuedDetailService
    {
        private readonly IRepositoryManager _repoManager;
        private readonly IMapper _mapper;
        private readonly IDataShaperManager _dataShaper;

        public GoodsIssuedDetailService(IRepositoryManager repoManager, IMapper mapper, IDataShaperManager dataShaper)
        {
            _repoManager = repoManager;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }
        public async Task<Result<ExpandoObject>> GetGoodsIssuedDetailAsync(Guid goodsIssuedDetailId, GoodsIssuedDetailParameters goodsIssuedDetailParameters, string? include)
        {
            var goodsIssuedDetailResult = await GetAncCheckGoodIssuedDetailIsExxist(goodsIssuedDetailId, false, include);

            if (!goodsIssuedDetailResult.IsSuccess)
                return Result<ExpandoObject>.NotFound(goodsIssuedDetailResult.Errors!);

            var goodsIssuedDetailEntity = goodsIssuedDetailResult.GetValue<GoodsIssuedDetail>();

            var goodsIssuedDetailDto = _mapper.Map<GoodsIssuedDetailDto>(goodsIssuedDetailEntity);

            var goodsIssuedDetailShaped = _dataShaper.GoodsIssuedDetail.ShapeData(goodsIssuedDetailDto, null);

            return Result<ExpandoObject>.Ok(goodsIssuedDetailShaped);
        }

        public async Task<Result<IEnumerable<ExpandoObject>>> GetGoodsIssuedDetailsAsync(GoodsIssuedDetailParameters goodsIssuedDetailParameters, string? include)
        {

            var goodsIssuedsWithMetadata = await _repoManager.GoodsIssuedDetail.GetGoodsIssuedDetailsAsync(goodsIssuedDetailParameters, include);

            var goodsIssuedsDto = _mapper.Map<IEnumerable<GoodsIssuedDetailDto>>(goodsIssuedsWithMetadata);

            var goodsIssuedsShaped = _dataShaper.GoodsIssuedDetail.ShapeData(goodsIssuedsDto, goodsIssuedDetailParameters.Fields);

            return Result<IEnumerable<ExpandoObject>>.Ok(goodsIssuedsShaped, goodsIssuedsWithMetadata.MetaData);
        }

        public Task<Result<IEnumerable<ExpandoObject>>> GetGoodsIssuedDetailsAsync(Guid goodGoodsIssued, GoodsIssuedDetailParameters goodsIssuedDetailParameters, string? include)
        {
            throw new NotImplementedException();
        }
        private async Task<bool> GetAndCheckIfWarehouseIdIsNotExist(Guid createdWareHouseManagerId)
        {
            var createdWareHouseManager = await _repoManager.Workplace.GetWorkplaceByIdAsync(createdWareHouseManagerId, false);
            if (createdWareHouseManager == null) return true;
            return false;
        }

        private async Task<bool> GetAndCheckIfGoodsIssuedIdIsExist(Guid goodsIssuedId)
        {
            var createdWareHouseManager = await _repoManager.GoodsIssued.GetGoodsIssuedAsync(goodsIssuedId, false);
            if (createdWareHouseManager == null) return true;
            return false;
        }

        private async Task<Result<GoodsIssuedDetail>> GetAncCheckGoodIssuedDetailIsExxist(Guid goodIssuedDetailId, bool trackChanges, string? include)
        {
            var goodsIssuedDetail = await _repoManager.GoodsIssuedDetail.GetGoodsIssuedDetailAsync(goodIssuedDetailId, trackChanges, include);
            if(goodsIssuedDetail == null) return goodsIssuedDetail.NotFound(goodIssuedDetailId);
            return goodsIssuedDetail.OkResult();
        }

      
    }
}
