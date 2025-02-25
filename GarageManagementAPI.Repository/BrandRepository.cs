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
            // Lọc và sắp xếp danh sách brands theo các điều kiện
            var brandsQuery = await FindByCondition(b =>
                    (string.IsNullOrEmpty(brandParameters.BrandName) || b.BrandName.Contains(brandParameters.BrandName)),
                    trackChanges)
                .SearchByName(brandParameters.BrandName) // Tìm kiếm theo tên sản phẩm
                .SearchByDate(brandParameters.CreatedAt) //Tìm kiếm theo CreatedAt
                .SearchByDate(brandParameters.UpdateAt) //Tìm kiếm theo UpdateAt
                .SearchByStatus(brandParameters.Status)
                .Sort(brandParameters.OrderBy) 
                .IsInclude(include) 
                .ToListAsync(); 

            // Trả về kết quả dưới dạng PagedList
            return PagedList<Brand>.ToPagedList(
                brandsQuery,
                brandParameters.PageNumber,
                brandParameters.PageSize
            );
        }


        public void UpdateBrandAsync(Brand brand)
        {
            base.Update(brand);
        }
    }
}
