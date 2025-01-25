using GarageManagementAPI.Shared.Enum;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Entities.NewModels;

public partial class GoodsReceived : BaseEntity<GoodsReceived>
{
    public Guid CreatedWarehouseManagerId { get; set; }

    public Guid SupplierContactId { get; set; }

    public Guid WarehouseId { get; set; }

    public string RefereneceNumber { get; set; } = null!;

    public string InvoiceCode { get; set; } = null!;

    public string SourceAddress { get; set; } = null!;

    public string SourceProvince { get; set; } = null!;

    public string SourceDistrict { get; set; } = null!;

    public string SourceWards { get; set; } = null!;

    public decimal TotalPrice { get; set; }

    [EnumDataType(typeof(SystemStatus))]
    public SystemStatus Status { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset UpdatedAt { get; set; }

    public virtual User CreatedWarehouseManager { get; set; } = null!;

    public virtual ICollection<GoodsReceivedDetail> GoodsReceivedDetails { get; set; } = new List<GoodsReceivedDetail>();

    public virtual SupplierContact SupplierContact { get; set; } = null!;

    public virtual Workplace Warehouse { get; set; } = null!;
}
