using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Entities.Models
{
    public partial class GoodsIssuedDetail : BaseEntity<GoodsIssuedDetail>
    {
        public Guid ProductAtWareHouseId { get; set; }
        public Guid GoodsIssuedId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        [EnumDataType(typeof(GoodsReceivedStatus))]
        public GoodsReceivedStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public virtual GoodsIssued GoodsIssued { get; set; } = null!;

        public virtual ProductAtGarage? ProductAtGarage { get; set; }

        public virtual ProductAtWarehouse ProductAtWareHouse { get; set; } = null!;

        public virtual ICollection<GoodsTransaction> GoodsTransactions { get; set; } = new List<GoodsTransaction>();

    }

}

