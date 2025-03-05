using GarageManagementAPI.Shared.ErrorModel;

namespace GarageManagementAPI.Shared.ErrorsConstant.Package
{
    public class PackageErrors
    {
        public const string PackageNotfound = "Package with id {0} not found.";
        public const string PackageAlreadyExist = "Package with name {0} alreadyExist.";


        public static ErrorsResult GetPackageNotFoundError(Guid id)
            => new()
            {
                Code = nameof(PackageNotfound),
                Description = string.Format(PackageNotfound, id)
            };

        public static ErrorsResult GetPackageAlreadyExistError(string name)
        {
            return new()
            {
                Code = nameof(PackageAlreadyExist),
                Description = string.Format(PackageAlreadyExist, name)
            };
        }
    }
}
