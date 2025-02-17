using GarageManagementAPI.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Entities.Models

{
    public partial class Appointment : BaseEntity<Appointment>
    {
        public Guid? ApproveByEmployeeId { get; set; }

        public Guid CarModelId { get; set; }

        public Guid GarageId { get; set; }

        public int Mileage { get; set; }

        public string CustomerName { get; set; } = null!;

        public string CustomerPhoneNumber { get; set; } = null!;

        public string CustomerEmail { get; set; } = null!;

        public DateTimeOffset EstimatedAppointmentTime { get; set; }

        public DateTimeOffset? ActualAppointmentTime { get; set; }

        public DateTimeOffset EstimatedEndTime { get; set; }

        public DateTimeOffset? ActualEndTime { get; set; }

        public decimal Price { get; set; }

        public string AppointmentType { get; set; } = null!;

        public string? CarLicensePlateNumber { get; set; }

        public string? CarCondition { get; set; }

        public string? CanceledReason { get; set; }

        [EnumDataType(typeof(SystemStatus))]
        public SystemStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public virtual ICollection<AppointmentDetailPackage> AppointmentDetailPackages { get; set; } = new List<AppointmentDetailPackage>();

        public virtual ICollection<AppointmentDetail> AppointmentDetails { get; set; } = new List<AppointmentDetail>();

        public virtual User? ApproveByEmployee { get; set; }

        public virtual CarModel CarModel { get; set; } = null!;

        public virtual Workplace Garage { get; set; } = null!;

        public virtual Invoice? Invoice { get; set; }

        public virtual PackageUsageDetail? PackageUsageDetail { get; set; }
    }
}


