namespace GarageManagementAPI.Entities.Models
{
    public partial class InvoiceSellProduct : BaseEntity<InvoiceSellProduct>
    {

        public Guid InvoiceId { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public virtual Invoice Invoice { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;

        public virtual ICollection<InvoiceSellProduct_ProductAtGarage> InvoiceSellProduct_ProductAtGarage { get; set; } = new List<InvoiceSellProduct_ProductAtGarage>();

    }

}

