namespace GarageManagementAPI.Entities.Models
{
    public class PackageUsage : BaseEntity<PackageUsage>
    {
        public Guid PackageHistoryId { get; set; }

        public Guid CustomerCarId { get; set; }

        public required string Status { get; set; }

        public int UsageCount { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public PackageHistory? PackageHistory { get; set; }

        public CustomerCar? CustomerCar { get; set; }

        ICollection<PackageUsageDetail>? PackageUsageDetails { get; set; }
    }
}