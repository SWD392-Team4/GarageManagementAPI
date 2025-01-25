using GarageManagementAPI.Shared.Enum;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Entities.NewModels;

public partial class ProductAtWarehouse : BaseEntity<ProductAtWarehouse>
{
    public int Quantity { get; set; }

    [EnumDataType(typeof(SystemStatus))]
    public SystemStatus Status { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset UpdatedAt { get; set; }

    public virtual ICollection<GoodsIssuedDetail> GoodsIssuedDetails { get; set; } = new List<GoodsIssuedDetail>();

    public virtual GoodsReceivedDetail GoodsReceivedDetail { get; set; } = null!;
}
