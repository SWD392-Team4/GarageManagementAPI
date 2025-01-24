namespace GarageManagementAPI.Entities.Models
{
    public class InvoiceSell : BaseEntity<InvoiceSell>
    {
        public Guid GarageId { get; set; }

        public Guid CreateBy { get; set; }

        public required string CustomerName { get; set; }

        public required string CustomerPhoneNumber { get; set; }

        public required string CustomerEmail { get; set; }

        public required string Status { get; set; }

        public Garage? Garage { get; set; }

        public User? Employee { get; set; }

        public ICollection<InvoiceDetailSell>? InvoiceDetailSells { get; set; }
    }
}