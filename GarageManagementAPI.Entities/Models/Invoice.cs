using GarageManagementAPI.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Entities.Models
{
    public partial class Invoice : BaseEntity<Invoice>
    {
        public Guid EmployeeId { get; set; }

        public Guid? CustomerId { get; set; }

        public Guid GarageId { get; set; }

        [EnumDataType(typeof(InvoiceType))]
        public InvoiceType InvoiceType { get; set; }

        public string CustomerName { get; set; } = null!;

        public string CustomerPhoneNumber { get; set; } = null!;

        public string CustomerEmail { get; set; } = null!;

        public decimal TotalPrice { get; set; }

        [EnumDataType(typeof(SystemStatus))]
        public SystemStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public virtual Appointment Appointment { get; set; } = null!;

        public virtual User? Customer { get; set; }

        public virtual User Employee { get; set; } = null!;

        public virtual Workplace Garage { get; set; } = null!;

        public virtual ICollection<InvoicePackageDetail> InvoicePackageDetails { get; set; } = new List<InvoicePackageDetail>();

        public virtual ICollection<InvoiceServiceDetail> InvoiceServiceDetails { get; set; } = new List<InvoiceServiceDetail>();

        public virtual ICollection<InvoiceSellProduct> InvoiceSellProducts { get; set; } = new List<InvoiceSellProduct>();

        public virtual PackageUsage? PackageUsage { get; set; }
    }

}

