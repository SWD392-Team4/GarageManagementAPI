using GarageManagementAPI.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Entities.Models
{
    public partial class EmployeeSchedule : BaseEntity<EmployeeSchedule>
    {
        public Guid AppointmentDetailId { get; set; }

        public Guid EmployeeId { get; set; }

        public DateTimeOffset? StartTime { get; set; }

        public DateTimeOffset? EstimatedEndTime { get; set; }

        public DateTimeOffset? ActualEndTime { get; set; }

        [EnumDataType(typeof(SystemStatus))]
        public SystemStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public virtual AppointmentDetail AppointmentDetail { get; set; } = null!;

        public virtual User Employee { get; set; } = null!;
    }

}

