using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.ErrorModel;

namespace GarageManagementAPI.Shared.ErrorsConstant.PackageCondition
{
    public class PackageConditionErrors
    {
        public const string ConditionTypeRequired = "Condition type is required.";
        public const string ConditionTypeInvalid = "Condition type is invalid.";
        public const string ConditionValueRequired = "Value is required.";

        public const string PackageConditionExist = "The condition with type {0} of the package have id {1} with value {2} already exist.";
        public const string PackageConditionNotFound = "Can not found the condition with id {0} of the package have id {1}.";
        public const string PackageConditionOfPackageNotFound = "Can not found the condition of the package have id {0}.";
        public const string PackageMinConditionValueGreaterThanMaxConditionValue = "The minimum condition value must be less than the maximum condition value.";

        public static ErrorsResult GetPackageConditionExistError(Guid packageId, PackageConditionType conditionType, int value)
        {
            return new()
            {
                Code = nameof(PackageConditionExist),
                Description = string.Format(PackageConditionExist, conditionType.ToString(), packageId, value)
            };
        }

        public static ErrorsResult GetPackageConditionNotFoundError(Guid packageId, Guid packageConditionId)
        {
            return new()
            {
                Code = nameof(PackageConditionNotFound),
                Description = string.Format(PackageConditionNotFound, packageConditionId, packageId)
            };
        }

        public static ErrorsResult GetPackageConditionOfPackageNotFoundError(Guid packageId)
        {
            return new()
            {
                Code = nameof(PackageConditionOfPackageNotFound),
                Description = string.Format(PackageConditionOfPackageNotFound, packageId)
            };
        }

        public static ErrorsResult GetPackageMinConditionValueGreaterThanMaxConditionValueError()
        {
            return new()
            {
                Code = nameof(PackageMinConditionValueGreaterThanMaxConditionValue),
                Description = PackageMinConditionValueGreaterThanMaxConditionValue
            };
        }
    }
}
