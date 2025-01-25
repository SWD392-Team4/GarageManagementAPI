using GarageManagementAPI.Shared.Enum;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Entities.NewModels;

public partial class PackageFeedBack : BaseEntity<PackageFeedBack>
{
    public Guid CustomerId { get; set; }

    public Guid PackageId { get; set; }

    public string FeedBack { get; set; } = null!;

    public string Emoji { get; set; } = null!;

    [EnumDataType(typeof(SystemStatus))]
    public SystemStatus Status { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset UpdatedAt { get; set; }

    public virtual User Customer { get; set; } = null!;

    public virtual Package Package { get; set; } = null!;
}
