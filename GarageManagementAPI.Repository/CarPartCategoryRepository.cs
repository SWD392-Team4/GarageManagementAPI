using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository
{

    public class CarPartCategoryRepository : RepositoryBase<CarPartCategory>, ICarPartCategoryRepository
    {

        public CarPartCategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public async Task CreateCarPartCategoryAsync(CarPartCategory carPartCategory)
        {
            await base.CreateAsync(carPartCategory);
        }

        public async Task<CarPartCategory?> GetCarPartCategoryByIdAndNameAsync(string name, Guid? carPartCategoryId, bool trackChanges)
        {
            //SingleOrDefaultAsync method throws an exception if more than one element satisfies the condition.
            var carPartCategory = carPartCategoryId is null ?
                                  await FindByCondition(c => c.PartCategory.ToLower().Equals(name), trackChanges).SingleOrDefaultAsync() :
                                  await FindByCondition(c => c.PartCategory.ToLower().Equals(name) && c.Id.Equals(carPartCategoryId), trackChanges).SingleOrDefaultAsync();
            return carPartCategory;
        }

        public async Task<CarPartCategory?> GetCarPartCategoryByIdAsync(Guid carPartCategoryId, bool trackChanges, string? include = null)
        {
           var cartPartCategory = include is null ? 
                                  await FindByCondition(c => c.Id.Equals(carPartCategoryId), trackChanges).SingleOrDefaultAsync() :
                                  await FindByCondition(c => c.Id.Equals(carPartCategoryId), trackChanges).IsInclude(include).SingleOrDefaultAsync();

            return cartPartCategory;
        }

        public async Task<PagedList<CarPartCategory>> GetCarPartCategoriesAsync(CarPartCategoryParameters carPartCategoryParameters, bool trackChanges, string? include = null)
        {
            var carPartQuery = await FindAll(trackChanges)
                                       .SearchByName(carPartCategoryParameters.PartCategory)
                                       .SearchByDate(carPartCategoryParameters.CreatedAt)
                                       .SearchByDate(carPartCategoryParameters.UpdatedAt)
                                       .SearchByStatus(carPartCategoryParameters.Status)
                                       .IsInclude(include)
                                       .ToListAsync();

            return PagedList<CarPartCategory>.ToPagedList(
                carPartQuery,
                carPartCategoryParameters.PageNumber,
                carPartCategoryParameters.PageSize
                );
        }

        public void UpdateCarPartCategoryAsync(CarPartCategory carPartCategory)
        {
             base.Update(carPartCategory);
        }
    }
}
