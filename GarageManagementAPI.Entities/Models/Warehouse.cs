namespace GarageManagementAPI.Entities.Models
{
    public class Warehouse : BaseEntity<Warehouse>
    {
        public required string Name { get; set; }

        public required string Address { get; set; }

        public ICollection<GoodsReceived>? GoodsReceiveds { get; set; }

        public ICollection<GoodsIssued>? GoodsIssueds { get; set; }
    }
}