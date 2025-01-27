namespace GarageManagementAPI.Entities.Models
{
    public partial class ReplacementPart : BaseEntity<ReplacementPart>
    {
        public Guid InvoiceDetailId { get; set; }

        public Guid ProductHistoryId { get; set; }

        public Guid ProductAtGarageId { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public virtual InvoiceServiceDetail InvoiceDetail { get; set; } = null!;

        public virtual ProductAtGarage ProductAtGarage { get; set; } = null!;

        public virtual ProductHistory ProductHistory { get; set; } = null!;
    }

}

