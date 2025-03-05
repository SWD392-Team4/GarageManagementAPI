using GarageManagementAPI.Shared.DataTransferObjects.PackageCondition;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IPackageConditionService
    {
        Task<Result<IEnumerable<PackageConditionDto>>> GetPackageConditionsAsync(PackageConditionParameters packageConditionParameters, bool trackChanges);
        Task<Result<PackageConditionDto>> GetPackageConditionByIdAsync(Guid id, bool trackChanges);
        Task<Result<PackageConditionDto>> CreatePackageConditionAsync(Guid packageId, PackageConditionDtoForCreation packageConditionDtoForCreation);
        Task<Result> UpdatePackageConditionAsync(Guid id, PackageConditionDtoForUpdate packageConditionDtoForUpdate);
        Task<Result> RemovePackageConditionAsync(Guid id);
    }
}