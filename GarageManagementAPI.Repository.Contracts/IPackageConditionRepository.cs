using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Repository.Contracts
{
    public interface IPackageConditionRepository : IRepositoryBase<PackageCondition>
    {
        Task<PackageCondition?> GetPackageConditionAsync(Guid pacakgeId, Guid packageCondtionId, bool trackChanges);
        Task<PackageCondition?> GetPackageConditionAsync(Guid packageId, bool trackChanges, PackageConditionType conditionType, int conditionValue);
        Task<PagedList<PackageCondition>> GetPackageConditionsAsync(Guid packageId, PackageConditionParameters packageConditionParameters, bool trackChanges);
        Task<IEnumerable<PackageCondition>> GetPackageConditionsAsync(Guid packageId, bool trackChanges);
        Task CreateAsync(Guid packageId, PackageCondition packageCondition);
    }
}
