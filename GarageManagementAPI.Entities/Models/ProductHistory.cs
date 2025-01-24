using Microsoft.EntityFrameworkCore;

namespace GarageManagementAPI.Entities.Models
{
    public class ProductHistory : BaseEntity<ProductHistory>
    {
        public Guid ProductId { get; set; }

        [Precision(18, 2)]
        public decimal Price { get; set; }

        public Product? Product { get; set; }

        public ICollection<AppointmentReplacementParts>? AppointmentReplacementParts { get; set; }

        public ICollection<InvoiceReplacementParts>? InvoiceReplacementParts { get; set; }

        public ICollection<InvoiceDetailSell>? invoiceDetailSells { get; set; }
    }
}