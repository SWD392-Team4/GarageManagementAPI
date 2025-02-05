using GarageManagementAPI.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Entities.Models
{
    public partial class PackageUsageDetail : BaseEntity<PackageUsageDetail>
    {
        public Guid PackageUsageId { get; set; }

        public Guid AppointmentId { get; set; }

        [EnumDataType(typeof(SystemStatus))]
        public SystemStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public virtual Appointment Appointment { get; set; } = null!;

        public virtual PackageUsage PackageUsage { get; set; } = null!;
    }

}

