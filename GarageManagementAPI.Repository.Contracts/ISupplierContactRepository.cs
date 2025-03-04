using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface ISupplierContactRepository
    {
        Task<SupplierContact?> GetSupplierContactAsync(Guid supplierContactId, bool trackChanges, string? include = default);
        Task<SupplierContact?> GetSupplierContactAllPropertyAsync(SupplierContact supplier, bool trackChanges);
        Task<PagedList<SupplierContact>> GetSupplierContactsBySupplierAsync(Guid suppplierId,SupplierContactParameters supplierContactParameters, bool trackChanges, string? include = default);
        Task<PagedList<SupplierContact>> GetSupplierContactsAsync(SupplierContactParameters supplierContactParameters, bool trackChanges, string? include = default);
        Task CreateSupplierContactAsync(SupplierContact supplierContact);
        void UpdateSupplierContact(SupplierContact supplierContact);
    }
}
