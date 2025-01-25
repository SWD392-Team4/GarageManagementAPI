using GarageManagementAPI.Entities.NewModels;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IGarageRepository : IRepositoryBase<Garage>
    {
        Task<PagedList<Garage>> GetAllGaragesAsync(
            GarageParameters garageParameters,
            bool trackChanges);
    }
}
