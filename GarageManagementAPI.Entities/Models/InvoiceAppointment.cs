namespace GarageManagementAPI.Entities.Models
{
    public class InvoiceAppointment : BaseEntity<InvoiceAppointment>
    {
        public Guid EmployeeId { get; set; }

        public Guid GarageId { get; set; }

        public Guid AppointmentId { get; set; }

        public required string CustomerName { get; set; }

        public required string CustomerEmail { get; set; }

        public required string CustomerPhoneNumber { get; set; }

        public required string Status { get; set; }

        public User? Employee { get; set; }

        public Garage? Garage { get; set; }

        public Appointment? Appointment { get; set; }
    }
}