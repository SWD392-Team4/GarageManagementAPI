using GarageManagementAPI.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Entities.Models
{
    public partial class ServiceHistory : BaseEntity<ServiceHistory>
    {
        public Guid ServiceId { get; set; }

        public decimal Price { get; set; }

        [EnumDataType(typeof(SystemStatus))]
        public SystemStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public virtual ICollection<AppointmentDetail> AppointmentDetails { get; set; } = new List<AppointmentDetail>();

        public virtual ICollection<InvoiceServiceDetail> InvoiceServiceDetails { get; set; } = new List<InvoiceServiceDetail>();

        public virtual Service Service { get; set; } = null!;
    }

}

