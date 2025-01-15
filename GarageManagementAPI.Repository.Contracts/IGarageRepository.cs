using GarageManagementAPI.Entities.Models;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IGarageRepository : IRepositoryBase<Garage>
    {
        IEnumerable<Garage> GetAllGarages(bool trackChanges);

    }
}
