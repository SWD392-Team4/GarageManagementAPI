using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface ICarModelRepository : IRepositoryBase<CarModel>
    {
        public Task<PagedList<CarModel>> GetCarModelsAsync(CarModelParameters carModelParameters, bool trackChanges, string? include = null);

        public Task<CarModel?> GetCarModelAsync(Guid id, bool trackChanges, string? include = null);

        public Task<CarModel?> GetCarModelAsync(string modelName, Guid brandId, Guid categoryId, DateOnly modelYear, bool trackChanges);

        public Task CreateCarModelsAsync(CarModel carModel);
    }
}
