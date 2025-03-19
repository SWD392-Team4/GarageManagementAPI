namespace GarageManagementAPI.Entities.Models
{
    public partial class ProductAtGarage : BaseEntity<ProductAtGarage>
    {
        public Guid GoodsIssuedDetailId { get; set; }
        public Guid ProductId { get; set; }
        public Guid WorkplaceId { get; set; }
        public int Quantity { get; set; }
        public string? ProductBarcodeAtGarage { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public virtual GoodsIssuedDetail GoodsIssuedDetail { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
        public virtual Workplace Workplace { get; set; } = null!;
        public virtual ICollection<InvoiceSellProduct> InvoiceSellProducts { get; set; } = new List<InvoiceSellProduct>();
        public virtual ICollection<ReplacementPart> ReplacementParts { get; set; } = new List<ReplacementPart>();
        public virtual ICollection<InvoiceSellProduct_ProductAtGarage> InvoiceSellProduct_ProductAtGarage { get; set; } = new List<InvoiceSellProduct_ProductAtGarage>();
        public virtual ICollection<AppointmentReplacementPart_ProductAtGarage> AppointmentReplacementPart_ProductAtGarages { get; set; } = new List<AppointmentReplacementPart_ProductAtGarage>();
    }

}

