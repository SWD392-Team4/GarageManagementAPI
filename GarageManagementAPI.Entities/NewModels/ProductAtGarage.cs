using GarageManagementAPI.Shared.Enum;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Entities.NewModels;

public partial class ProductAtGarage : BaseEntity<ProductAtGarage>
{
    public int Quantity { get; set; }

    public string ProductBarcodeAtGarage { get; set; } = null!;

    [EnumDataType(typeof(SystemStatus))]
    public SystemStatus Status { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset UpdatedAt { get; set; }

    public virtual ICollection<AppointmentReplacementPart> AppointmentReplacementParts { get; set; } = new List<AppointmentReplacementPart>();

    public virtual GoodsIssuedDetail GoodsIssuedDetail { get; set; } = null!;

    public virtual ICollection<InvoiceSellProduct> InvoiceSellProducts { get; set; } = new List<InvoiceSellProduct>();

    public virtual ICollection<ReplacementPart> ReplacementParts { get; set; } = new List<ReplacementPart>();
}
