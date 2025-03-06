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

        public async Task<PagedList<CarModel>> GetCarModelsAsync(CarModelParameters carModelParameters, bool trackChanges, string? include)
        {
            var carModels = await FindAll(trackChanges)
            .SearchByBrandId(carModelParameters.BrandId)
            .SearchByCarCategoryId(carModelParameters.CarCategoryId)
            .SearchByModelName(carModelParameters.ModelName)
            .SearchByModelYear(carModelParameters.ModelYear)
            .Sort(carModelParameters.OrderBy)
             .IsInclude(include)
            .ToListAsync();

            return PagedList<CarModel>.ToPagedList(
                carModels,
                carModelParameters.PageNumber,
                carModelParameters.PageSize);
        }

        public async Task<CarModel?> GetCarModelAsync(Guid id, bool trackChanges, string? include)
        {
            return include == null ? await FindByCondition(e => e.Id.Equals(id), trackChanges).SingleOrDefaultAsync() : await FindByCondition(e => e.Id.Equals(id), trackChanges).IsInclude(include).SingleOrDefaultAsync();
        }
    }
}
