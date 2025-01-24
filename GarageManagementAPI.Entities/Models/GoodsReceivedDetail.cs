using Microsoft.EntityFrameworkCore;

namespace GarageManagementAPI.Entities.Models
{
    public class GoodsReceivedDetail : BaseEntity<GoodsReceivedDetail>
    {
        public Guid ProductId { get; set; }

        public Guid GoodsReceivedId { get; set; }

        public int Quantity { get; set; }

        [Precision(18, 2)]
        public decimal UnitPrice { get; set; }

        public Product? Product { get; set; }

        public GoodsReceived? GoodsReceived { get; set; }

        public ProductAtWareHouse? ProductAtWareHouse { get; set; }
    }
}