using GarageManagementAPI.Shared.DataTransferObjects.PackageUsage;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IPackageUsageService
    {
        Task<Result<IEnumerable<PackageUsageDto>>> GetPackageUsagesAsync(PackageUsageParameters packageUsageParameters, bool trackChanges);
        Task<Result<PackageUsageDto>> GetPackageUsageByIdAsync(Guid id, bool trackChanges);
        Task<Result<PackageUsageDto>> CreatePackageUsageAsync(PackageUsageDtoForCreation packageUsageDtoForCreation);
        Task<Result> UpdatePackageUsageAsync(Guid id, PackageUsageDtoForUpdate packageUsageDtoForUpdate);
        Task<Result> RemovePackageUsageAsync(Guid id);
    }
}