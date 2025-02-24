using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace GarageManagementAPI.Repository
{
    public class CarCategoryRepository : RepositoryBase<CarCategory>, ICarCategoryRepository
    {
        public CarCategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CreateCarCategoryAsync(CarCategory carCategory)
        {
            await base.CreateAsync(carCategory);
        }

        public async Task<PagedList<CarCategory>> GetCarCategoriesAsync(CarCategoryParameters carCategoryParameters, bool trackChanges)
        {
            var carCategories = await FindAll(trackChanges)
            .Sort(carCategoryParameters.OrderBy)
            .Skip((carCategoryParameters.PageNumber - 1) * carCategoryParameters.PageSize)
            .Take(carCategoryParameters.PageSize)
            .ToListAsync();

            var count = await FindAll(trackChanges)
                .CountAsync();


            return new PagedList<CarCategory>(
                carCategories,
                count,
                carCategoryParameters.PageNumber,
                carCategoryParameters.PageSize);
        }

        public async Task<CarCategory?> GetCarCategoryAsync(Guid id, bool trackChanges)
        {
            return await FindByCondition(e => e.Id.Equals(id), trackChanges).SingleOrDefaultAsync();
        }
    }
}
