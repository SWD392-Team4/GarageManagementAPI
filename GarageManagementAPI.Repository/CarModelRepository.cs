using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.Extension;
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
            carModel.UpdatedAt = DateTimeOffset.Now.SEAsiaStandardTime();
            carModel.CreatedAt = DateTimeOffset.Now.SEAsiaStandardTime();
            carModel.Status = CarModelStatus.Active;
            await base.CreateAsync(carModel);
        }

        public async Task<PagedList<CarModel>> GetCarModelsAsync(CarModelParameters carModelParameters, bool trackChanges, string? include = null)
        {
            var carModels = await FindAll(trackChanges)
            .SearchByBrandId(carModelParameters.BrandId)
            .SearchByCarCategoryId(carModelParameters.CarCategoryId)
            .SearchByModelName(carModelParameters.ModelName)
            .SearchByModelYear(carModelParameters.ModelYear)
            .FilterByStatus(carModelParameters.Status)
            .FilterByCreatedAt(carModelParameters.CreatedAt)
            .FilterByUpdatedAt(carModelParameters.UpdatedAt)
            .Sort(carModelParameters.OrderBy)
            .Skip((carModelParameters.PageNumber - 1) * carModelParameters.PageSize)
            .Take(carModelParameters.PageSize)
            .IsInclude(include)
            .ToListAsync();

            var count = await FindAll(trackChanges)
                .SearchByBrandId(carModelParameters.BrandId)
                .SearchByCarCategoryId(carModelParameters.CarCategoryId)
                .SearchByModelName(carModelParameters.ModelName)
                .SearchByModelYear(carModelParameters.ModelYear)
                .FilterByStatus(carModelParameters.Status)
                .FilterByCreatedAt(carModelParameters.CreatedAt)
                .FilterByUpdatedAt(carModelParameters.UpdatedAt)
                .Skip((carModelParameters.PageNumber - 1) * carModelParameters.PageSize)
                .Take(carModelParameters.PageSize)
                .CountAsync();


            return new PagedList<CarModel>(
                carModels,
                count,
                carModelParameters.PageNumber,
                carModelParameters.PageSize);
        }

        public async Task<CarModel?> GetCarModelAsync(Guid id, bool trackChanges, string? include = null)
        {
            return await FindByCondition(e => e.Id.Equals(id), trackChanges)
                .IsInclude(include)
                .SingleOrDefaultAsync();
        }

        public async Task<CarModel?> GetCarModelAsync(string modelName, Guid brandId, Guid categoryId, DateOnly modelYear, bool trackChanges)
        {
            return await FindByCondition(
                e => e.ModelName.Equals(modelName) &&
                e.BrandId.Equals(brandId) &&
                e.CarCategoryId.Equals(categoryId) &&
                e.ModelYear.Equals(modelYear), trackChanges).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CarModel>> GetCarPartsAsync(List<Guid> carModeldIds, bool trackChanges, string? include = null)
        {
            return await FindByCondition(cp => carModeldIds.Contains(cp.Id), trackChanges).ToListAsync();
        }
    }
}
