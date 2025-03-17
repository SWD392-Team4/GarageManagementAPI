namespace GarageManagementAPI.Shared.RequestFeatures
{
    public class InvoiceParameters : RequestParameters
    {
        public InvoiceParameters() => OrderBy = "TotalPrice";
        public decimal MinTotalPrice { get; set; } = 0;
        public decimal? MaxTotalPrice { get; set; }
    }
}
