using GarageManagementAPI.Shared.Enum;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Entities.NewModels
{
    public partial class CarConditionImage : BaseEntity<CarConditionImage>
    {
        public Guid AppointmentDetailId { get; set; }

        public string Link { get; set; } = null!;

        [EnumDataType(typeof(SystemStatus))]
        public SystemStatus Status { get; set; }

        [EnumDataType(typeof(ConditionStage))]
        public ConditionStage ConditionStage { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public virtual AppointmentDetail AppointmentDetail { get; set; } = null!;
    }
}


