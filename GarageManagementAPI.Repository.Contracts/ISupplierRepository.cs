using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface ISupplierRepository
    {
        Task<Supplier?> GetSupplierAsync(Guid supplierId, bool trackChanges, string? include = default);
        Task<PagedList<Supplier>> GetSuppliersAsync(SupplierParameters supplierParameters, bool trackChanges, string? include = default);
        Task<Supplier?> GetSupplierAllPropertiesAsync(Supplier supplier, Guid? supplierId);
        Task<Supplier?> GetSupplierTaxCodeAsync(Guid? supplierId, string Taxcode);
        public Task CreateSupplierAsync(Supplier supplier);
        void UpdateSupplier(Supplier supplier);
    }
}
