using System.ComponentModel.DataAnnotations;
using GarageManagementAPI.Shared.Enums.SystemStatuss;

namespace GarageManagementAPI.Entities.Models
{
    public partial class ServiceHistory : BaseEntity<ServiceHistory>
    {
        public Guid ServiceId { get; set; }

        public decimal Price { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public virtual ICollection<AppointmentDetail> AppointmentDetails { get; set; } = new List<AppointmentDetail>();

        public virtual ICollection<InvoiceServiceDetail> InvoiceServiceDetails { get; set; } = new List<InvoiceServiceDetail>();

        public virtual Service Service { get; set; } = null!;
    }

}

