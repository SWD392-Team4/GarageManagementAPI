using GarageManagementAPI.Shared.Enum;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Entities.NewModels
{
    public partial class AppointmentDetailPackage : BaseEntity<AppointmentDetailPackage>
    {
        public Guid PackageHistoryId { get; set; }

        public Guid AppointmentId { get; set; }

        public Guid? UpdateByEmployeeId { get; set; }

        public Guid? UpdateByCustomerId { get; set; }

        [EnumDataType(typeof(SystemStatus))]
        public SystemStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public virtual Appointment Appointment { get; set; } = null!;

        public virtual PackageHistory PackageHistory { get; set; } = null!;

        public virtual User? UpdateByCustomer { get; set; }

        public virtual User? UpdateByEmployee { get; set; }
    }

}

