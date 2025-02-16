namespace GarageManagementAPI.Entities.Models
{
    public partial class InvoiceSellProduct : BaseEntity<InvoiceSellProduct>
    {
        public Guid ProductHistoryId { get; set; }

        public Guid InvoiceId { get; set; }

        public Guid ProductAtGarageId { get; set; }

        public int Quantity { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public virtual Invoice Invoice { get; set; } = null!;

        public virtual ProductAtGarage ProductAtGarage { get; set; } = null!;

        public virtual ProductHistory ProductHistory { get; set; } = null!;
    }

}

