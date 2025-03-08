using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.Package
{
    public record PackageDtoForUpdate : PackageDtoForManipulation
    {
        [EnumDataType(typeof(PackageHistoryStatus))]
        public PackageHistoryStatus Status { get; set; }
    }
}
