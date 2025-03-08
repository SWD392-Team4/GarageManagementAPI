using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Shared.RequestFeatures;

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

        public Task<PagedList<PackageDetail>> GetPackageDetailsAsync(PackageDetailParameters packageDetailParameters, bool trackChanges)
        {
            throw new NotImplementedException();
        }
    }
}
