using GarageManagementAPI.Shared.Enum;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Entities.NewModels
{
    public partial class AppointmentDetail : BaseEntity<AppointmentDetail>
    {
        public Guid ServiceHistoryId { get; set; }

        public Guid? UpdateByEmployeeId { get; set; }

        public Guid? UpdateByCustomerId { get; set; }

        public Guid AppointmentId { get; set; }

        public string ServiceNote { get; set; } = null!;

        [EnumDataType(typeof(SystemStatus))]
        public SystemStatus Status { get; set; }

        public DateTimeOffset CreateAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public virtual Appointment Appointment { get; set; } = null!;

        public virtual ICollection<AppointmentReplacementPart> AppointmentReplacementParts { get; set; } = new List<AppointmentReplacementPart>();

        public virtual ICollection<CarConditionImage> CarConditionImages { get; set; } = new List<CarConditionImage>();

        public virtual ICollection<EmployeeSchedule> EmployeeSchedules { get; set; } = new List<EmployeeSchedule>();

        public virtual ServiceHistory ServiceHistory { get; set; } = null!;

        public virtual User? UpdateByCustomer { get; set; }

        public virtual User? UpdateByEmployee { get; set; }
    }
}


