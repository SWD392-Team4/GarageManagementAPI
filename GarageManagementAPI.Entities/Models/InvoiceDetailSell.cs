namespace GarageManagementAPI.Entities.Models
{
    public class InvoiceDetailSell : BaseEntity<InvoiceDetailSell>
    {
        public Guid ProductHistoryId { get; set; }

        public Guid InvoiceSellId { get; set; }

        public Guid ProductAtStoreId { get; set; }

        public int Quantity { get; set; }

        public ProductHistory? ProductHistory { get; set; }

        public InvoiceSell? InvoiceSell { get; set; }

        public ProductAtStore? ProductAtStore { get; set; }
    }
}