using GarageManagementAPI.Shared.Enum;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Entities.NewModels;

public partial class PackageDetail : BaseEntity<PackageDetail>
{
    public Guid ServiceId { get; set; }

    public Guid PackageHistoryId { get; set; }

    [EnumDataType(typeof(SystemStatus))]
    public SystemStatus Status { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset UpdatedAt { get; set; }

    public virtual PackageHistory PackageHistory { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;
}
