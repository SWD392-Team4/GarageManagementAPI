namespace GarageManagementAPI.Entities.Models
{
    public class InvoiceSellProduct_ProductAtGarage : BaseEntity<InvoiceSellProduct_ProductAtGarage>
    {
        public Guid ProductAtGarageId { get; set; }
        public virtual ProductAtGarage ProductAtGarage { get; set; } = null!;

        public Guid InvoiceSellProductId { get; set; }
        public virtual InvoiceSellProduct InvoiceSellProduct { get; set; } = null!;

        public int QuantityUsed { get; set; }
    }
}
