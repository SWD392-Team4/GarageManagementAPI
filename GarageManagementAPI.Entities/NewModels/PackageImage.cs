using GarageManagementAPI.Shared.Enum;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Entities.NewModels;

public partial class PackageImage : BaseEntity<PackageImage>
{
    public Guid PackageId { get; set; }

    public string Link { get; set; } = null!;

    [EnumDataType(typeof(SystemStatus))]
    public SystemStatus Status { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset UpdatedAt { get; set; }

    public virtual Package Package { get; set; } = null!;
}
