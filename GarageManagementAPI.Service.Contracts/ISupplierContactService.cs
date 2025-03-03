using System.Dynamic;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.DataTransferObjects.SupplierContact;

namespace GarageManagementAPI.Service.Contracts
{
    public interface ISupplierContactService
    {
        public Task<Result<ExpandoObject>> GetSupplierContactAsync(Guid supplierContactId, SupplierContactParameters supplierContactParameters, bool trackChanges, string? include = null);
        public Task<Result<IEnumerable<ExpandoObject>>> GetSupplierContactsAsync(SupplierContactParameters supplierContactParameters, bool trackChanges, string? include = null);
        public Task<Result<IEnumerable<ExpandoObject>>> GetSupplierContactsBySupplierAsync(Guid supplierId,SupplierContactParameters supplierContactParameters, bool trackChanges, string? include = null);
        public Task<Result<SupplierContactDto>> CreateSupplierContactAsync(SupplierContactDtoForCreation supplierContactDtoForCreation);
        public Task<Result> UpdateSupplierContact(Guid SupplierContactId, SupplierContactDtoForUpdate supplierContactDtoForUpdate, bool trackChanges);
    }
}
