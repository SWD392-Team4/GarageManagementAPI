using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IPackageRepository : IRepositoryBase<Package>
    {
        Task<Package?> GetPackageByIdAsync(Guid id, bool trackChanges);
        Task<Package?> GetPackageByNameAsync(string packageName, bool trackChanges);
        Task<PagedList<Package>> GetPackagesAsync(PackageParameters packageParameters, bool trackChanges);
        Task<PagedList<Package>> GetPackagesByServiceIdAsync(Guid serviceId, PackageParameters packageParameters, bool trackChanges);
    }
}
