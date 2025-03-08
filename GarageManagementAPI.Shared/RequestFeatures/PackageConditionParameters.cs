using GarageManagementAPI.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.RequestFeatures
{
    public class PackageConditionParameters : RequestParameters
    {
        [EnumDataType(typeof(PackageConditionType))]
        public PackageConditionType? ConditionType { get; set; }

        public uint MaxConditionValue { get; set; } = int.MaxValue;
        public uint MinConditionValue { get; set; } = 0;
        public bool ValidConditionValueRange => MaxConditionValue > MinConditionValue;
    }
}
