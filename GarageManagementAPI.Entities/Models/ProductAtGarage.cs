namespace GarageManagementAPI.Entities.Models
{
    public partial class ProductAtGarage : BaseEntity<ProductAtGarage>
    {
        public Guid GoodsIssuedDetailId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public string ProductBarcodeAtGarage { get; set; } = null!;
        public DateTimeOffset CreatedAt { get; set; }
        public virtual GoodsIssuedDetail GoodsIssuedDetail { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;

        public virtual ICollection<AppointmentReplacementPart> AppointmentReplacementParts { get; set; } = new List<AppointmentReplacementPart>();

        public virtual ICollection<InvoiceSellProduct> InvoiceSellProducts { get; set; } = new List<InvoiceSellProduct>();

        public virtual ICollection<ReplacementPart> ReplacementParts { get; set; } = new List<ReplacementPart>();
    }

}

