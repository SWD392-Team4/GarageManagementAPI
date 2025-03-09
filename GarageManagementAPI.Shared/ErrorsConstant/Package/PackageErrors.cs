using GarageManagementAPI.Shared.ErrorModel;

namespace GarageManagementAPI.Shared.ErrorsConstant.Package
{
    public class PackageErrors
    {
        public const string ServiceCategoryRequired = "Service category is required.";
        public const string ServiceCategoryInvalid = "Service category is invalid.";
        public const string CarCategoryIdRequired = "Car category id is required.";
        public const string PackageNameRequired = "Package name is required.";
        public const string DescriptionRequired = "Description is required.";
        public const string TypeRequired = "Type is required.";
        public const string TypeInvalid = "Type is invalid.";
        public const string PackagePriceRequired = "Package price is required.";
        public const string ValidityPeriodRequired = "Validity period is required.";
        public const string TimeUnitRequired = "Time unit is required.";
        public const string TimeUnitInvalid = "Time unit is invalid.";
        public const string UsageLimitRequired = "Usage limit is required.";

        public const string ServiceListRequired = "Service list is required.";
        public const string PackageConditionsRequired = "Package conditions are required.";

        public const string StatusRequired = "Status is required.";
        public const string StatusInvalid = "Status is invalid.";

        public const string PackageNotfound = "Package with ID {0} not found.";
        public const string PackageAlreadyExist = "Package with name '{0}' already exists.";
        public const string PackageDoesNotHaveAnyPackageHistory = "The package with ID {0} does not have any package history or does not have any active package history. Please create a new package history for it.";

        public const string ServiceAlreadyExistInPackage = "Service with ID {0} already exists in the package have id {0}.";
        public const string ServiceNotExistInPackage = "Service with ID {0} not exist in package have id {0}.";

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

        public static ErrorsResult GetServiceAlreadyExistInPackageError(Guid serviceId, Guid packageId)
        {
            return new()
            {
                Code = nameof(ServiceAlreadyExistInPackage),
                Description = string.Format(ServiceAlreadyExistInPackage, serviceId, packageId)
            };
        }

        public static ErrorsResult GetServiceNotExistInPackage(Guid serviceId, Guid packageId)
        {
            return new()
            {
                Code = nameof(ServiceNotExistInPackage),
                Description = string.Format(ServiceNotExistInPackage, serviceId, packageId)
            };
        }
    }
}
