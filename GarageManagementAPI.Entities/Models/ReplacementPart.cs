namespace GarageManagementAPI.Entities.Models
{
    public partial class ReplacementPart : BaseEntity<ReplacementPart>
    {
        public Guid InvoiceDetailId { get; set; }

        public Guid ProductHistoryId { get; set; }

        public int Quantity { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public virtual InvoiceServiceDetail InvoiceDetail { get; set; } = null!;

        public virtual IEnumerable<ReplacementPart_ProductAtGarage> ReplacementPart_ProductAtGarages { get; set; } = new List<ReplacementPart_ProductAtGarage>();

        public virtual ProductHistory ProductHistory { get; set; } = null!;
    }

}

