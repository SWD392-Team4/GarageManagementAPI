using GarageManagementAPI.Shared.Enums.SystemStatuss;

using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.AppointmentDetailPackage
{
    public record AppointmentDetailPackageDtoForUpdate
    {
        [EnumDataType(typeof(AppointmentDetailPackageStatus))]
        public AppointmentDetailPackageStatus Status { get; set; }
    }
}
