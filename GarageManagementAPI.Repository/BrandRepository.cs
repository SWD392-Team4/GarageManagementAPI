using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

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
            var brandsQuery = FindByCondition(b =>
                    (string.IsNullOrEmpty(brandParameters.BrandName) || b.BrandName.Contains(brandParameters.BrandName)),
                    trackChanges)
                .SearchByName(brandParameters.BrandName) // Tìm kiếm theo tên sản phẩm
                .SearchByStatus(brandParameters.Status)
                .Sort(brandParameters.OrderBy) 
                .IsInclude(include) 
                .AsQueryable(); 

            // Lấy danh sách sản phẩm sau khi phân trang
            var brands = await brandsQuery
                .Skip((brandParameters.PageNumber - 1) * brandParameters.PageSize) 
                .Take(brandParameters.PageSize) 
                .ToListAsync(); 

            // Lấy tổng số bản ghi để tính toán tổng số trang
            var count = await brandsQuery.CountAsync(); 

            // Trả về kết quả dưới dạng PagedList
            return new PagedList<Brand>(
                brands,
                count,
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
