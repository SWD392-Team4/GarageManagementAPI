using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IPackageHistoryRepository : IRepositoryBase<PackageHistory>
    {
        Task<PackageHistory?> GetPackageHistoryAsync(Guid packageId, Guid packageHistoryId, bool trackChanges);
        Task<PackageHistory?> GetPackageHistoryAsync(Guid packageId, decimal packagePrice, int validityPeriod, TimeUnit timeUnit, int usageLimit, bool trackChanges);
        Task<PagedList<PackageHistory>> GetPackageHistoriesAsync(Guid packageId, PackageHistoryParameters packageHistoryParameters, bool trackChanges);
        Task CreateAsync(Guid packageId, PackageHistory packageHistory);

    }
}
