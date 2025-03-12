using GarageManagementAPI.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Entities.Models
{
    public partial class ProductAtWarehouse : BaseEntity<ProductAtWarehouse>
    {
        public Guid GoodsReceivedDetailId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        [EnumDataType(typeof(SystemStatus))]
        public SystemStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public virtual ICollection<GoodsIssuedDetail_ProductAtWarehouse> GoodsIssuedDetail_ProductAtWarehouse { get; set; } = new List<GoodsIssuedDetail_ProductAtWarehouse>();

        public virtual GoodsReceivedDetail GoodsReceivedDetail { get; set; } = null!;
    }

}

