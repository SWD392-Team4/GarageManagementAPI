namespace GarageManagementAPI.Entities.Models
{
    public class PackageDetailHistory : BaseEntity<PackageDetailHistory>
    {
        public Guid PackageHistoryId { get; set; }

        public Guid ServiceId { get; set; }

        public PackageHistory? PackageHistory { get; set; }

        public Service? Service { get; set; }
    }
}