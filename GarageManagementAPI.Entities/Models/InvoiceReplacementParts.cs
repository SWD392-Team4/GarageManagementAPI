namespace GarageManagementAPI.Entities.Models
{
    public class InvoiceReplacementParts : BaseEntity<InvoiceReplacementParts>
    {
        public Guid InvoiceDetailRepairId { get; set; }

        public Guid ProductHistoryId { get; set; }

        public Guid ProductAtStoreId { get; set; }

        public int Quantity { get; set; }

        public InvoiceDetailRepair? InvoiceDetailRepair { get; set; }

        public ProductHistory? ProductHistory { get; set; }

        public ProductAtStore? ProductAtStore { get; set; }
    }
}