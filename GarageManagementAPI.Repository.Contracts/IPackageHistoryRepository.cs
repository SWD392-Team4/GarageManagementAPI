using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IPackageHistoryRepository : IRepositoryBase<PackageHistory>
    {
        Task<PackageHistory?> GetPackageHistoryByIdAsync(Guid id, bool trackChanges);
        Task<bool> CheckIfPackageHistoryExist(Guid packageId, decimal packagePrice, int validityPeriod, TimeUnit timeUnit, int usageLimit);
        Task<PagedList<PackageHistory>> GetPackageHistoriesAsync(PackageHistoryParameters packageHistoryParameters, bool trackChanges);
    }
}
