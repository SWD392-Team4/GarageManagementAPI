using GarageManagementAPI.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.PackageCondition
{
    public record PackageConditionDto : BaseDto<PackageConditionDto>
    {
        public Guid Id { get; set; }

        public Guid PackageId { get; set; }

        [EnumDataType(typeof(PackageConditionType))]
        public PackageConditionType ConditionType { get; set; }

        public int ConditionValue { get; set; }
    }
}
