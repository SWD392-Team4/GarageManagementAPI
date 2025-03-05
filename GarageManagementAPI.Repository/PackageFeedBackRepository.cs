using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace GarageManagementAPI.Repository
{
    public class PackageFeedBackRepository : RepositoryBase<PackageFeedBack>, IPackageFeedBackRepository
    {
        public PackageFeedBackRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public async Task<PackageFeedBack?> GetPackageFeedBackByIdAsync(Guid id, bool trackChanges)
        {
            var packageFeedBack = await FindByCondition(p => p.Id.Equals(id), trackChanges).SingleOrDefaultAsync();
            return packageFeedBack;
        }
        public async Task<PagedList<PackageFeedBack>> GetPackageFeedBacksAsync(PackageFeedBackParameters packageFeedBackParameters, bool trackChanges)
        {
            var packageFeedBacks = await FindAll(trackChanges)
                .Sort(packageFeedBackParameters.OrderBy)
                .Skip((packageFeedBackParameters.PageNumber - 1) * packageFeedBackParameters.PageSize)
                .Take(packageFeedBackParameters.PageSize)
                .ToListAsync();
            var count = await FindAll(trackChanges)
                .CountAsync();
            return new PagedList<PackageFeedBack>(
                packageFeedBacks,
                count,
                packageFeedBackParameters.PageNumber,
                packageFeedBackParameters.PageSize);
        }
    }
}
