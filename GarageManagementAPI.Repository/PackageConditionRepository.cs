using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace GarageManagementAPI.Repository
{
    public class PackageConditionRepository : RepositoryBase<PackageCondition>, IPackageConditionRepository
    {
        public PackageConditionRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public async Task<PackageCondition?> GetPackageConditionByIdAsync(Guid id, bool trackChanges)
        {
            var packageCondition = await FindByCondition(p => p.Id.Equals(id), trackChanges).SingleOrDefaultAsync();
            return packageCondition;
        }
        public async Task<PagedList<PackageCondition>> GetPackageConditionsAsync(PackageConditionParameters packageConditionParameters, bool trackChanges)
        {
            var packageConditions = await FindAll(trackChanges)
                .Sort(packageConditionParameters.OrderBy)
                .Skip((packageConditionParameters.PageNumber - 1) * packageConditionParameters.PageSize)
                .Take(packageConditionParameters.PageSize)
                .ToListAsync();
            var count = await FindAll(trackChanges)
                .CountAsync();
            return new PagedList<PackageCondition>(
                packageConditions,
                count,
                packageConditionParameters.PageNumber,
                packageConditionParameters.PageSize);
        }

        public async Task<IEnumerable<PackageCondition>> GetPackageConditionsByPackageIdAsync(Guid packageId, bool trackChanges)
        {
            return await FindByCondition(p => p.PackageId.Equals(packageId), trackChanges).ToListAsync();
        }
    }
}
