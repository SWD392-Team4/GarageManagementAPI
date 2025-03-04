using AutoMapper;
using System.Dynamic;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Service.Extension;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.DataTransferObjects.GoodsReceivedDetail;

namespace GarageManagementAPI.Service
{
    public class GoodsReceivedDetailService : IGoodsReceivedDetailService
    {
        private readonly IRepositoryManager _repoManager;
        private readonly IMapper _mapper;
        private readonly IDataShaperManager _dataShaper;

        public GoodsReceivedDetailService(IRepositoryManager repoManager, IMapper mapper, IDataShaperManager dataShaper)
        {
            _repoManager = repoManager;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }
        public async Task<Result<GoodsReceivedDetailDto>> CreateGoodsReceivedDetailAsync(GoodsReceivedDetailDtoForCreation goodsReceivedDetailDtoForCreation)
        {
            var goodsReceivedAndProductIsExist = await GetAndCheckIfGoodsReceivedByGoodReceivedAndProductExist(goodsReceivedDetailDtoForCreation.GoodsReceivedId, goodsReceivedDetailDtoForCreation.ProductId, false);
            if (!goodsReceivedAndProductIsExist.IsSuccess)
                return Result<GoodsReceivedDetailDto>.Failure(goodsReceivedAndProductIsExist.StatusCode, goodsReceivedAndProductIsExist.Errors!);

            var goodsReceivedDetailEntity = _mapper.Map<GoodsReceivedDetail>(goodsReceivedDetailDtoForCreation);

            goodsReceivedDetailEntity.TotalPrice = goodsReceivedDetailDtoForCreation.UnitPrice * goodsReceivedDetailDtoForCreation.Quantity;
            goodsReceivedDetailEntity.CreatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            goodsReceivedDetailEntity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            goodsReceivedDetailEntity.Status = GoodsReceivedDetailStatus.Inactive;

            await _repoManager.GoodsReceivedDetail.CreateGoodsReceivedDetailAsync(goodsReceivedDetailEntity);
            await _repoManager.SaveAsync();

            var goodsReceivedDetailDtoToReturn = _mapper.Map<GoodsReceivedDetailDto>(goodsReceivedDetailEntity);

            return goodsReceivedDetailDtoToReturn.CreatedResult();
        }

        public async Task<Result<ExpandoObject>> GetGoodsReceivedDetailAsync(Guid goodsReceivedDetailId, GoodsReceivedDetailParameters goodsReceivedDetailParameterdParameters, bool trackChanges, string? include = null)
        {
            var goodsReceivedResult = await GetAndCheckIfGoodsReceivedExist(goodsReceivedDetailId, trackChanges, include);

            if (!goodsReceivedResult.IsSuccess)
                return Result<ExpandoObject>.NotFound(goodsReceivedResult.Errors!);

            var goodsReceivedEntity = goodsReceivedResult.GetValue<GoodsReceivedDetail>();

            var goodsReceivedDetailDto = _mapper.Map<GoodsReceivedDetailDto>(goodsReceivedEntity);
            Console.WriteLine("ProductName" + goodsReceivedDetailDto.Productname);

            var goodsReceivedDetailShaped = _dataShaper.GoodsReceivedDetail.ShapeData(goodsReceivedDetailDto, goodsReceivedDetailParameterdParameters.Fields);

            return Result<ExpandoObject>.Ok(goodsReceivedDetailShaped);
        }

        public async Task<Result<IEnumerable<ExpandoObject>>> GetGoodsReceivedDetailsAsync(GoodsReceivedDetailParameters goodsReceivedDetails, bool trackChanges, string? include = null)
        {
            var goodsReceivedsWithMetadata = await _repoManager.GoodsReceivedDetail.GetGoodsReceivedDetailsAsync(goodsReceivedDetails, trackChanges, include);

            var goodsReceivedsDto = _mapper.Map<IEnumerable<GoodsReceivedDetailDto>>(goodsReceivedsWithMetadata);

            var goodsReceivedsShaped = _dataShaper.GoodsReceivedDetail.ShapeData(goodsReceivedsDto, goodsReceivedDetails.Fields);

            return Result<IEnumerable<ExpandoObject>>.Ok(goodsReceivedsShaped, goodsReceivedsWithMetadata.MetaData);
        }

        public async Task<Result> UpdateGoodsReceivedDetail(Guid goodsReceivedDetailId, GoodsReceivedDetailDtoForUpdate goodsReceivedDetailDtoForUpdate, bool trackChanges)
        {
            var goodsReceivedDetailResult = await GetAndCheckIfGoodsReceivedExist(goodsReceivedDetailId, trackChanges);
            var goodsReceivedAndProductIsExist = await GetAndCheckIfGoodsReceivedByGoodReceivedAndProductExist(goodsReceivedDetailDtoForUpdate.GoodsReceivedId, goodsReceivedDetailDtoForUpdate.ProductId, false, goodsReceivedDetailId);
            if (!goodsReceivedAndProductIsExist.IsSuccess)
                return Result<GoodsReceivedDetailDto>.Failure(goodsReceivedAndProductIsExist.StatusCode, goodsReceivedAndProductIsExist.Errors!);
            if (!goodsReceivedDetailResult.IsSuccess)
                return Result<GoodsReceivedDetailDto>.Failure(goodsReceivedDetailResult.StatusCode, goodsReceivedDetailResult.Errors!);
            var goodsReceivedDetailEntity = goodsReceivedDetailResult.GetValue<GoodsReceivedDetail>();

            _mapper.Map(goodsReceivedDetailDtoForUpdate, goodsReceivedDetailEntity);

            goodsReceivedDetailEntity.TotalPrice = goodsReceivedDetailDtoForUpdate.UnitPrice * goodsReceivedDetailDtoForUpdate.Quantity;
            goodsReceivedDetailEntity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();

            await _repoManager.SaveAsync();

            return Result.NoContent();
        }

        private async Task<Result<GoodsReceivedDetail>> GetAndCheckIfGoodsReceivedExist(Guid goodReceivedId, bool trackChanges, string? include =null)
        {
            var goodReceived = await _repoManager.GoodsReceivedDetail.GetGoodsReceivedDetailAsync(goodReceivedId, trackChanges, include);
            if (goodReceived == null)
                return goodReceived.NotFound(goodReceivedId);

            return goodReceived.OkResult();
        }

        private async Task<Result<GoodsReceivedDetail>> GetAndCheckIfGoodsReceivedByGoodReceivedAndProductExist(Guid goodReceivedId, Guid productId,bool trackChanges, Guid? goodsReceivedDetailId = null,string? include = null)
        {
            var goodReceived = await _repoManager.GoodsReceivedDetail.GetGoodsReceivedDetailByProductAndGoodsReceivedAsync(productId, goodReceivedId, goodsReceivedDetailId, trackChanges);
            if (goodReceived != null)
                return goodReceived.ExistedWithId(productId, goodReceivedId);

            return goodReceived!.OkResult();
        }
    }
}
