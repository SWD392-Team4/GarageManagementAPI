using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Entities.Models
{
    public partial class AppointmentDetailPackage : BaseEntity<AppointmentDetailPackage>
    {
        public Guid PackageHistoryId { get; set; }

        public Guid AppointmentId { get; set; }

        [EnumDataType(typeof(AppointmentDetailPackageStatus))]
        public AppointmentDetailPackageStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public virtual Appointment Appointment { get; set; } = null!;

        public virtual PackageHistory PackageHistory { get; set; } = null!;

    }

}

