using System.Dynamic;
using GarageManagementAPI.Shared.ResultModel;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.DataTransferObjects.Supplier;

namespace GarageManagementAPI.Service.Contracts
{
    public interface ISupplierService
    {
        public Task<Result<ExpandoObject>> GetSupplierAsync(Guid SupplierId, SupplierParameters supplierParameters, bool trackChanges, string? include = null);
        public Task<Result<IEnumerable<ExpandoObject>>> GetSuppliersAsync(SupplierParameters brans, bool trackChanges, string? include = null);
        public Task<Result<SupplierDto>> CreateSupplierAsync(SupplierDtoForCreation SupplierDtoForCreation);
        public Task<Result> UpdateSupplier(Guid SupplierId, SupplierDtoForUpdate SupplierDtoForUpdate, bool trackChanges);
    }
}
