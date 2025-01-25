using GarageManagementAPI.Shared.Enum;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Entities.NewModels;

public partial class PackageUsage : BaseEntity<PackageUsage>
{
    public Guid InvoiceAppointmentId { get; set; }

    public Guid PackageHistoryId { get; set; }

    public Guid CustomerCarId { get; set; }

    public int UsagedCount { get; set; }

    public DateTimeOffset StartDate { get; set; }

    public DateTimeOffset EndDate { get; set; }

    [EnumDataType(typeof(SystemStatus))]
    public SystemStatus Status { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset UpdatedAt { get; set; }

    public virtual CustomerCar CustomerCar { get; set; } = null!;

    public virtual Invoice InvoiceAppointment { get; set; } = null!;

    public virtual PackageHistory PackageHistory { get; set; } = null!;

    public virtual ICollection<PackageUsageDetail> PackageUsageDetails { get; set; } = new List<PackageUsageDetail>();
}
