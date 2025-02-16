using GarageManagementAPI.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Entities.Models
{
    public partial class GoodsIssuedDetail : BaseEntity<GoodsIssuedDetail>
    {
        public Guid ProductAtWareHouseId { get; set; }

        public Guid GoodsIssuedId { get; set; }

        public int Quantity { get; set; }

        [EnumDataType(typeof(SystemStatus))]
        public SystemStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public virtual GoodsIssued GoodsIssued { get; set; } = null!;

        public virtual ProductAtGarage? ProductAtGarage { get; set; }

        public virtual ProductAtWarehouse ProductAtWareHouse { get; set; } = null!;
    }

}

