using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IWorkplaceRepository : IRepositoryBase<Workplace>
    {
        public Task<Workplace?> GetWorkplace(Guid id, bool trackChanges);

        public Task<PagedList<Workplace>> GetWorkplaces(WorkplaceParameters workplaceParameters, bool trackChanges);

        public Task CreateWorkplaceAsync(Workplace workplace);

        public void UpdateWorkplace(Workplace workplace);

        public void DeleteWorkplace(Workplace workplace);
    }
}
