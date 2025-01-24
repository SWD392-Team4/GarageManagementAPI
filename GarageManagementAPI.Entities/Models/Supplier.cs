namespace GarageManagementAPI.Entities.Models
{
    public class Supplier : BaseEntity<Supplier>
    {
        public required string ContactName { get; set; }

        public required string ContactEmail { get; set; }

        public required string CompanyCode { get; set; }

        public required string CompanyAddress { get; set; }

        public required string CompanyHotline { get; set; }

        public ICollection<GoodsReceived>? GoodsReceiveds { get; set; }
    }
}