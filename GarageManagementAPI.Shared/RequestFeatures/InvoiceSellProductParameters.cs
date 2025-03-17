namespace GarageManagementAPI.Shared.RequestFeatures
{
    public class InvoiceSellProductParameters : RequestParameters
    {
        public InvoiceSellProductParameters() => OrderBy = "Quantity";

        public int minQuantity { get; set; } = 0;

        public int maxQuantity { get; set; }
    }
}
