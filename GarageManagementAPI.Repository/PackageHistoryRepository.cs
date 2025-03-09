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

        public async Task<PackageHistory?> GetPackageHistoryAsync(Guid packageId, bool trackChanges)
        {
            var packageHistory = await FindByCondition(p => p.PackageId.Equals(packageId), trackChanges)
                .OrderByDescending(p => p.CreatedAt)
                .FirstOrDefaultAsync();
            return packageHistory;
        }

        public async Task<PagedList<PackageHistory>> GetPackageHistoriesAsync(Guid packageId, PackageHistoryParameters packageHistoryParameters, bool trackChanges)
        {
            var packageHistories = await FindByCondition(p => p.PackageId.Equals(packageId), trackChanges)
                .FilterByCarCategory(packageHistoryParameters.CarCategoryId)
                .FilterByServiceCategory(packageHistoryParameters.ServiceCategory)
                .FilterByPriceRange(packageHistoryParameters.MinPrice, packageHistoryParameters.MaxPrice)
                .FilterByPackageName(packageHistoryParameters.PackageName)
                .FilterByDescription(packageHistoryParameters.Description)
                .FilterByPackageType(packageHistoryParameters.Type)
                .FilterByValidityPeriod(packageHistoryParameters.ValidityPeriod)
                .FilterByTimeUnit(packageHistoryParameters.TimeUnit)
                .FilterByUsageLimit(packageHistoryParameters.UsageLimit)
                .FilterByCreatedAt(packageHistoryParameters.CreatedAt)
                .Sort(packageHistoryParameters.OrderBy)
                .Skip((packageHistoryParameters.PageNumber - 1) * packageHistoryParameters.PageSize)
                .Take(packageHistoryParameters.PageSize)
                .Include(p => p.CarCategory)
                .ToListAsync();

            var count = await FindByCondition(p => p.PackageId.Equals(packageId), trackChanges)
                .FilterByCarCategory(packageHistoryParameters.CarCategoryId)
                .FilterByServiceCategory(packageHistoryParameters.ServiceCategory)
                .FilterByPriceRange(packageHistoryParameters.MinPrice, packageHistoryParameters.MaxPrice)
                .FilterByPackageName(packageHistoryParameters.PackageName)
                .FilterByDescription(packageHistoryParameters.Description)
                .FilterByPackageType(packageHistoryParameters.Type)
                .FilterByValidityPeriod(packageHistoryParameters.ValidityPeriod)
                .FilterByTimeUnit(packageHistoryParameters.TimeUnit)
                .FilterByUsageLimit(packageHistoryParameters.UsageLimit)
                .FilterByCreatedAt(packageHistoryParameters.CreatedAt)
                .Include(p => p.CarCategory)
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
            packageHistory.CreatedAt = DateTimeOffset.UtcNow.SEAsiaStandardTime();
            await base.CreateAsync(packageHistory);
        }
    }
}
