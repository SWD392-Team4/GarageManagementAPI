using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Entities.Models
{
    public partial class PackageHistory : BaseEntity<PackageHistory>
    {
        public Guid PackageId { get; set; }

        public decimal PackagePrice { get; set; }

        public int ValidityPeriod { get; set; }

        [EnumDataType(typeof(TimeUnit))]
        public TimeUnit TimeUnit { get; set; }

        public int UsageLimit { get; set; }

        [EnumDataType(typeof(PackageHistoryStatus))]
        public PackageHistoryStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public virtual ICollection<AppointmentDetailPackage> AppointmentDetailPackages { get; set; } = new List<AppointmentDetailPackage>();

        public virtual ICollection<InvoicePackageDetail> InvoicePackageDetails { get; set; } = new List<InvoicePackageDetail>();

        public virtual Package Package { get; set; } = null!;

        public virtual ICollection<PackageDetail> PackageDetails { get; set; } = new List<PackageDetail>();

        public virtual ICollection<PackageUsage> PackageUsages { get; set; } = new List<PackageUsage>();
    }

}

