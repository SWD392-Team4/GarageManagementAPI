using GarageManagementAPI.Shared.DataTransferObjects.PackageImage;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;
using System.Dynamic;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IPackageImageService
    {
        Task<Result<IEnumerable<ExpandoObject>>> GetPackageImageByPackageIdAsync(Guid packageId, PackageImageParameters packageImageParameters);

        Task<Result<IEnumerable<PackageImageDto>>> GetPackageImageByPackageIdAsync(Guid packageId);

        Task<Result<PackageImageDto>> GetPackageImageByIdAsync(Guid packageId, Guid id);

        Task<Result<IEnumerable<PackageImageDto>>> CreatePackageImageAsync(Guid packageId, IEnumerable<(string? ImageId, string? ImageLink)> imageTuples);

        Task<Result> RemovePackageImageAsync(Guid packageId, Guid packageImageId);

        Task<Result> RemoveAllPackageImageOfPackageAsync(Guid packageId);
    }
}