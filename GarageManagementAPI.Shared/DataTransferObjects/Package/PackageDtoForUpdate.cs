using GarageManagementAPI.Shared.DataTransferObjects.PackageCondition;
using GarageManagementAPI.Shared.DataTransferObjects.PackageHistory;
using GarageManagementAPI.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.Package
{
    public record PackageDtoForUpdate : PackageDtoForManipulation
    {
        [EnumDataType(typeof(PackageStatus))]
        public PackageStatus Status { get; set; }


        public IEnumerable<string>? ImageLinksForRemove { get; set; }

    }
}
