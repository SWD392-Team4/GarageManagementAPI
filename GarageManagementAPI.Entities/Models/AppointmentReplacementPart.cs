using GarageManagementAPI.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Entities.Models
{
    public partial class AppointmentReplacementPart : BaseEntity<AppointmentReplacementPart>
    {
        public Guid AppointmentDetailId { get; set; }

        public Guid ProductHistoryId { get; set; }

        public Guid ProductAtGarageId { get; set; }

        public int Quantity { get; set; }

        [EnumDataType(typeof(SystemStatus))]
        public SystemStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public virtual AppointmentDetail AppointmentDetail { get; set; } = null!;

        public virtual ProductAtGarage ProductAtGarage { get; set; } = null!;

        public virtual ProductHistory ProductHistory { get; set; } = null!;
    }

}

