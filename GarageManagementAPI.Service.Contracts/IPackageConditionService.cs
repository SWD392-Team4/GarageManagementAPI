using GarageManagementAPI.Shared.DataTransferObjects.PackageCondition;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;
using System.Dynamic;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IPackageConditionService
    {
        Task<Result<ExpandoObject>> GetPackageConditionAsync(Guid packageId, Guid packageConditionId, string? fields = null);
        Task<Result<IEnumerable<ExpandoObject>>> GetPackageConditionsAsync(Guid packageId, PackageConditionParameters packageConditionParameters);
        Task<Result<PackageConditionDto>> CreatePackageConditionAsync(Guid packageId, PackageConditionDtoForCreation packageConditionDtoForCreation);
        Task<Result> UpdatePackageConditionAsync(Guid packageId, Guid packageConditionId, PackageConditionDtoForUpdate packageConditionDtoForUpdate);
        Task<Result> RemovePackageConditionAsync(Guid packageId, Guid packageConditionId);
        Task<Result> RemovePackageConditionAsync(Guid packageId);
    }
}