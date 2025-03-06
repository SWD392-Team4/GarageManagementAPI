using GarageManagementAPI.Shared.ErrorModel;

namespace GarageManagementAPI.Shared.ErrorsConstant.Package
{
    public class PackageErrors
    {
        public const string PackageNotfound = "Package with ID {0} not found.";
        public const string PackageAlreadyExist = "Package with name '{0}' already exists.";
        public const string PackageDoesNotHaveAnyPackageHistory = "The package with ID {0} does not have any package history or does not have any active package history. Please create a new package history for it.";

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

        public static ErrorsResult GetPackageDoesNotHaveAnyPackageHistoryError(Guid id)
        {
            return new()
            {
                Code = nameof(PackageDoesNotHaveAnyPackageHistory),
                Description = string.Format(PackageDoesNotHaveAnyPackageHistory, id)
            };
        }
    }

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
