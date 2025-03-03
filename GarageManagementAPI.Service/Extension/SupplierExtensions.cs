using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.ErrorsConstant.Supplier;
using GarageManagementAPI.Shared.DataTransferObjects.Supplier;

namespace GarageManagementAPI.Service.Extension
{
    public static class SupplierExtensions
    {
        public static Result<Supplier> OkResult(this Supplier supplier)
           => Result<Supplier>.Ok(supplier);

        public static Result<SupplierDto> OkResult(this SupplierDto supplierDto)
            => Result<SupplierDto>.Ok(supplierDto);

        public static Result<SupplierDto> CreatedResult(this SupplierDto supplierDto)
            => Result<SupplierDto>.Created(supplierDto);

        public static Result<Supplier> NotFound(this Supplier? supplierDto, Guid supplierId)
            => Result<Supplier>.NotFound([SupplierErrors.GetSupplierNotFoundWithIdError(supplierId)]);
    }
}
