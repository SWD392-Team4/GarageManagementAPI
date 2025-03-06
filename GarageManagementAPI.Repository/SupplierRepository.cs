using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository
{
    public class SupplierRepository : RepositoryBase<Supplier>, ISupplierRepository
    {
        public SupplierRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CreateSupplierAsync(Supplier supplier)
        {
            await base.CreateAsync(supplier);
        }

        public async Task<Supplier?> GetSupplierAllPropertiesAsync(Supplier supplier, Guid? supplierId)
        {
            var address = supplier.Address!.Trim();
            var province = supplier.Province!.Trim();
            var district = supplier.District!.Trim();
            var ward = supplier.Wards!.Trim();
            var name = supplier.Name!.Trim();

            var supplierEntity = supplierId == null ? await FindByCondition(x =>
                (x.Address.Trim().Equals(address) &&
                 x.Province.Trim().Equals(province) &&
                 x.District.Trim().Equals(district) &&
                 x.Wards.Trim().Equals(ward)) ||
                x.Name.Trim().Equals(name),
                false).SingleOrDefaultAsync() : await FindByCondition(x =>
                ((x.Address.Trim().Equals(address) &&
                 x.Province.Trim().Equals(province) &&
                 x.District.Trim().Equals(district) &&
                 x.Wards.Trim().Equals(ward)) ||
                x.Name.Trim().Equals(name)) && x.Id != supplierId,
                false).SingleOrDefaultAsync();

            return supplierEntity;
        }

        public async Task<Supplier?> GetSupplierAsync(Guid supplierId, bool trackChanges, string? include = null)
        {
            var supplier = include is null ?
              await FindByCondition(u => u.Id.Equals(supplierId), trackChanges).SingleOrDefaultAsync() :
              await FindByCondition(u => u.Id.Equals(supplierId), trackChanges).Include(include).SingleOrDefaultAsync();

            return supplier;
        }

        public async Task<Supplier?> GetSupplierTaxCodeAsync(Guid? supplierId, string Taxcode)
        {
            var supplier = supplierId == null ? await FindByCondition(u => u.TaxCode == Taxcode, false).SingleOrDefaultAsync() :
            await FindByCondition(u => !u.Id.Equals(supplierId) && u.TaxCode == Taxcode, false).SingleOrDefaultAsync();
            return supplier;
        }

        public async Task<PagedList<Supplier>> GetSuppliersAsync(SupplierParameters supplierParameters, bool trackChanges, string? include = null)
        {
            var suppliers = await FindAll(trackChanges)
                 .SearchByName(supplierParameters.Name)
                 .SearchByAddress(supplierParameters.Address)
                 .SearchByDistrict(supplierParameters.District)
                 .SearchByProvince(supplierParameters.Province)
                 .SearchByTaxCode(supplierParameters.TaxCode)
                 .SearchByWards(supplierParameters.Wards)
                 .SearchByDate(supplierParameters.CreatedAt)
                 .SearchByDate(supplierParameters.UpdatedAt)
                 .SearchByStatus(supplierParameters.Status)
                 .Sort(supplierParameters.OrderBy)
                 .IsInclude(include)
                 .ToListAsync();
            return PagedList<Supplier>.ToPagedList(
                suppliers,
                supplierParameters.PageNumber,
                supplierParameters.PageSize
                );
        }

        public void UpdateSupplier(Supplier supplier)
        {
            base.Update(supplier);
        }
    }
}
