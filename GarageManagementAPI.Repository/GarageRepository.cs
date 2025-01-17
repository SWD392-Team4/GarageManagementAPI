using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace GarageManagementAPI.Repository
{
    public class GarageRepository : RepositoryBase<Garage>, IGarageRepository
    {
        public GarageRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Garage>> GetAllGaragesAsync(bool trackChanges) =>
           await FindAll(trackChanges)
            .OrderBy(g => g.Name)
            .ToListAsync();
    }
}
