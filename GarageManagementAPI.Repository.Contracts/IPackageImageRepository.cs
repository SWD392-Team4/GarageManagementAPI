using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IPackageImageRepository : IRepositoryBase<PackageImage>
    {
        Task<PackageImage?> GetPackageImageByIdAsync(Guid packageId, Guid id, bool trackChanges);

        Task<PagedList<PackageImage>> GetPackageImagesByPackageIdAsync(Guid id, bool trackChanges, PackageImageParameters packageImageParameters);

        Task<IEnumerable<PackageImage>> GetPackageImagesByPackageIdAsync(Guid id, bool trackChanges);
    }
}
