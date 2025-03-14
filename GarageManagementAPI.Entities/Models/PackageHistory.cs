using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Entities.Models
{
    public partial class PackageHistory : BaseEntity<PackageHistory>
    {
        public Guid PackageId { get; set; }

        [EnumDataType(typeof(ServiceCategory))]
        public ServiceCategory ServiceCategory { get; set; }

        public Guid CarCategoryId { get; set; }

        public string PackageName { get; set; } = null!;

        public string Description { get; set; } = null!;

        [EnumDataType(typeof(PackageType))]
        public PackageType Type { get; set; }

        public decimal PackagePrice { get; set; }

        public int ValidityPeriod { get; set; }

        [EnumDataType(typeof(TimeUnit))]
        public TimeUnit TimeUnit { get; set; }

        public int UsageLimit { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public virtual ICollection<AppointmentDetailPackage> AppointmentDetailPackages { get; set; } = new List<AppointmentDetailPackage>();

        public virtual ICollection<InvoicePackageDetail> InvoicePackageDetails { get; set; } = new List<InvoicePackageDetail>();

        public virtual CarCategory CarCategory { get; set; } = null!;

        public virtual Package Package { get; set; } = null!;

        public virtual ICollection<Service> Services { get; set; } = new List<Service>();

        public virtual ICollection<PackageUsage> PackageUsages { get; set; } = new List<PackageUsage>();

        public virtual ICollection<AppointmentDetail> AppointmentDetails { get; set; } = new List<AppointmentDetail>();
    }
}

