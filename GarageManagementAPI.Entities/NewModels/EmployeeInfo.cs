using GarageManagementAPI.Shared.Enum;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Entities.NewModels;

public partial class EmployeeInfo : BaseEntity<EmployeeInfo>
{
    public Guid WorkplaceId { get; set; }

    public string CitizenIdentification { get; set; } = null!;

    public bool Gender { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset UpdatedAt { get; set; }

    [EnumDataType(typeof(WorkplaceType))]
    public WorkplaceType WorkPlaceType { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual Workplace Workplace { get; set; } = null!;
}
