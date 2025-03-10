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
using GarageManagementAPI.Shared.ErrorsConstant.GoodsReceived;
using GarageManagementAPI.Shared.DataTransferObjects.GoodsReceived;
using GarageManagementAPI.Shared.DataTransferObjects.GoodsReceivedDetail;

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

        public async Task<Result<GoodsReceivedDto>> CreateGoodsReceivedAsync(GoodsReceivedDtoForCreation goodsReceivedDtoForCreation, Guid createdWarehouseManagerId)
        {
            var goodsReceivedEntity = _mapper.Map<GoodsReceived>(goodsReceivedDtoForCreation);
            var wareHouseResult = await GetAndCheckIfWarehouseIdIsNotExist(goodsReceivedDtoForCreation.WarehouseId);
            var supplierContactResult = await GetAndCheckIfSupplierContactIdNotExist(goodsReceivedDtoForCreation.SupplierContactId);
            var addressResult = await GetAndCheckIfGoodsReceivedExistByAddressCode(goodsReceivedEntity);
            var invoiceResult = await GetAndCheckIfGoodsReceivedExistByInvoiceCode(goodsReceivedEntity.InvoiceCode);
            var numberResult = await GetAndCheckIfGoodsReceivedExistByRefereneceNumber(goodsReceivedEntity.RefereneceNumber);
            if (!addressResult.IsSuccess)
                return Result<GoodsReceivedDto>.NotFound(addressResult.Errors!);
            if (!invoiceResult.IsSuccess)
                return Result<GoodsReceivedDto>.NotFound(invoiceResult.Errors!);
            if (!numberResult.IsSuccess)
                return Result<GoodsReceivedDto>.NotFound(numberResult.Errors!);
            if (wareHouseResult) return Result<GoodsReceivedDto>.BadRequest([GoodsReceivedErrors.GetMangerIsNotFoundWithIdError(goodsReceivedDtoForCreation.WarehouseId)]);
            if (supplierContactResult) return Result<GoodsReceivedDto>.BadRequest([GoodsReceivedErrors.GetGoodsReceivedWithSupplierContactNotFoundIdError(goodsReceivedDtoForCreation.SupplierContactId)]);

            goodsReceivedEntity.CreatedWarehouseManagerId = createdWarehouseManagerId;
            goodsReceivedEntity.CreatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            goodsReceivedEntity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            goodsReceivedEntity.Status = GoodsReceivedStatus.Inactive;
            foreach (var goodsIssuedDetailDtoForCreation in goodsReceivedDtoForCreation.goodsIssuedDetailDtoForCreations)
            {
                goodsReceivedEntity.TotalPrice += goodsIssuedDetailDtoForCreation.UnitPrice * goodsIssuedDetailDtoForCreation.Quantity;
            }
           

            await _repoManager.GoodsReceived.CreateGoodsReceivedAsync(goodsReceivedEntity);
            await _repoManager.SaveAsync();

            var goodsReceivedDtoToReturn = _mapper.Map<GoodsReceivedDto>(goodsReceivedEntity);

            foreach (var goodsIssuedDetailDtoForCreation in goodsReceivedDtoForCreation.goodsIssuedDetailDtoForCreations)
            {
                await this.CreateGoodsReceivedDetailAsync(goodsReceivedDtoToReturn.Id, goodsIssuedDetailDtoForCreation);
            }

            return goodsReceivedDtoToReturn.CreatedResult();
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
            var wareHouseResult = await GetAndCheckIfWarehouseIdIsNotExist(goodsReceivedDtoForUpdate.WarehouseId);
            var supplierContactResult = await GetAndCheckIfSupplierContactIdNotExist(goodsReceivedDtoForUpdate.SupplierContactId);
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
            if (wareHouseResult) return Result<GoodsReceivedDto>.BadRequest([GoodsReceivedErrors.GetMangerIsNotFoundWithIdError(goodsReceivedDtoForUpdate.WarehouseId)]);
            if (supplierContactResult) return Result<GoodsReceivedDto>.BadRequest([GoodsReceivedErrors.GetGoodsReceivedWithSupplierContactNotFoundIdError(goodsReceivedDtoForUpdate.SupplierContactId)]);
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

        private async Task<bool> GetAndCheckIfSupplierContactIdNotExist(Guid supplierContactId)
        {
            var createdWareHouseManager = await _repoManager.SupplierContact.GetSupplierContactAsync(supplierContactId, false);
            if (createdWareHouseManager == null) return true;
            return false;
        }

        private async Task<Result<GoodsReceivedDetail>> GetAndCheckIfGoodsReceivedByGoodReceivedAndProductExist(Guid goodReceivedId, Guid productId, bool trackChanges, Guid? goodsReceivedDetailId = null, string? include = null)
        {
            var goodReceived = await _repoManager.GoodsReceivedDetail.GetGoodsReceivedDetailByProductAndGoodsReceivedAsync(productId, goodReceivedId, goodsReceivedDetailId, trackChanges);
            if (goodReceived != null)
                return goodReceived.ExistedWithId(productId, goodReceivedId);

            return goodReceived!.OkResult();
        }

        public async Task CreateGoodsReceivedDetailAsync(Guid goodsReceivedId, GoodsReceivedDetailDtoForCreationGoods goodsReceivedDetailDtoForCreation)
        {

            var goodsReceivedDetailEntity = _mapper.Map<GoodsReceivedDetail>(goodsReceivedDetailDtoForCreation);

            goodsReceivedDetailEntity.GoodsReceivedId = goodsReceivedId;
            goodsReceivedDetailEntity.TotalPrice = goodsReceivedDetailDtoForCreation.UnitPrice * goodsReceivedDetailDtoForCreation.Quantity;
            goodsReceivedDetailEntity.CreatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            goodsReceivedDetailEntity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            goodsReceivedDetailEntity.Status = GoodsReceivedDetailStatus.Inactive;

            await _repoManager.GoodsReceivedDetail.CreateGoodsReceivedDetailAsync(goodsReceivedDetailEntity);
            await _repoManager.SaveAsync();
        }
    }
}
