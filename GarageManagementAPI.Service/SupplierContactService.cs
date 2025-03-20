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
using GarageManagementAPI.Shared.ErrorsConstant.SupplierContact;
using GarageManagementAPI.Shared.DataTransferObjects.SupplierContact;

namespace GarageManagementAPI.Service
{
    public class SupplierContactService : ISupplierContactService
    {
        private readonly IRepositoryManager _repoManager;
        private readonly IMapper _mapper;
        private readonly IDataShaperManager _dataShaper;

        public SupplierContactService(IRepositoryManager repoManager, IMapper mapper, IDataShaperManager dataShaper)
        {
            _repoManager = repoManager;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }

        public async Task<Result<SupplierContactDto>> CreateSupplierContactAsync(SupplierContactDtoForCreation supplierContactDtoForCreation)
        {
            var supplierEntity = _mapper.Map<SupplierContact>(supplierContactDtoForCreation);
            var supplierPropertiyResult = await GetAndCheckIfSupplierContactSame(null, supplierEntity);

            if (supplierPropertiyResult)
                return Result<SupplierContactDto>.BadRequest([SupplierContactErrors.GetSupplierAlreadyExistError(supplierContactDtoForCreation)]);

            supplierEntity.CreatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            supplierEntity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            supplierEntity.Status = SupplierContactStatus.Inactive;

            await _repoManager.SupplierContact.CreateSupplierContactAsync(supplierEntity);
            await _repoManager.SaveAsync();

            var supplierDtoToReturn = _mapper.Map<SupplierContactDto>(supplierEntity);

            return supplierDtoToReturn.CreatedResult();
        }

        public async Task<Result<ExpandoObject>> GetSupplierContactAsync(Guid supplierContactId, SupplierContactParameters supplierContactParameters, bool trackChanges, string? include = null)
        {
            var supplierResult = await GetAndCheckIfSupplierContactSupplierExist(supplierContactId, trackChanges);

            if (!supplierResult.IsSuccess)
                return Result<ExpandoObject>.NotFound(supplierResult.Errors!);

            var supplierEntity = supplierResult.GetValue<SupplierContact>();

            var suppliersDto = _mapper.Map<SupplierContactDto>(supplierEntity);

            var supplierShaped = _dataShaper.SupplierContact.ShapeData(suppliersDto, supplierContactParameters.Fields);

            return Result<ExpandoObject>.Ok(supplierShaped);
        }

        public async Task<Result<IEnumerable<ExpandoObject>>> GetSupplierContactsAsync(SupplierContactParameters supplierContactParameters, bool trackChanges, string? include = null)
        {
            var suppliersWithMetadata = await _repoManager.SupplierContact.GetSupplierContactsAsync(supplierContactParameters, trackChanges, include);

            var suppliersDto = _mapper.Map<IEnumerable<SupplierContactDto>>(suppliersWithMetadata);

            var suppliersShaped = _dataShaper.SupplierContact.ShapeData(suppliersDto, supplierContactParameters.Fields);

            return Result<IEnumerable<ExpandoObject>>.Ok(suppliersShaped, suppliersWithMetadata.MetaData);
        }

        public async Task<Result<IEnumerable<ExpandoObject>>> GetSupplierContactsBySupplierAsync(Guid supplierId, SupplierContactParameters supplierContactParameters, bool trackChanges, string? include = null)
        {
            var suppliersWithMetadata = await _repoManager.SupplierContact.GetSupplierContactsBySupplierAsync(supplierId, supplierContactParameters, trackChanges, include);

            var suppliersDto = _mapper.Map<IEnumerable<SupplierContactDto>>(suppliersWithMetadata);

            var suppliersShaped = _dataShaper.SupplierContact.ShapeData(suppliersDto, supplierContactParameters.Fields);

            return Result<IEnumerable<ExpandoObject>>.Ok(suppliersShaped, suppliersWithMetadata.MetaData);
        }

        public async Task<Result> UpdateSupplierContact(Guid supplierContactId, SupplierContactDtoForUpdate supplierContactDtoForUpdate, bool trackChanges)
        {
            var supplierIsExistResult = await GetAndCheckIfSupplierContactSupplierExist(supplierContactId, trackChanges);
            if (!supplierIsExistResult.IsSuccess)
                return Result<SupplierContactDto>.Failure(supplierIsExistResult.StatusCode, supplierIsExistResult.Errors!);

            var supplierUpdate = _mapper.Map<SupplierContact>(supplierContactDtoForUpdate);

            var supplierResult = await GetAndCheckIfSupplierContactSame(supplierContactId, supplierUpdate);
            if (supplierResult)
                return Result<SupplierContactDto>.BadRequest([SupplierContactErrors.GetSupplierAlreadyExistError(supplierContactDtoForUpdate)]);

            var supplierEntity = supplierIsExistResult.GetValue<SupplierContact>();

            _mapper.Map(supplierContactDtoForUpdate, supplierEntity);

            supplierEntity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();

            await _repoManager.SaveAsync();

            return Result.NoContent();
        }

        private async Task<bool> GetAndCheckIfSupplierContactSame(Guid? supplierContactId, SupplierContact supplierContact)
        {
            var supplierContactEntity = await _repoManager.SupplierContact.GetSupplierContactAllPropertyAsync(supplierContactId, supplierContact, false);
            if (supplierContactEntity == null)
                return false;
            return true;
        }

        private async Task<Result<SupplierContact>> GetAndCheckIfSupplierContactSupplierExist(Guid supplierContactId, bool trackChanges)
        {
            var supplier = await _repoManager.SupplierContact.GetSupplierContactAsync(supplierContactId, trackChanges);
            if (supplier == null)
                return supplier.NotFound(supplierContactId);
            return supplier.OkResult();
        }
    }
}
