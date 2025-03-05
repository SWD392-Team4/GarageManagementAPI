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
        public async Task<PackageImage?> GetPackageImageByIdAsync(Guid id, bool trackChanges)
        {
            var packageImage = await FindByCondition(p => p.Id.Equals(id), trackChanges).SingleOrDefaultAsync();
            return packageImage;
        }

        public async Task<IEnumerable<PackageImage>> GetPackageImagesByPackageIdAsync(Guid id, bool trackChanges)
        {
            return await FindByCondition(p => p.PackageId.Equals(id), trackChanges).ToListAsync();
        }
    }
}
