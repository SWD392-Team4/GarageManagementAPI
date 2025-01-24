namespace GarageManagementAPI.Entities.Models
{
    public class FeedBackPackage : BaseEntity<FeedBackPackage>
    {
        public Guid CustomerId { get; set; }

        public Guid ServiceId { get; set; }

        public required string Status { get; set; }

        public required string Description { get; set; }

        public User? Customer { get; set; }

        public Package? Package { get; set; }
    }




}