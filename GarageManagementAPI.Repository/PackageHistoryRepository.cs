using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.Extension;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace GarageManagementAPI.Repository
{
    public class PackageHistoryRepository : RepositoryBase<PackageHistory>, IPackageHistoryRepository
    {
        public PackageHistoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public async Task<PackageHistory?> GetPackageHistoryAsync(Guid packageId, Guid packageHistoryId, bool trackChanges)
        {
            var packageHistory = await FindByCondition(p => p.Id.Equals(packageHistoryId) && p.PackageId.Equals(packageId), trackChanges)
                .SingleOrDefaultAsync();
            return packageHistory;
        }

        public async Task<PackageHistory?> GetPackageHistoryAsync(Guid packageId, decimal packagePrice, int validityPeriod, TimeUnit timeUnit, int usageLimit, bool trackChanges)
            => await FindByCondition(p =>
                p.PackageId.Equals(packageId) &&
                p.PackagePrice.Equals(packagePrice) &&
                p.ValidityPeriod.Equals(validityPeriod) &&
                p.TimeUnit.Equals(timeUnit) &&
                p.UsageLimit.Equals(usageLimit), trackChanges)
                .SingleOrDefaultAsync();

        public async Task<PagedList<PackageHistory>> GetPackageHistoriesAsync(Guid packageId, PackageHistoryParameters packageHistoryParameters, bool trackChanges)
        {
            var packageHistories = await FindByCondition(p => p.PackageId.Equals(packageId), trackChanges)
                .Sort(packageHistoryParameters.OrderBy)
                .Skip((packageHistoryParameters.PageNumber - 1) * packageHistoryParameters.PageSize)
                .Take(packageHistoryParameters.PageSize)
                .ToListAsync();

            var count = await FindByCondition(p => p.PackageId.Equals(packageId), trackChanges)
                .CountAsync();

            return new PagedList<PackageHistory>(
                packageHistories,
                count,
                packageHistoryParameters.PageNumber,
                packageHistoryParameters.PageSize);
        }

        public async Task CreateAsync(Guid packageId, PackageHistory packageHistory)
        {
            packageHistory.PackageId = packageId;
            packageHistory.Status = PackageHistoryStatus.Active;
            packageHistory.CreatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();

            await base.CreateAsync(packageHistory);
        }

        public new void Update(PackageHistory packageHistory)
        {
            packageHistory.Status = PackageHistoryStatus.Inactive;
            base.Update(packageHistory);
        }
    }
}
