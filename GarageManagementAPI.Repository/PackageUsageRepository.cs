using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace GarageManagementAPI.Repository
{
    public class PackageUsageRepository : RepositoryBase<PackageUsage>, IPackageUsageRepository
    {
        public PackageUsageRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public async Task<PackageUsage?> GetPackageUsageByIdAsync(Guid id, bool trackChanges)
        {
            var packageUsage = await FindByCondition(p => p.Id.Equals(id), trackChanges).SingleOrDefaultAsync();
            return packageUsage;
        }
        public async Task<PagedList<PackageUsage>> GetPackageUsagesAsync(PackageUsageParameters packageUsageParameters, bool trackChanges)
        {
            var packageUsages = await FindAll(trackChanges)
                .Sort(packageUsageParameters.OrderBy)
                .Skip((packageUsageParameters.PageNumber - 1) * packageUsageParameters.PageSize)
                .Take(packageUsageParameters.PageSize)
                .ToListAsync();
            var count = await FindAll(trackChanges)
                .CountAsync();
            return new PagedList<PackageUsage>(
                packageUsages,
                count,
                packageUsageParameters.PageNumber,
                packageUsageParameters.PageSize);
        }
    }
}
