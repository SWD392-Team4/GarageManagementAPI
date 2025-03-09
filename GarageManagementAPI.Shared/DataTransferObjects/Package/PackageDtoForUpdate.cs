using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.Package
{
    public record PackageDtoForUpdate : PackageDtoForManipulation
    {
        [EnumDataType(typeof(PackageStatus))]
        public PackageStatus? Status { get; set; }

        public Guid[]? AddServices { get; set; }

        public Guid[]? RemoveServices { get; set; }
    }
}
