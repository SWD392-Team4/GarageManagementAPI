using GarageManagementAPI.Shared.Enum;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Entities.NewModels;

public partial class ProductCategory : BaseEntity<ProductCategory>
{
    public string Category { get; set; } = null!;

    [EnumDataType(typeof(SystemStatus))]
    public SystemStatus Status { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset UpdatedAt { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
