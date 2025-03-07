using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.ErrorModel;

namespace GarageManagementAPI.Shared.ErrorsConstant.PackageCondition
{
    public class PackageConditionErrors
    {
        public const string PackageConditionExist = "The condition with type {0} of the package have id {0} with value {0} already exist.";
        public const string PackageConditionNotFound = "Can not found the condition with id {0} of the package have id {0}.";

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
    }
}
