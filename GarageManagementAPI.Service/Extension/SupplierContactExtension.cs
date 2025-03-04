using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.ErrorsConstant.SupplierContact;
using GarageManagementAPI.Shared.DataTransferObjects.SupplierContact;

namespace GarageManagementAPI.Service.Extension
{
    public static class SupplierContactExtension
    {
        public static Result<SupplierContact> OkResult(this SupplierContact SupplierContact)
           => Result<SupplierContact>.Ok(SupplierContact);

        public static Result<SupplierContactDto> OkResult(this SupplierContactDto SupplierContactDto)
            => Result<SupplierContactDto>.Ok(SupplierContactDto);

        public static Result<SupplierContactDto> CreatedResult(this SupplierContactDto SupplierContactDto)
            => Result<SupplierContactDto>.Created(SupplierContactDto);

        public static Result<SupplierContact> NotFound(this SupplierContact? supplierContact, Guid supplierContactId)
            => Result<SupplierContact>.NotFound([SupplierContactErrors.GetSupplierNotFoundWithIdError(supplierContactId)]);
    }
}
