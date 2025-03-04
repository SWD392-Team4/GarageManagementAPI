using AutoMapper;
using System.Dynamic;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Service.Extension;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.DataTransferObjects.GoodsReceived;

namespace GarageManagementAPI.Service
{
    public class GoodsReceivedService : IGoodsReceivedService
    {
        private readonly IRepositoryManager _repoManager;
        private readonly IMapper _mapper;
        private readonly IDataShaperManager _dataShaper;

        public GoodsReceivedService(IRepositoryManager repoManager, IMapper mapper, IDataShaperManager dataShaper)
        {
            _repoManager = repoManager;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }

        public async Task<Result<GoodsReceivedDto>> CreateGoodsReceivedAsync(GoodsReceivedDtoForCreation goodsReceivedDtoForCreation)
        {
            var goodsReceivedEntity = _mapper.Map<GoodsReceived>(goodsReceivedDtoForCreation);

            var addressResult = await GetAndCheckIfGoodsReceivedExistByAddressCode(goodsReceivedEntity);
            var invoiceResult = await GetAndCheckIfGoodsReceivedExistByInvoiceCode(goodsReceivedEntity.InvoiceCode);
            var numberResult = await GetAndCheckIfGoodsReceivedExistByRefereneceNumber(goodsReceivedEntity.RefereneceNumber);
            if (!addressResult.IsSuccess)
                return Result<GoodsReceivedDto>.NotFound(addressResult.Errors!);
            if (!invoiceResult.IsSuccess)
                return Result<GoodsReceivedDto>.NotFound(invoiceResult.Errors!);
            if (!numberResult.IsSuccess)
                return Result<GoodsReceivedDto>.NotFound(numberResult.Errors!);

            goodsReceivedEntity.CreatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            goodsReceivedEntity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            goodsReceivedEntity.Status = GoodsReceivedStatus.Inactive;

            await _repoManager.GoodsReceived.CreateGoodsReceivedAsync(goodsReceivedEntity);
            await _repoManager.SaveAsync();

            var GoodsReceivedDtoToReturn = _mapper.Map<GoodsReceivedDto>(goodsReceivedEntity);

            return GoodsReceivedDtoToReturn.CreatedResult();
        }

        public async Task<Result<ExpandoObject>> GetGoodsReceivedAsync(Guid goodsReceivedId, GoodsReceivedParameters goodsReceivedParameterdParameters, bool trackChanges, string? include = null)
        {
            var goodsReceivedResult = await GetAndCheckIfGoodsReceivedExist(goodsReceivedId, trackChanges, include);

            if (!goodsReceivedResult.IsSuccess)
                return Result<ExpandoObject>.NotFound(goodsReceivedResult.Errors!);

            var goodsReceivedEntity = goodsReceivedResult.GetValue<GoodsReceived>();

            var goodsReceivedsDto = _mapper.Map<GoodsReceivedDto>(goodsReceivedEntity);

            var GoodsReceivedShaped = _dataShaper.GoodsReceived.ShapeData(goodsReceivedsDto, goodsReceivedParameterdParameters.Fields);

            return Result<ExpandoObject>.Ok(GoodsReceivedShaped);
        }

        public async Task<Result<IEnumerable<ExpandoObject>>> GetGoodsReceivedsAsync(GoodsReceivedParameters goodsReceivedParameterdParameters, bool trackChanges, string? include = null)
        {
            var goodsReceivedsWithMetadata = await _repoManager.GoodsReceived.GetGoodsReceivedsAsync(goodsReceivedParameterdParameters, trackChanges, include);

            var goodsReceivedsDto = _mapper.Map<IEnumerable<GoodsReceivedDto>>(goodsReceivedsWithMetadata);

            var goodsReceivedsShaped = _dataShaper.GoodsReceived.ShapeData(goodsReceivedsDto, goodsReceivedParameterdParameters.Fields);

            return Result<IEnumerable<ExpandoObject>>.Ok(goodsReceivedsShaped, goodsReceivedsWithMetadata.MetaData);
        }

        public async Task<Result> UpdateGoodsReceived(Guid goodsReceivedId, GoodsReceivedDtoForUpdate goodsReceivedDtoForUpdate, bool trackChanges)
        {
            var goodsReceived= _mapper.Map<GoodsReceived>(goodsReceivedDtoForUpdate);

            var addressResult = await GetAndCheckIfGoodsReceivedExistByAddressCode(goodsReceived, goodsReceivedId);
            var invoiceResult = await GetAndCheckIfGoodsReceivedExistByInvoiceCode(goodsReceived.InvoiceCode, goodsReceivedId);
            var numberResult = await GetAndCheckIfGoodsReceivedExistByRefereneceNumber(goodsReceived.RefereneceNumber, goodsReceivedId);
            var goodsReceivedResult = await GetAndCheckIfGoodsReceivedExist(goodsReceivedId, trackChanges);

            if (!goodsReceivedResult.IsSuccess)
                return Result<ExpandoObject>.NotFound(goodsReceivedResult.Errors!);
            if (!addressResult.IsSuccess)
                return Result<GoodsReceivedDto>.NotFound(addressResult.Errors!);
            if (!invoiceResult.IsSuccess)
                return Result<GoodsReceivedDto>.NotFound(invoiceResult.Errors!);
            if (!numberResult.IsSuccess)
                return Result<GoodsReceivedDto>.NotFound(numberResult.Errors!);
            var goodsReceivedEntity = goodsReceivedResult.GetValue<GoodsReceived>();

            _mapper.Map(goodsReceivedDtoForUpdate, goodsReceivedEntity);

            goodsReceivedEntity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();

            await _repoManager.SaveAsync();

            return Result.NoContent();
        }

        private async Task<Result<GoodsReceived>> GetAndCheckIfGoodsReceivedExistByRefereneceNumber(string refereneceNumber, Guid? goodsReceivedId = null)
        {
            var goodsReceived = await _repoManager.GoodsReceived.GetGoodsReceivedByRefereneceNumberAsync(goodsReceivedId, refereneceNumber, false);
            if (goodsReceived != null) return goodsReceived.ExistedWithReferenceName(refereneceNumber);
            return goodsReceived!.OkResult();
        }

        private async Task<Result<GoodsReceived>> GetAndCheckIfGoodsReceivedExistByInvoiceCode(string invoiceCode, Guid? goodsReceivedId = null)
        {
            var goodsReceived = await _repoManager.GoodsReceived.GetGoodsReceivedByRefereneceNumberAsync(goodsReceivedId, invoiceCode, false);
            if (goodsReceived != null) return goodsReceived.ExistedWithInvoiceCode(invoiceCode);
            return goodsReceived!.OkResult();
        }

        private async Task<Result<GoodsReceived>> GetAndCheckIfGoodsReceivedExistByAddressCode(GoodsReceived goodsReceivedEntity, Guid? goodsReceivedId = null)
        {
            var goodsReceived = await _repoManager.GoodsReceived.GetGoodsReceivedByAddressAsync(goodsReceivedId, goodsReceivedEntity, false);
            if (goodsReceived == null) return  goodsReceived!.OkResult();
            return goodsReceived.ExistedWithAddress(goodsReceivedEntity);
             
        }
        private async Task<Result<GoodsReceived>> GetAndCheckIfGoodsReceivedExist(Guid goodsReceivedId, bool trackChanges, string? include = null)
        {
            var goodsReceived = await _repoManager.GoodsReceived.GetGoodsReceivedAsync(goodsReceivedId, trackChanges, include);
            if (goodsReceived == null)
                return goodsReceived.NotFound(goodsReceivedId);

            return goodsReceived.OkResult();
        }
    }
}
