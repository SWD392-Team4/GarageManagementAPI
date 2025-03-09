using GarageManagementAPI.Shared.ErrorModel;

namespace GarageManagementAPI.Shared.ErrorsConstant.PackageImages
{
    public class PackageImageErrors
    {
        public const string PackageImageNotFound = "Package image with id {0} not found.";

        public static ErrorsResult GetPackageImageNotFoundError(Guid id)
            => new()
            {
                Code = nameof(PackageImageNotFound),
                Description = string.Format(PackageImageNotFound, id)
            };

    }
}
