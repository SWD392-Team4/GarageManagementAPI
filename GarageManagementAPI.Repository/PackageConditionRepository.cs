using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace GarageManagementAPI.Repository
{
    public class PackageConditionRepository : RepositoryBase<PackageCondition>, IPackageConditionRepository
    {
        public PackageConditionRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CreateAsync(Guid packageId, PackageCondition packageCondition)
        {
            packageCondition.PackageId = packageId;
            await base.CreateAsync(packageCondition);
        }
        public async Task<PackageCondition?> GetPackageConditionAsync(Guid packageId, Guid packageConditionId, bool trackChanges)
        {
            var packageCondition = await FindByCondition(p => p.Id.Equals(packageConditionId) && p.PackageId.Equals(packageId), trackChanges).SingleOrDefaultAsync();
            return packageCondition;
        }

        public async Task<PackageCondition?> GetPackageConditionAsync(Guid packageId, bool trackChanges, PackageConditionType conditionType, int conditionValue)
        {
            return await FindByCondition(
                p => p.PackageId.Equals(packageId) && 
                p.ConditionType.Equals(conditionType) && 
                p.ConditionValue.Equals(conditionValue), trackChanges)
                .SingleOrDefaultAsync();
        }

        public async Task<PagedList<PackageCondition>> GetPackageConditionsAsync(Guid packageId, PackageConditionParameters packageConditionParameters, bool trackChanges)
        {
            var packageConditions = await FindByCondition(p => p.PackageId.Equals(packageId), trackChanges)
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

        public async Task<IEnumerable<PackageCondition>> GetPackageConditionsAsync(Guid packageId, bool trackChanges)
        {
            return await FindByCondition(p => p.PackageId.Equals(packageId), trackChanges).ToListAsync();
        }
    }
}
