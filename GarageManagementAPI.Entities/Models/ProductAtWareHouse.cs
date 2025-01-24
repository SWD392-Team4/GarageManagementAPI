namespace GarageManagementAPI.Entities.Models
{
    public class ProductAtWareHouse : BaseEntity<ProductAtWareHouse>
    {
        public Guid ProductId { get; set; }

        public Guid GoodsReceivedDetailId { get; set; }

        public int Quantity { get; set; }

        public Product? Product { get; set; }

        public GoodsReceivedDetail? GoodsReceivedDetail { get; set; }

        public ICollection<GoodsIssuedDetail>? GoodsIssueds { get; set; }
    }
}