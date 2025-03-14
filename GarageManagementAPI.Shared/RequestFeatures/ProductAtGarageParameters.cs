namespace GarageManagementAPI.Shared.RequestFeatures
{
    public class ProductAtGarageParameters : RequestParameters
    {
        public ProductAtGarageParameters() => OrderBy = "CreatedAt";
        public int? minQuantity { get; set; } = 0;
        public int maxQuantity { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
