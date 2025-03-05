using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IPackageUsageDetailRepository : IRepositoryBase<PackageUsageDetail>
    {
        Task<PackageUsageDetail?> GetPackageUsageDetailByIdAsync(Guid id, bool trackChanges);
        Task<PagedList<PackageUsageDetail>> GetPackageUsageDetailsAsync(PackageUsageDetailParameters packageUsageDetailParameters, bool trackChanges);
    }
}
