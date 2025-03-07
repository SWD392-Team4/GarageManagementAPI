using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Service.Extension;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.DataTransferObjects.GoodsIssuedDetail;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.ErrorsConstant.GoodsIssued;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;
using System.Dynamic;
using GarageManagementAPI.Shared.DataTransferObjects.GoodsIssued;

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
        public async Task<Result<GoodsIssuedDetailDto>> CreateGoodsIssuedDetailAsync(GoodsIssuedDetailDtoForCreation goodsIssuedDetailDto)
        {
            var wareHouseResult = await GetAndCheckIfGoodsIssuedIdIsExist(goodsIssuedDetailDto.GoodsIssuedId);
            if (wareHouseResult) return Result<GoodsIssuedDetailDto>.BadRequest([GoodsIssuedErrors.GetGoodsIssuedNotFoundWithIdError(goodsIssuedDetailDto.GoodsIssuedId)]);

            var goodsIssuedDetailEntity = _mapper.Map<GoodsIssuedDetail>(goodsIssuedDetailDto);

            goodsIssuedDetailEntity.CreatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            goodsIssuedDetailEntity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            goodsIssuedDetailEntity.Status = GoodsIssuedDetailStatus.Inactive;

            await _repoManager.GoodsIssuedDetail.CreatedGoodsIssuedDetailAsync(goodsIssuedDetailEntity);
            await _repoManager.SaveAsync();

            var goodsIssuedDetailDtoToReturn = _mapper.Map<GoodsIssuedDetailDto>(goodsIssuedDetailEntity);

            return goodsIssuedDetailDtoToReturn.CreatedResult();
        }

        public async Task<Result> UpdateGoodsIssuedDetailAsync(Guid goodsIssuedDetailId, GoodsIssuedDetailDtoForUpdate goodsIssuedDetailDto)
        {
            var goodIssuedDetailResult = await GetAncCheckGoodIssuedDetailIsExxist(goodsIssuedDetailId, true, null);
            if (!goodIssuedDetailResult.IsSuccess)
                return Result<GoodsIssuedDetailDto>.Failure(goodIssuedDetailResult.StatusCode, goodIssuedDetailResult.Errors!);
            var goodIssuedDetailEntity = goodIssuedDetailResult.GetValue<GoodsIssuedDetail>();
            _mapper.Map(goodsIssuedDetailDto, goodIssuedDetailEntity);

            goodIssuedDetailEntity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            await _repoManager.SaveAsync();
            return Result<GoodsIssuedDetailDtoForUpdate>.Ok(goodsIssuedDetailDto);
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
