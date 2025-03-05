using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace GarageManagementAPI.Repository
{
    public class PackageUsageDetailRepository : RepositoryBase<PackageUsageDetail>, IPackageUsageDetailRepository
    {
        public PackageUsageDetailRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public async Task<PackageUsageDetail?> GetPackageUsageDetailByIdAsync(Guid id, bool trackChanges)
        {
            var packageUsageDetail = await FindByCondition(p => p.Id.Equals(id), trackChanges).SingleOrDefaultAsync();
            return packageUsageDetail;
        }
        public async Task<PagedList<PackageUsageDetail>> GetPackageUsageDetailsAsync(PackageUsageDetailParameters packageUsageDetailParameters, bool trackChanges)
        {
            var packageUsageDetails = await FindAll(trackChanges)
                .Sort(packageUsageDetailParameters.OrderBy)
                .Skip((packageUsageDetailParameters.PageNumber - 1) * packageUsageDetailParameters.PageSize)
                .Take(packageUsageDetailParameters.PageSize)
                .ToListAsync();
            var count = await FindAll(trackChanges)
                .CountAsync();
            return new PagedList<PackageUsageDetail>(
                packageUsageDetails,
                count,
                packageUsageDetailParameters.PageNumber,
                packageUsageDetailParameters.PageSize);
        }
    }
}
