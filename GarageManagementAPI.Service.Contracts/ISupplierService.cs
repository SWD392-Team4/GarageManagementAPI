using System.Dynamic;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.DataTransferObjects.Supplier;

namespace GarageManagementAPI.Service.Contracts
{
    public interface ISupplierService
    {
        public Task<Result<ExpandoObject>> GetSupplierAsync(Guid SupplierId, SupplierParameters supplierParameters, bool trackChanges, string? include = null);
        public Task<Result<IEnumerable<ExpandoObject>>> GetSuppliersAsync(SupplierParameters supplierParameters, bool trackChanges, string? include = null);
        public Task<Result<SupplierDto>> CreateSupplierAsync(SupplierDtoForCreation supplierDtoForCreation);
        public Task<Result> UpdateSupplier(Guid supplierId, SupplierDtoForUpdate supplierDtoForUpdate, bool trackChanges);
    }
}
