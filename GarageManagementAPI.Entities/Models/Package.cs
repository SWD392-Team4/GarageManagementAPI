namespace GarageManagementAPI.Entities.Models
{
    public class Package : BaseEntity<Package>
    {
        public required string ServiceCategory { get; set; }

        public required string Name { get; set; }

        public required string Description { get; set; }

        public ICollection<FeedBackPackage>? FeedBacks { get; set; }

        public ICollection<PackageImage>? PackageImages { get; set; }

        public ICollection<PackageHistory>? PackageHistories { get; set; }

        public ICollection<MaintainCondition>? MaintainConditions { get; set; }

        public ICollection<PackageDetail>? PackageDetails { get; set; }
    }
}