using GarageManagementAPI.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.PackageCondition
{
    public record PackageConditionDtoForManipulation
    {
        [EnumDataType(typeof(PackageConditionType))]
        public PackageConditionType ConditionType { get; set; }

        public int ConditionValue { get; set; }
    }
}
