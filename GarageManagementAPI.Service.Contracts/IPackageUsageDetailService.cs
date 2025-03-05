using GarageManagementAPI.Shared.DataTransferObjects.PackageUsageDetail;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IPackageUsageDetailService
    {
        Task<Result<IEnumerable<PackageUsageDetailDto>>> GetPackageUsageDetailsAsync(PackageUsageDetailParameters packageUsageDetailParameters, bool trackChanges);
        Task<Result<PackageUsageDetailDto>> GetPackageUsageDetailByIdAsync(Guid id, bool trackChanges);
        Task<Result<PackageUsageDetailDto>> CreatePackageUsageDetailAsync(PackageUsageDetailDtoForCreation packageUsageDetailDtoForCreation);
        Task<Result> UpdatePackageUsageDetailAsync(Guid id, PackageUsageDetailDtoForUpdate packageUsageDetailDtoForUpdate);
        Task<Result> RemovePackageUsageDetailAsync(Guid id);
    }
}