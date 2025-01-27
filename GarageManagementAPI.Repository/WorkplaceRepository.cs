using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace GarageManagementAPI.Repository
{
    public class WorkplaceRepository : RepositoryBase<Workplace>, IWorkplaceRepository
    {
        public WorkplaceRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CreateWorkplaceAsync(Workplace workplace)
        {
            await base.CreateAsync(workplace);
        }


        public void UpdateWorkplace(Workplace workplace)
        {

            base.Update(workplace);
        }

        public void DeleteWorkplace(Workplace workplace)
        {
            base.Delete(workplace);
        }

        public async Task<Workplace?> GetWorkplace(Guid id, bool trackChanges)
        {
            var Worplace = await FindByCondition(wp => wp.Id.Equals(id), trackChanges).SingleOrDefaultAsync();

            return Worplace;
        }

        public async Task<PagedList<Workplace>> GetWorkplaces(WorkplaceParameters workplaceParameters, bool trackChanges)
        {
            var worplaces = await FindAll(trackChanges)
            .SearchByStatus(workplaceParameters.WorkplaceStatus)
            .SearchByType(workplaceParameters.WorkplaceType)
            .SearchByName(workplaceParameters.Name)
            .Sort(workplaceParameters.OrderBy)
            .Skip((workplaceParameters.PageNumber - 1) * workplaceParameters.PageSize)
            .Take(workplaceParameters.PageSize)
            .ToListAsync();

            var count = await FindAll(trackChanges)
                 .SearchByStatus(workplaceParameters.WorkplaceStatus)
                .SearchByType(workplaceParameters.WorkplaceType)
                .SearchByName(workplaceParameters.Name)
                .CountAsync();


            return new PagedList<Workplace>(
                worplaces,
                count,
                workplaceParameters.PageNumber,
                workplaceParameters.PageSize);
        }
    }
}
