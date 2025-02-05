using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Entities.Models
{
    public partial class Workplace : BaseEntity<Workplace>
    {
        public required string Name { get; set; }

        public required string PhoneNumber { get; set; }

        public required string Address { get; set; }

        public required string Province { get; set; }

        public required string District { get; set; }

        public required string Ward { get; set; }

        [EnumDataType(typeof(WorkplaceType))]
        public WorkplaceType WorkplaceType { get; set; }

        [EnumDataType(typeof(WorkplaceStatus))]
        public WorkplaceStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

        public virtual ICollection<EmployeeInfo> EmployeeInfos { get; set; } = new List<EmployeeInfo>();

        public virtual ICollection<GoodsIssued> GoodsIssuedGarages { get; set; } = new List<GoodsIssued>();

        public virtual ICollection<GoodsIssued> GoodsIssuedWarehouses { get; set; } = new List<GoodsIssued>();

        public virtual ICollection<GoodsReceived> GoodsReceiveds { get; set; } = new List<GoodsReceived>();

        public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
    }
}


