using Microsoft.EntityFrameworkCore;

namespace GarageManagementAPI.Entities.Models
{
    public class Appointment : BaseEntity<Appointment>
    {
        public Guid? ApprovedBy { get; set; }

        public Guid CarModelId { get; set; }

        public Guid GarageId { get; set; }

        public int Mileage { get; set; }

        public required string CustomerName { get; set; }

        public required string CustomerPhone { get; set; }

        public required string CustomerEmail { get; set; }

        public required string CarLicencePlateNumber { get; set; }

        public string? CarCondition { get; set; }

        public string? CanceledReason { get; set; }

        [Precision(18, 2)]
        public required decimal ExpectedPrice { get; set; }

        public required DateTimeOffset EstimatedAppointmentTime { get; set; }

        public DateTimeOffset? ActualAppointmentTime { get; set; }

        public DateTimeOffset? EstimatedEndTime { get; set; }

        public DateTimeOffset? ActualEndTime { get; set; }

        public required string AppointmentType { get; set; }

        public required string Status { get; set; }

        public User? User { get; set; }

        public CarModel? CarModel { get; set; }

        public Garage? Garage { get; set; }

        public InvoiceAppointment? InvoiceAppointments { get; set; }

        public ICollection<AppointmentDetail>? AppointmentDetails { get; set; }

        public ICollection<PackageUsageDetail>? PackageUsageDetails { get; set; }

        public ICollection<PackageProvided>? PackageProvideds { get; set; }

    }
}