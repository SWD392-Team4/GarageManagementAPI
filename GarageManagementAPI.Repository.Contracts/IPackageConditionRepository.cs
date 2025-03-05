using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IPackageConditionRepository : IRepositoryBase<PackageCondition>
    {
        Task<PackageCondition?> GetPackageConditionByIdAsync(Guid id, bool trackChanges);
        Task<PagedList<PackageCondition>> GetPackageConditionsAsync(PackageConditionParameters packageConditionParameters, bool trackChanges);
        Task<IEnumerable<PackageCondition>> GetPackageConditionsByPackageIdAsync(Guid packageId, bool trackChanges);
    }
}
