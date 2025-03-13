using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IPackageHistoryRepository : IRepositoryBase<PackageHistory>
    {
        Task<PackageHistory?> GetPackageHistoryAsync(Guid packageId, Guid packageHistoryId, bool trackChanges);
        Task<PackageHistory?> GetPackageHistoryAsync(Guid packageId, bool trackChanges);
        Task<IEnumerable<PackageHistory>> GetPackageHistoriesAsync(IEnumerable<Guid> packageId, bool trackChanges);
        Task<PagedList<PackageHistory>> GetPackageHistoriesAsync(Guid packageId, PackageHistoryParameters packageHistoryParameters, bool trackChanges);
        Task CreateAsync(Package package, PackageHistory packageHistory);

    }
}
