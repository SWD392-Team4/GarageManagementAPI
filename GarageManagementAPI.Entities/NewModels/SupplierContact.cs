using GarageManagementAPI.Shared.Enum;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Entities.NewModels;

public partial class SupplierContact : BaseEntity<SupplierContact>
{
    public Guid SupplierId { get; set; }

    public string ContactPersonName { get; set; } = null!;

    public string ContactPosition { get; set; } = null!;

    public string ContactPhoneNumber { get; set; } = null!;

    public string ContactEmail { get; set; } = null!;

    [EnumDataType(typeof(SystemStatus))]
    public SystemStatus Status { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset UpdatedAt { get; set; }

    public virtual ICollection<GoodsReceived> GoodsReceiveds { get; set; } = new List<GoodsReceived>();

    public virtual Supplier Supplier { get; set; } = null!;
}
