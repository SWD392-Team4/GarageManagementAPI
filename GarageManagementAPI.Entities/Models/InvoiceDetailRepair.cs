using Microsoft.EntityFrameworkCore;

namespace GarageManagementAPI.Entities.Models
{
    public class InvoiceDetailRepair : BaseEntity<InvoiceDetailRepair>
    {
        public Guid AppointmentDetailId { get; set; }

        public Guid AppointmentId { get; set; }

        public Guid InvoiceAppointmentId { get; set; }

        [Precision(18, 2)]
        public decimal TotalServicePrice { get; set; }

        [Precision(18, 2)]
        public decimal TotalReplacePartPrice { get; set; }

        public AppointmentDetail? AppointmentDetail { get; set; }

        public Appointment? Appointment { get; set; }

        public InvoiceAppointment? InvoiceAppointment { get; set; }

        public ICollection<InvoiceReplacementParts>? InvoiceReplacementParts { get; set; }
    }
}