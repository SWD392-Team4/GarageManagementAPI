namespace GarageManagementAPI.Entities.Models
{
    public class AppointmentDetail : BaseEntity<AppointmentDetail>
    {
        public required Guid ServiceHistoryId { get; set; }

        public required Guid AppointmentId { get; set; }

        public required string ServiceNotes { get; set; }

        public required string Status { get; set; }

        public ServiceHistory? ServiceHistory { get; set; }

        public Appointment? Appointment { get; set; }

        public InvoiceDetailRepair? InvoiceDetailRepair { get; set; }

        public ICollection<EmployeeSchedule>? EmployeeSchedules { get; set; }

        public ICollection<AppointmentReplacementParts>? AppointmentReplacementParts { get; set; }

        public ICollection<CarConditionImage>? CarConditionImages { get; set; }
    }
}