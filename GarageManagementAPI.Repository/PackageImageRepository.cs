using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Repository.Extensions;
using GarageManagementAPI.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace GarageManagementAPI.Repository
{
    public class PackageImageRepository : RepositoryBase<PackageImage>, IPackageImageRepository
    {
        public PackageImageRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public async Task<PackageImage?> GetPackageImageByIdAsync(Guid packageId, Guid id, bool trackChanges)
        {
            var packageImage = await FindByCondition(p => p.Id.Equals(id) && p.PackageId.Equals(packageId), trackChanges).SingleOrDefaultAsync();
            return packageImage;
        }

        public async Task<PagedList<PackageImage>> GetPackageImagesByPackageIdAsync(Guid id, bool trackChanges, PackageImageParameters packageImageParameters)
        {
            var packageImages = await FindByCondition(p => p.PackageId.Equals(id), trackChanges)
                    .Sort(packageImageParameters.OrderBy)
                    .Skip((packageImageParameters.PageNumber - 1) * packageImageParameters.PageSize)
                    .Take(packageImageParameters.PageSize)
                    .ToListAsync();

            var count = await FindByCondition(p => p.PackageId.Equals(id), trackChanges)
                .CountAsync();

            return new PagedList<PackageImage>(
                packageImages,
                count,
                packageImageParameters.PageNumber,
                packageImageParameters.PageSize);

        }

        public async Task<IEnumerable<PackageImage>> GetPackageImagesByPackageIdAsync(Guid id, bool trackChanges)
        {
            return await FindByCondition(p => p.PackageId.Equals(id), trackChanges).ToListAsync();
        }
    }
}
