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
using GarageManagementAPI.Shared.ErrorsConstant.GoodsIssued;
using GarageManagementAPI.Shared.DataTransferObjects.GoodsIssued;
using GarageManagementAPI.Shared.DataTransferObjects.GoodsIssuedDetail;
using GarageManagementAPI.Shared.ErrorsConstant.ProductHistory;
using GarageManagementAPI.Shared.Enums;

namespace GarageManagementAPI.Service
{
    public class GoodsIssuedService : IGoodsIssuedService
    {
        private readonly IRepositoryManager _repoManager;
        private readonly IMapper _mapper;
        private readonly IDataShaperManager _dataShaper;

        public GoodsIssuedService(IRepositoryManager repoManager, IMapper mapper, IDataShaperManager dataShaper)
        {
            _repoManager = repoManager;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }

        public async Task<Result<GoodsIssuedDto>> CreateGoodsIssuedAsync(GoodsIssuedDtoForCreation goodsIssuedDtoForCreation, Guid createdWarehouseManagerId)
        {
            var wareHouseResult = await GetAndCheckIfWarehouseIdIsNotExist(goodsIssuedDtoForCreation.WarehouseId);
            if (wareHouseResult) return Result<GoodsIssuedDto>.BadRequest([GoodsIssuedErrors.GetWareHourseIsNotFoundWithIdError(goodsIssuedDtoForCreation.WarehouseId)]);

            var goodsIssuedResult = await GetAndCheckIfGoodsIssuedWithReferenceNumberIsExist(goodsIssuedDtoForCreation.ReferenceNumber, null, false);
            if (goodsIssuedResult) return Result<GoodsIssuedDto>.BadRequest([GoodsIssuedErrors.GetGoodsIssuedReferenceIsExist(goodsIssuedDtoForCreation.ReferenceNumber)]);

            foreach (var goodsIssuedDetail in goodsIssuedDtoForCreation.gooodsIssuedDetails)
            {
                var totalStock = await _repoManager.ProductAtWarehouse
                    .GetTotalStockForProduct(goodsIssuedDetail.ProductId, goodsIssuedDtoForCreation.WarehouseId);

                if (totalStock < goodsIssuedDetail.Quantity)
                {
                    return Result<GoodsIssuedDto>.BadRequest(
                        [GoodsIssuedErrors.GetQuantityIsOutOfRange()]);
                }
            }

            var goodsIssuedEntity = _mapper.Map<GoodsIssued>(goodsIssuedDtoForCreation);

            goodsIssuedEntity.CreatedWareHouseManagerId = createdWarehouseManagerId;
            goodsIssuedEntity.CreatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            goodsIssuedEntity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            goodsIssuedEntity.Status = GoodsIssuedStatus.Active;

            foreach (var goodsIssuedDetail in goodsIssuedDtoForCreation.gooodsIssuedDetails)
            {
                var productHistory = await _repoManager.ProductHistory.GetProductHistoryByGoodsIssuedDetails(goodsIssuedDetail!.ProductId);
                if(productHistory == null)
                {
                    goodsIssuedEntity.TotalCost += 0;
                }
                else
                {
                    goodsIssuedEntity.TotalCost += goodsIssuedDetail.Quantity * productHistory!.ProductPrice;
                }
               
            }

            await _repoManager.GoodsIssued.CreateGoodsIssuedAsync(goodsIssuedEntity);
            await _repoManager.SaveAsync();

            var goodsIssuedDtoToReturn = _mapper.Map<GoodsIssuedDto>(goodsIssuedEntity);

            foreach (var goodsIssuedDetail in goodsIssuedDtoForCreation.gooodsIssuedDetails)
            {
                var deductedList = await _repoManager.ProductAtWarehouse
                    .DeductProductQuantityFromWarehouseAsync(goodsIssuedDetail.ProductId, goodsIssuedDtoForCreation.WarehouseId, goodsIssuedDetail.Quantity);

                foreach (var (productAtWarehouseId, deductedQuantity) in deductedList)
                {
                    var productHistory = await _repoManager.ProductHistory
                        .GetProductHistoryByGoodsIssuedDetails(goodsIssuedDetail.ProductId);

                    var goodsIssuedDetailEntity = new GoodsIssuedDetail
                    {
                        GoodsIssuedId = goodsIssuedEntity.Id,
                        Quantity = deductedQuantity,
                        UnitPrice = productHistory == null ? 0 :  productHistory.ProductPrice,
                        CreatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime(),
                        UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime(),
                        Status = GoodsReceivedStatus.Active
                    };

                    await _repoManager.GoodsIssuedDetail.CreateGoodsIssuedDetailAsync(goodsIssuedDetailEntity);

                    goodsIssuedEntity.TotalCost += deductedQuantity * (productHistory?.ProductPrice ?? 0);

                    var goodsIssuedDetail_ProductAtWarehouse = new GoodsIssuedDetail_ProductAtWarehouse
                    {
                        GoodsIssuedDetailId = goodsIssuedDetailEntity.Id,
                        ProductAtWarehouseId = productAtWarehouseId,
                        QuantityUsed = deductedQuantity
                    };

                    await _repoManager.GoodsIssuedDetailProductAtWarehouse.CreateGoodsIssuedDetailProductAtWarehouse(goodsIssuedDetail_ProductAtWarehouse);
                }
            }
            await _repoManager.SaveAsync();
            return goodsIssuedDtoToReturn.CreatedResult();
        }
        public async Task<Result> UpdateGoodsIssued(Guid goodsIssuedId, GoodsIssuedDtoForUpdate goodsIssuedDtoForUpdate, bool trackChanges)
        {
            var goodsIssuedResult = await GetAndCheckIfGoodsIssuedIsExist(goodsIssuedId, trackChanges, null);

            if (!goodsIssuedResult.IsSuccess)
                return Result<GoodsIssuedDtoForUpdate>.Failure(goodsIssuedResult.StatusCode, goodsIssuedResult.Errors!);

            var goodsIssuedEntity = goodsIssuedResult.GetValue<GoodsIssued>();

            _mapper.Map(goodsIssuedDtoForUpdate, goodsIssuedEntity);

            goodsIssuedEntity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            await _repoManager.SaveAsync();
            return Result<GoodsIssuedDtoForUpdate>.Ok(goodsIssuedDtoForUpdate);
        }
        public async Task<Result<ExpandoObject>> GetGoodsIssuedAsync(Guid goodsIssuedId, GoodsIssuedParameters goodsIssuedParameterdParameters, bool trackChanges, string? include = null)
        {
            var goodsIssuedResult = await GetAndCheckIfGoodsIssuedIsExist(goodsIssuedId, trackChanges, include);

            if (!goodsIssuedResult.IsSuccess)
                return Result<ExpandoObject>.NotFound(goodsIssuedResult.Errors!);

            var goodsIssuedEntity = goodsIssuedResult.GetValue<GoodsIssued>();

            var goodsIssuedDto = _mapper.Map<GoodsIssuedDto>(goodsIssuedEntity);

            var goodsIssuedShaped = _dataShaper.GoodsIssued.ShapeData(goodsIssuedDto, null);

            return Result<ExpandoObject>.Ok(goodsIssuedShaped);
        }

        public async Task<Result<IEnumerable<ExpandoObject>>> GetGoodsIssuedsAsync(GoodsIssuedParameters goodsIssuedParameterdParameters, bool trackChanges, string? include = null)
        {
            var goodsIssuedsWithMetadata = await _repoManager.GoodsIssued.GetGoodsIssuedsAsync(goodsIssuedParameterdParameters, trackChanges, include);

            var goodsIssuedsDto = _mapper.Map<IEnumerable<GoodsIssuedDto>>(goodsIssuedsWithMetadata);

            var goodsIssuedsShaped = _dataShaper.GoodsIssued.ShapeData(goodsIssuedsDto, goodsIssuedParameterdParameters.Fields);

            return Result<IEnumerable<ExpandoObject>>.Ok(goodsIssuedsShaped, goodsIssuedsWithMetadata.MetaData);
        }

        private async Task<Result<GoodsIssuedDetailDto>> CreateGoodsIssuedDetailAsync(GoodsIssuedDetailDtoForCreation goodsIssuedDetailDtoForCreation, Guid goodsIssuedId, Guid warehouseId)
        {
            var goodsIssuedDetailEntity = _mapper.Map<GoodsIssuedDetail>(goodsIssuedDetailDtoForCreation);

            var productHistory = await _repoManager.ProductHistory.GetProductHistoryByGoodsIssuedDetails(goodsIssuedDetailDtoForCreation!.ProductId);

            goodsIssuedDetailEntity.GoodsIssuedId = goodsIssuedId;
            goodsIssuedDetailEntity.UnitPrice = productHistory!.ProductPrice;
            goodsIssuedDetailEntity.CreatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            goodsIssuedDetailEntity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            goodsIssuedDetailEntity.Status = GoodsReceivedStatus.Active;

            await _repoManager.GoodsIssuedDetail.CreateGoodsIssuedDetailAsync(goodsIssuedDetailEntity);
            await _repoManager.SaveAsync();

            var goodsIssuedDetailDtoToReturn = _mapper.Map<GoodsIssuedDetailDto>(goodsIssuedDetailEntity);

            return goodsIssuedDetailDtoToReturn.CreatedResult();
        }

        private async Task<Result<GoodsIssued>> GetAndCheckIfGoodsIssuedIsExist(Guid goodsIssuedId, bool trackChanges, string? include)
        {
            var goodsIssued = await _repoManager.GoodsIssued.GetGoodsIssuedAsync(goodsIssuedId, trackChanges, include);
            if (goodsIssued == null) return goodsIssued.NotFound(goodsIssuedId);
            return goodsIssued.OkResult();
        }

        private async Task<bool> GetAndCheckIfGoodsIssuedWithReferenceNumberIsExist(string referenceNumber, Guid? goodsIssuedId, bool trackChanges)
        {
            var goodsIssued = await _repoManager.GoodsIssued.GetGoodsIssuedByIdAndReferenceNumberAsync(referenceNumber, goodsIssuedId, trackChanges);
            if (goodsIssued == null) return false;
            return true;
        }

        private async Task<bool> GetAndCheckIfWarehouseIdIsNotExist(Guid createdWareHouseManagerId)
        {
            var createdWareHouseManager = await _repoManager.Workplace.GetWorkplaceByIdAsync(createdWareHouseManagerId, false);
            if (createdWareHouseManager == null) return true;
            return false;
        }
    }
}
