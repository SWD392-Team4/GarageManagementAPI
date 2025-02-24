using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface ICarModelRepository : IRepositoryBase<CarModel>
    {
        public Task<PagedList<CarModel>> GetCarModelsAsync(CarModelParameters carModelParameters, bool trackChanges);

        public Task<CarModel?> GetCarModelAsync(Guid id, bool trackChanges);

        public Task CreateCarModelsAsync(CarModel carModel);
    }
}
