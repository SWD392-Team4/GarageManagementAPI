using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.PackageUsage
{
    public record PackageUsageDtoForUpdate : PackageUsageDtoForManipulation
    {
        [EnumDataType(typeof(PackageUsageStatus))]
        public PackageUsageStatus Status { get; set; }
    }
}
