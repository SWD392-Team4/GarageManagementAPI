using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace GarageManagementAPI.Repository
{
    public class PackageHistoryRepository : RepositoryBase<PackageHistory>, IPackageHistoryRepository
    {
        public PackageHistoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public async Task<PackageHistory?> GetPackageHistoryByIdAsync(Guid id, bool trackChanges)
        {
            var packageHistory = await FindByCondition(p => p.Id.Equals(id), trackChanges).Include(p => p.Services).SingleOrDefaultAsync();
            return packageHistory;
        }

        public async Task<bool> CheckIfPackageHistoryExist(Guid packageId, decimal packagePrice, int validityPeriod, TimeUnit timeUnit, int usageLimit)
            => await FindByCondition(p =>
                p.PackageId.Equals(packageId) &&
                p.PackagePrice.Equals(packagePrice) &&
                p.ValidityPeriod.Equals(validityPeriod) &&
                p.TimeUnit.Equals(timeUnit) &&
                p.UsageLimit.Equals(usageLimit), false)
                .AnyAsync();

        public async Task<PagedList<PackageHistory>> GetPackageHistoriesAsync(PackageHistoryParameters packageHistoryParameters, bool trackChanges)
        {
            var packageHistories = await FindAll(trackChanges)
                .Sort(packageHistoryParameters.OrderBy)
                .Skip((packageHistoryParameters.PageNumber - 1) * packageHistoryParameters.PageSize)
                .Take(packageHistoryParameters.PageSize).Include(p => p.Services)
                .Include(p => p.Services)
                .ToListAsync();
            var count = await FindAll(trackChanges)
                .CountAsync();
            return new PagedList<PackageHistory>(
                packageHistories,
                count,
                packageHistoryParameters.PageNumber,
                packageHistoryParameters.PageSize);
        }
    }
}
