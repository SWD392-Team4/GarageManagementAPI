using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IPackageDetailRepository : IRepositoryBase<PackageDetail>
    {
        Task<PackageDetail?> GetPackageDetailByIdAsync(Guid id, bool trackChanges);
        Task<PagedList<PackageDetail>> GetPackageDetailsAsync(PackageDetailParameters packageDetailParameters, bool trackChanges);

        Task<IEnumerable<PackageDetail>> GetPackageDetails(Guid packageHistoryId, Guid[] serviceIds, bool trackChanges);
    }
}
