using GarageManagementAPI.Shared.DataTransferObjects.Package;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.RequestFeatures;
using GarageManagementAPI.Shared.ResultModel;
using System.Dynamic;

namespace GarageManagementAPI.Service.Contracts
{
    public interface IPackageService
    {
        Task<Result<IEnumerable<ExpandoObject>>> GetPackagesAsync(PackageParameters packageParameters, bool trackChanges);

        Task<Result<ExpandoObject>> GetPackageByIdAsync(Guid id, bool trackChanges, string? fields = null);

        Task<Result<ExpandoObject>> CreatePackage(PackageDtoForCreation packageDtoForCreation, List<(string? ImageId, string? ImageLink)>? imageTuples = null, string? fields = null);

        Task<Result> UpdatePackage(Guid id, PackageDtoForUpdate packageDtoForUpdate);

        Task<Result> RemovePacakge(Guid id);
    }
}