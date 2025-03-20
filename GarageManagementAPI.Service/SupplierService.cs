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
using GarageManagementAPI.Shared.ErrorsConstant.Supplier;
using GarageManagementAPI.Shared.DataTransferObjects.Supplier;

namespace GarageManagementAPI.Service
{
    public class SupplierService : ISupplierService
    {
        private readonly IRepositoryManager _repoManager;
        private readonly IMapper _mapper;
        private readonly IDataShaperManager _dataShaper;

        public SupplierService(IRepositoryManager repoManager, IMapper mapper, IDataShaperManager dataShaper)
        {
            _repoManager = repoManager;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }

        public async Task<Result<SupplierDto>> CreateSupplierAsync(SupplierDtoForCreation supplierDtoForCreation)
        {
            var supplierEntity = _mapper.Map<Supplier>(supplierDtoForCreation);
            var supplierPropertiyResult = await GetAndCheckIfSupplierSame(supplierEntity);
            if (supplierPropertiyResult)
                return Result<SupplierDto>.BadRequest([SupplierErrors.GetSupplierAlreadyExistError(supplierDtoForCreation)]);
            supplierEntity.CreatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            supplierEntity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            supplierEntity.Status = SupplierStatus.Inactive;

            await _repoManager.Supplier.CreateSupplierAsync(supplierEntity);
            await _repoManager.SaveAsync();

            var supplierDtoToReturn = _mapper.Map<SupplierDto>(supplierEntity);

            return supplierDtoToReturn.CreatedResult();
        }


        public async Task<Result<ExpandoObject>> GetSupplierAsync(Guid supplierId, SupplierParameters supplierParameters, bool trackChanges, string? include = null)
        {
            var supplierResult = await GetAndCheckIfSupplierExist(supplierId, trackChanges);

            if (!supplierResult.IsSuccess)
                return Result<ExpandoObject>.NotFound(supplierResult.Errors!);

            var supplierEntity = supplierResult.GetValue<Supplier>();

            var suppliersDto = _mapper.Map<SupplierDto>(supplierEntity);

            var SupplierShaped = _dataShaper.Supplier.ShapeData(suppliersDto, supplierParameters.Fields);

            return Result<ExpandoObject>.Ok(SupplierShaped);
        }

        public async Task<Result<IEnumerable<ExpandoObject>>>  GetSuppliersAsync(SupplierParameters supplierParameters, bool trackChanges, string? include)
        {
            var suppliersWithMetadata = await _repoManager.Supplier.GetSuppliersAsync(supplierParameters, trackChanges, include);

            var suppliersDto = _mapper.Map<IEnumerable<SupplierDto>>(suppliersWithMetadata);

            var suppliersShaped = _dataShaper.Supplier.ShapeData(suppliersDto, supplierParameters.Fields);

            return Result<IEnumerable<ExpandoObject>>.Ok(suppliersShaped, suppliersWithMetadata.MetaData);
        }
        public async Task<Result> UpdateSupplier(Guid supplierId, SupplierDtoForUpdate supplierDtoForUpdate, bool trackChanges)
        {
            var supplierIsExistResult = await GetAndCheckIfSupplierExist(supplierId, trackChanges);
            if (!supplierIsExistResult.IsSuccess)
                return Result<SupplierDto>.Failure(supplierIsExistResult.StatusCode, supplierIsExistResult.Errors!);

            var supplierUpdate = _mapper.Map<Supplier>(supplierDtoForUpdate);

            var supplierResult = await GetAndCheckIfSupplierSame(supplierUpdate, supplierId);
            if (supplierResult)
                return Result<SupplierDto>.BadRequest([SupplierErrors.GetSupplierAlreadyExistError(supplierDtoForUpdate)]);
           
            var supplierEntity = supplierIsExistResult.GetValue<Supplier>();

            _mapper.Map(supplierDtoForUpdate, supplierEntity);

            supplierEntity.UpdatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();

            await _repoManager.SaveAsync();

            return Result.NoContent();
        }

        private async Task<Result<Supplier>> GetAndCheckIfSupplierExist(Guid supplierId, bool trackChanges)
        {
            var Supplier = await _repoManager.Supplier.GetSupplierAsync(supplierId, trackChanges);
            if (Supplier == null)
                return Supplier.NotFound(supplierId);
            return Supplier.OkResult();
        }
        private async Task<bool> GetAndCheckIfSupplierSame(Supplier supplier, Guid? supplierId = null)
        {
            var supplierEntity = await _repoManager.Supplier.GetSupplierAllPropertiesAsync(supplier, supplierId);
            if (supplierEntity == null)
                return false;
            return true;
        }

        private async Task<bool> GetAndCheckIfSupplierTaxcodeSame(string taxCode, Guid? supplierId = null)
        {
            var supplierEntity = await _repoManager.Supplier.GetSupplierTaxCodeAsync(supplierId, taxCode);
            if (supplierEntity == null)
                return false;
            return true;
        }
    }
}
