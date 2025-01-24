namespace GarageManagementAPI.Entities.Models
{
    public class Service : BaseEntity<Service>
    {
        public Guid CarPartId { get; set; }

        public required string Name { get; set; }

        public required string ServiceCategory { get; set; }

        public required string WorkNature { get; set; }

        public required string Action { get; set; }

        public required string Status { get; set; }

        public required string Description { get; set; }

        public int EstimatedTime { get; set; } //hours

        public CarPart? CarPart { get; set; }

        public ICollection<FeedBackService>? FeedBacks { get; set; }

        public ICollection<ServiceImage>? ServiceImages { get; set; }

        public ICollection<ServiceHistory>? ServiceHistories { get; set; }

        public ICollection<PackageDetail>? PackageDetails { get; set; }
    }
}