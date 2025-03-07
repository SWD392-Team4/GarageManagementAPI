using GarageManagementAPI.Shared.DataTransferObjects.PackageCondition;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;
using System.Dynamic;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IPackageConditionService
    {
        Task<Result<ExpandoObject>> GetPackageConditionAsync(Guid packageId, Guid packageConditionId, bool trackChanges, string? fields = null);
        Task<Result<IEnumerable<ExpandoObject>>> GetPackageConditionsAsync(Guid packageId, PackageConditionParameters packageConditionParameters, bool trackChanges);
        Task<Result<PackageConditionDto>> CreatePackageConditionAsync(Guid packageId, PackageConditionDtoForCreation packageConditionDtoForCreation);
        Task<Result> UpdatePackageConditionAsync(Guid id, PackageConditionDtoForUpdate packageConditionDtoForUpdate);
        Task<Result> RemovePackageConditionAsync(Guid id);
    }
}