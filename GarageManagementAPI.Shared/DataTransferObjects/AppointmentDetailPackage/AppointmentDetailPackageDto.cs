using GarageManagementAPI.Shared.DataTransferObjects.Package;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.AppointmentDetailPackage
{
    public record AppointmentDetailPackageDto
    {
        public Guid Id { get; set; }
        public Guid PackageHistoryId { get; set; }

        public Guid AppointmentId { get; set; }

        [EnumDataType(typeof(AppointmentDetailPackageStatus))]
        public AppointmentDetailPackageStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public decimal? PackagePrice { get; set; }

        public string? PackageName { get; set; }

    }
}
