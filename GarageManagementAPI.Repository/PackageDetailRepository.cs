using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace GarageManagementAPI.Repository
{
    public class PackageDetailRepository : RepositoryBase<PackageDetail>, IPackageDetailRepository
    {
        public PackageDetailRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public Task<PackageDetail?> GetPackageDetailByIdAsync(Guid id, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PackageDetail>> GetPackageDetails(Guid packageHistoryId, Guid[] serviceIds, bool trackChanges)
        {
            return await FindByCondition(p => p.PackageHistoryId.Equals(packageHistoryId) && serviceIds.Contains(p.ServiceId), trackChanges).ToListAsync();
        }

        public Task<PagedList<PackageDetail>> GetPackageDetailsAsync(PackageDetailParameters packageDetailParameters, bool trackChanges)
        {
            throw new NotImplementedException();
        }
    }
}
