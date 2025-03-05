using GarageManagementAPI.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.PackageUsageDetail
{
    public record PackageUsageDetailDtoForUpdate : PackageUsageDetailDtoForManipulation
    {
        [EnumDataType(typeof(SystemStatus))]
        public SystemStatus Status { get; set; }
    }
}
