using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;

namespace GarageManagementAPI.Repository
{
    public class GarageRepository : RepositoryBase<Garage>, IGarageRepository
    {
        public GarageRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Garage> GetAllGarages(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(g => g.Name)
            .ToList();
    }
}
