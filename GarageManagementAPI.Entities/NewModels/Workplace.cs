using GarageManagementAPI.Shared.Enum;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Entities.NewModels;

public partial class Workplace : BaseEntity<Workplace>
{
    public string Name { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Province { get; set; } = null!;

    public string District { get; set; } = null!;

    public string Wards { get; set; } = null!;

    [EnumDataType(typeof(WorkplaceType))]
    public WorkplaceType WorkplaceType { get; set; }

    [EnumDataType(typeof(SystemStatus))]
    public SystemStatus Status { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset UpdatedAt { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<EmployeeInfo> EmployeeInfos { get; set; } = new List<EmployeeInfo>();

    public virtual ICollection<GoodsIssued> GoodsIssuedGarages { get; set; } = new List<GoodsIssued>();

    public virtual ICollection<GoodsIssued> GoodsIssuedWarehouses { get; set; } = new List<GoodsIssued>();

    public virtual ICollection<GoodsReceived> GoodsReceiveds { get; set; } = new List<GoodsReceived>();

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}
