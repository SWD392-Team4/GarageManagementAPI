using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository
{
    public class BrandRepository : RepositoryBase<Brand>, IBrandRepository
    {
        public BrandRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CreateBrandAsync(Brand brand)
        {
            await base.CreateAsync(brand);
        }

        public async Task<Brand?> GetBrandByIdAndNameAsync(string name, Guid? brandId, bool trackChanges)
        {
            var brand = brandId is null ?
            await FindByCondition(b => b.BrandName.Equals(name), trackChanges).SingleOrDefaultAsync() :
            await FindByCondition(b => !b.Id.Equals(brandId) && b.BrandName.ToLower().Equals(name.ToLower()), trackChanges).SingleOrDefaultAsync();
            return brand;
        }

        public async Task<Brand?> GetBrandByIdAsync(Guid brandId, bool trackChanges, string? include = null)
        {
            var brand = include is null ?
             await FindByCondition(u => u.Id.Equals(brandId), trackChanges).SingleOrDefaultAsync() :
             await FindByCondition(u => u.Id.Equals(brandId), trackChanges).Include(include).SingleOrDefaultAsync();

            return brand;
        }

        public async Task<PagedList<Brand>> GetBrandsAsync(BrandParameters brandParameters, bool trackChanges, string? include = null)
        {
            var brandsQuery = brandParameters.PageSize == 0 ? 
                await FindAll(trackChanges)
                .SearchByName(brandParameters.BrandName) 
                .SearchByDate(brandParameters.CreatedAt) 
                .SearchByDate(brandParameters.UpdateAt) 
                .SearchByStatus(brandParameters.Status)
                .Sort(brandParameters.OrderBy)
                .IsInclude(include)
                .ToListAsync()
                : 
                await FindAll(trackChanges)
                .SearchByName(brandParameters.BrandName) 
                .SearchByDate(brandParameters.CreatedAt) 
                .SearchByDate(brandParameters.UpdateAt) 
                .SearchByStatus(brandParameters.Status)
                .Sort(brandParameters.OrderBy)
                .IsInclude(include)
                .Skip((brandParameters.PageNumber - 1) * brandParameters.PageSize)
                .Take(brandParameters.PageSize)
                .ToListAsync();
            var count = await FindAll(trackChanges).CountAsync();

            // Trả về kết quả dưới dạng PagedList
            return new PagedList<Brand>(
                brandsQuery,
                count,
                brandParameters.PageNumber == 0 ? 1 : brandParameters.PageNumber,
                brandParameters.PageSize == 0 ? count : brandParameters.PageSize
            );
        }


        public void UpdateBrandAsync(Brand brand)
        {
            base.Update(brand);
        }
    }
}
