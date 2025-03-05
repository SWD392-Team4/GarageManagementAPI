using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IPackageImageRepository : IRepositoryBase<PackageImage>
    {
        Task<PackageImage?> GetPackageImageByIdAsync(Guid id, bool trackChanges);
        Task<IEnumerable<PackageImage>> GetPackageImagesByPackageIdAsync(Guid id, bool trackChanges);
    }
}
