using GarageManagementAPI.Shared.Enum;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Entities.NewModels;

public partial class PackageCondition : BaseEntity<PackageCondition>
{
    public Guid PackageId { get; set; }

    [EnumDataType(typeof(PackageConditionType))]
    public PackageConditionType ConditionType { get; set; }

    public int ConditionValue { get; set; }

    public virtual Package Package { get; set; } = null!;
}
