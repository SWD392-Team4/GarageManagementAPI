using Microsoft.EntityFrameworkCore;

namespace GarageManagementAPI.Entities.Models
{
    public class GoodsIssuedDetail : BaseEntity<GoodsIssuedDetail>
    {
        public Guid ProductAtWareHouseId { get; set; }

        public Guid GoodsIssuedId { get; set; }

        [Precision(18, 2)]
        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public ProductAtWareHouse? ProductAtWareHouse { get; set; }

        public GoodsIssued? GoodsIssued { get; set; }

        public ProductAtStore? ProductAtStore { get; set; }
    }
}