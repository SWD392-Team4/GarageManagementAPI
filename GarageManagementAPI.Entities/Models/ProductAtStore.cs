namespace GarageManagementAPI.Entities.Models
{
    public class ProductAtStore : BaseEntity<ProductAtStore>
    {
        public Guid GoodsIssuedDetailId { get; set; }

        public Guid ProductId { get; set; }

        public Guid GarageId { get; set; }

        public int Quantity { get; set; }

        public required string BarcodeAtStore { get; set; }

        public Product? Product { get; set; }

        public Garage? Garage { get; set; }

        public GoodsIssuedDetail? GoodsIssuedDetail { get; set; }

        public ICollection<InvoiceReplacementParts>? InvoiceReplacementParts { get; set; }

        public ICollection<InvoiceDetailSell>? invoiceDetailSells { get; set; }
    }
}