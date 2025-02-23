using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Repository.Extensions;

namespace GarageManagementAPI.Repository
{
    public class CarPartRepository: RepositoryBase<CarPart>, ICarPartRepository
    {
        public CarPartRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CreateCarPartAsync(CarPart carPart)
        {
            await base.CreateAsync(carPart);
        }

        public async Task<CarPart?> GetCarPartByIdAndNameAsync(string name, Guid? carPartId, bool trackChanges)
        {
            var carPart = carPartId is null ?
            await FindByCondition(c => c.PartName.Equals(name), trackChanges).SingleOrDefaultAsync() :
            await FindByCondition(c => c.Id.Equals(carPartId) && c.PartName.ToLower().Equals(name.ToLower()), trackChanges).SingleOrDefaultAsync();

            return carPart;
        }

        public async Task<CarPart?> GetCarPartByIdAsync(Guid CarPartId, bool trackChanges, string? include = null)
        {
            var CarPart = include is null ?
             await FindByCondition(u => u.Id.Equals(CarPartId), trackChanges).SingleOrDefaultAsync() :
             await FindByCondition(u => u.Id.Equals(CarPartId), trackChanges).Include(include).SingleOrDefaultAsync();

            return CarPart;
        }

        public async Task<PagedList<CarPart>> GetCarPartsAsync(CarPartParameters carPartParameters, bool trackChanges, string? include = null)
        {
            // Lọc và sắp xếp danh sách CarParts theo các điều kiện
            var CarPartsQuery = await FindByCondition(c =>
                    (string.IsNullOrEmpty(carPartParameters.CarPartName) || c.PartName.Contains(carPartParameters.CarPartName)),
                    trackChanges)
                .SearchByName(carPartParameters.CarPartName) // Tìm kiếm theo tên sản phẩm
                .SearchByDate(carPartParameters.CreatedAt) //Tìm kiếm theo CreatedAt
                .SearchByDate(carPartParameters.UpdatedAt) //Tìm kiếm theo UpdateAt
                .SearchByStatus(carPartParameters.Status)
                .Sort(carPartParameters.OrderBy)
                .IsInclude(include)
                .ToListAsync();

            // Trả về kết quả dưới dạng PagedList
            return PagedList<CarPart>.ToPagedList(
                CarPartsQuery,
                carPartParameters.PageNumber,
                carPartParameters.PageSize
            );
        }


        public void UpdateCarPartAsync(CarPart carPart)
        {
            base.Update(carPart);
        }
    }
}
