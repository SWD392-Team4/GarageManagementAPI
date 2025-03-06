using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface ICarModelRepository : IRepositoryBase<CarModel>
    {
        public Task<PagedList<CarModel>> GetCarModelsAsync(CarModelParameters carModelParameters, bool trackChanges, string? include);

        public Task<CarModel?> GetCarModelAsync(Guid id, bool trackChanges, string? include);

        public Task CreateCarModelsAsync(CarModel carModel);
    }
}
