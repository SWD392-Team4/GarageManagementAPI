using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace GarageManagementAPI.Repository
{
    public class CarModelRepository : RepositoryBase<CarModel>, ICarModelRepository
    {
        public CarModelRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CreateCarModelsAsync(CarModel carModel)
        {
            await base.CreateAsync(carModel);
        }

        public async Task<PagedList<CarModel>> GetCarModelsAsync(CarModelParameters carModelParameters, bool trackChanges)
        {
            var carModels = await FindAll(trackChanges)
            .SearchByBrandId(carModelParameters.BrandId)
            .SearchByCarCategoryId(carModelParameters.CarCategoryId)
            .SearchByModelName(carModelParameters.ModelName)
            .SearchByModelYear(carModelParameters.ModelYear)
            .Sort(carModelParameters.OrderBy)
            .Skip((carModelParameters.PageNumber - 1) * carModelParameters.PageSize)
            .Take(carModelParameters.PageSize)
            .Include(e => e.Brand)
            .Include(e => e.CarCategory)
            .ToListAsync();

            var count = await FindAll(trackChanges)
                .SearchByBrandId(carModelParameters.BrandId)
                .SearchByCarCategoryId(carModelParameters.CarCategoryId)
                .SearchByModelName(carModelParameters.ModelName)
                .SearchByModelYear(carModelParameters.ModelYear)
                .CountAsync();


            return new PagedList<CarModel>(
                carModels,
                count,
                carModelParameters.PageNumber,
                carModelParameters.PageSize);
        }

        public async Task<CarModel?> GetCarModelAsync(Guid id, bool trackChanges)
        {
            return await FindByCondition(e => e.Id.Equals(id), trackChanges).SingleOrDefaultAsync();
        }
    }
}
