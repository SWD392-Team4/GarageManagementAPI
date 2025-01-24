namespace GarageManagementAPI.Entities.Models
{
    public class FeedBackService : BaseEntity<FeedBackService>
    {
        public Guid CustomerId { get; set; }

        public Guid ServiceId { get; set; }

        public required string Status { get; set; }

        public required string Description { get; set; }

        public User? Customer { get; set; }

        public Service? Service { get; set; }
    }
}