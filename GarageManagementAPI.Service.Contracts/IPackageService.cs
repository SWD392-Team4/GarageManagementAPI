using GarageManagementAPI.Shared.DataTransferObjects.Package;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;
using System.Dynamic;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IPackageService
    {
        Task<Result<IEnumerable<ExpandoObject>>> GetServiceOfPackageAsync(Guid packgeId, ServiceParameters serviceParameters);

        Task<Result<IEnumerable<ExpandoObject>>> GetPackagesAsync(PackageParameters packageParameters, bool trackChanges);

        Task<Result<ExpandoObject>> GetPackageByIdAsync(Guid packageId, bool trackChanges, string? fields = null);

        Task<Result<ExpandoObject>> CreatePackageAsync(PackageDtoForCreation packageDtoForCreation, List<(string? imageId, string? imageLink)>? imageTuples = null, string? fields = null);

        Task<Result> UpdatePackageAsync(Guid packageId, PackageDtoForUpdate packageDtoForUpdate);

        Task<Result> RemovePacakgeAsync(Guid packageId);
    }
}