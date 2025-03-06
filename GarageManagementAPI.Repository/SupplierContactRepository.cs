using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository
{
    public class SupplierContactRepository : RepositoryBase<SupplierContact>, ISupplierContactRepository
    {
        public SupplierContactRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public async Task CreateSupplierContactAsync(SupplierContact supplierContact)
        {
            await base.CreateAsync(supplierContact);
        }

        public async Task<SupplierContact?> GetSupplierContactAllPropertyAsync(SupplierContact supplier, bool trackChanges)
        {
            var supplierEntity = supplier?.Id == null ?
                 await FindByCondition(s => s.ContactEmail.ToLower().Equals(supplier!.ContactEmail.ToLower()) || s.ContactPhoneNumber.ToLower().Equals(supplier.ContactPhoneNumber.ToLower()), false).SingleOrDefaultAsync() :
                 await FindByCondition(s => (s.ContactEmail.ToLower().Equals(supplier.ContactEmail) || s.ContactPhoneNumber.ToLower().Equals(supplier.ContactPhoneNumber.ToLower())) && s.Id != supplier.Id, false).SingleOrDefaultAsync();
            return supplierEntity;
        }

        public async Task<SupplierContact?> GetSupplierContactAsync(Guid supplierContactId, bool trackChanges, string? include = null)
        {
            var supplier = await FindByCondition(s => s.Id == supplierContactId, trackChanges).SingleOrDefaultAsync();
            return supplier;
        }

        public async Task<PagedList<SupplierContact>> GetSupplierContactsAsync(SupplierContactParameters supplierContactParameters, bool trackChanges, string? include = null)
        {
            var suppliers = await FindAll(trackChanges)
                .SearchByName(supplierContactParameters.ContactPersonName)
                .SearchByEmail(supplierContactParameters.ContactEmail)
                .SearchByhoneNumber(supplierContactParameters.ContactPhoneNumber)
                .SearchByPosition(supplierContactParameters.ContactPosition)
                .IsInclude(include)
                .ToListAsync();
            return PagedList<SupplierContact>.ToPagedList(
                 suppliers,
                 supplierContactParameters.PageNumber,
                 supplierContactParameters.PageSize
                 );
        }

        public async Task<PagedList<SupplierContact>> GetSupplierContactsBySupplierAsync(Guid suppplierId, SupplierContactParameters supplierContactParameters, bool trackChanges, string? include = null)
        {
            var suppliers = await FindByCondition(s => s.SupplierId == suppplierId, trackChanges)
                .SearchByName(supplierContactParameters.ContactPersonName)
                .SearchByEmail(supplierContactParameters.ContactEmail)
                .SearchByhoneNumber(supplierContactParameters.ContactPhoneNumber)
                .SearchByPosition(supplierContactParameters.ContactPosition)
                .IsInclude(include)
                .Skip((supplierContactParameters.PageNumber - 1) * supplierContactParameters.PageSize)
                .Take(supplierContactParameters.PageSize)
                .ToListAsync();

            return PagedList<SupplierContact>.ToPagedList(
                 suppliers,
                 supplierContactParameters.PageNumber,
                 supplierContactParameters.PageSize
                 );
        }

        public void UpdateSupplierContact(SupplierContact supplierContact)
        {
            base.Update(supplierContact);
        }
    }
}
