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

        public async Task<Result<GoodsIssuedDto>> CreateGoodsIssuedAsync(GoodsIssuedDtoForCreation goodsIssuedDtoForCreation)
        {
            var createdWarehouseManagerResult = await GetAndCheckIfCreatedWareHouseManagerIdNotExist(goodsIssuedDtoForCreation.CreatedWareHouseManagerId);
            var wareHouseResult = await GetAndCheckIfWarehouseIdIsNotExist(goodsIssuedDtoForCreation.WarehouseId);
            var goodsIssuedResult = await GetAndCheckIfGoodsIssuedWithReferenceNumberIsExist(goodsIssuedDtoForCreation.ReferenceNumber, null, false);
            if(goodsIssuedResult) return Result<GoodsIssuedDto>.BadRequest([GoodsIssuedErrors.GetGoodsIssuedReferenceIsExist(goodsIssuedDtoForCreation.ReferenceNumber)]);
            if (createdWarehouseManagerResult) return Result<GoodsIssuedDto>.BadRequest([GoodsIssuedErrors.GetMangerIsNotFoundWithIdError(goodsIssuedDtoForCreation.CreatedWareHouseManagerId)]);
            if(wareHouseResult) return Result<GoodsIssuedDto>.BadRequest([GoodsIssuedErrors.GetWareHourseIsNotFoundWithIdError(goodsIssuedDtoForCreation.WarehouseId)]);

            var goodsIssuedEntity = _mapper.Map<GoodsIssued>(goodsIssuedDtoForCreation);

            goodsIssuedEntity.CreatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            goodsIssuedEntity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            goodsIssuedEntity.Status = GoodsIssuedStatus.Inactive;


            await _repoManager.GoodsIssued.CreateGoodsIssuedAsync(goodsIssuedEntity);
            await _repoManager.SaveAsync();
            var goodsIssuedDtoToReturn = _mapper.Map<GoodsIssuedDto>(goodsIssuedEntity);
            return goodsIssuedDtoToReturn.CreatedResult();
        }
        public async Task<Result> UpdateGoodsIssued(Guid goodsIssuedId, GoodsIssuedDtoForUpdate goodsIssuedDtoForUpdate, bool trackChanges)
        {
            var goodsIssuedResult = await GetAndCheckIfGoodsIssuedIsExist(goodsIssuedId, trackChanges, null);
            var createdWarehouseManagerResult = await GetAndCheckIfCreatedWareHouseManagerIdNotExist(goodsIssuedDtoForUpdate.CreatedWareHouseManagerId);
            var wareHouseResult = await GetAndCheckIfWarehouseIdIsNotExist(goodsIssuedDtoForUpdate.WarehouseId);
            var goodsIssuedReferenceNameResult = await GetAndCheckIfGoodsIssuedWithReferenceNumberIsExist(goodsIssuedDtoForUpdate.ReferenceNumber, goodsIssuedId, false);
            if (!goodsIssuedResult.IsSuccess)
                return Result<GoodsIssuedDtoForUpdate>.Failure(goodsIssuedResult.StatusCode, goodsIssuedResult.Errors!);
            if (goodsIssuedReferenceNameResult) return Result<GoodsIssuedDto>.BadRequest([GoodsIssuedErrors.GetGoodsIssuedReferenceIsExist(goodsIssuedDtoForUpdate.ReferenceNumber)]);
            if (createdWarehouseManagerResult) return Result<GoodsIssuedDto>.BadRequest([GoodsIssuedErrors.GetMangerIsNotFoundWithIdError(goodsIssuedDtoForUpdate.CreatedWareHouseManagerId)]);
            if (wareHouseResult) return Result<GoodsIssuedDto>.BadRequest([GoodsIssuedErrors.GetWareHourseIsNotFoundWithIdError(goodsIssuedDtoForUpdate.WarehouseId)]);
            
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

        private async Task<Result<GoodsIssued>> GetAndCheckIfGoodsIssuedIsExist(Guid goodsIssuedId, bool trackChanges, string? include)
        {
            var goodsIssued = await _repoManager.GoodsIssued.GetGoodsIssuedAsync(goodsIssuedId, trackChanges, include);
            if (goodsIssued == null) return goodsIssued.NotFound(goodsIssuedId);
            return goodsIssued.OkResult();
        }

        private async Task<bool> GetAndCheckIfGoodsIssuedWithReferenceNumberIsExist(string referenceNumber,Guid? goodsIssuedId, bool trackChanges)
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

        private async Task<bool> GetAndCheckIfCreatedWareHouseManagerIdNotExist(Guid createdWareHouseManagerId)
        {
            var createdWareHouseManager = await _repoManager.User.GetUserByIdAsync(createdWareHouseManagerId, false);
            if (createdWareHouseManager == null) return true;
            return false;
        }
    }
}
