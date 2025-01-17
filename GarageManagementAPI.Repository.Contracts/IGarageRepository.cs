using GarageManagementAPI.Entities.Models;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IGarageRepository : IRepositoryBase<Garage>
    {
        Task<IEnumerable<Garage>> GetAllGaragesAsync(bool trackChanges);
    }
}
