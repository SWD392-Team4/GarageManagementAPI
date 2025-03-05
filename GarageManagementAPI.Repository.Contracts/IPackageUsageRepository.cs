using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IPackageUsageRepository : IRepositoryBase<PackageUsage>
    {
        Task<PackageUsage?> GetPackageUsageByIdAsync(Guid id, bool trackChanges);
        Task<PagedList<PackageUsage>> GetPackageUsagesAsync(PackageUsageParameters packageUsageParameters, bool trackChanges);
    }
}
