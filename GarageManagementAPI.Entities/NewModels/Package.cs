using GarageManagementAPI.Shared.Enum;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Entities.NewModels;

public partial class Package : BaseEntity<Package>
{
    public string ServiceCategory { get; set; } = null!;

    public Guid CarCategoryId { get; set; }

    public string PackageName { get; set; } = null!;

    public string Description { get; set; } = null!;

    [EnumDataType(typeof(SystemStatus))]
    public SystemStatus Status { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset UpdatedAt { get; set; }

    public virtual CarCategory CarCategory { get; set; } = null!;

    public virtual ICollection<PackageCondition> PackageConditions { get; set; } = new List<PackageCondition>();

    public virtual ICollection<PackageFeedBack> PackageFeedBacks { get; set; } = new List<PackageFeedBack>();

    public virtual ICollection<PackageHistory> PackageHistories { get; set; } = new List<PackageHistory>();

    public virtual ICollection<PackageImage> PackageImages { get; set; } = new List<PackageImage>();
}
