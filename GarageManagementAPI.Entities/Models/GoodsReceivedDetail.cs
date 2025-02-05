using GarageManagementAPI.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Entities.Models
{
    public partial class GoodsReceivedDetail : BaseEntity<GoodsIssuedDetail>
    {
        public Guid ProductId { get; set; }

        public Guid GoodsReceivedId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalPrice { get; set; }

        [EnumDataType(typeof(SystemStatus))]
        public SystemStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public virtual GoodsReceived GoodsReceived { get; set; } = null!;

        public virtual Product Product { get; set; } = null!;

        public virtual ProductAtWarehouse? ProductAtWarehouse { get; set; }
    }

}

