using GarageManagementAPI.Shared.DataTransferObjects.Package;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IPackageService
    {
        Task<Result<IEnumerable<PackageDto>>> GetPackagesAsync(PackageParameters packageParameters, bool trackChanges);

        Task<Result<PackageDto>> GetPackageByIdAsync(Guid id, bool trackChanges);

        Task<Result<PackageDto>> CreatePackage(PackageDtoForCreation packageDtoForCreation, List<(string? publicId, string? absoluteUrl)>? imageTuples = null);

        Task<Result> UpdatePackage(Guid id, PackageDtoForUpdate packageDtoForUpdate, List<(string? publicId, string? absoluteUrl)>? imageTuples = null);

        Task<Result> RemovePacakge(Guid id);
    }
}