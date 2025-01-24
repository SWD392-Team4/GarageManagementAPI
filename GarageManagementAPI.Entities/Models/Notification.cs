namespace GarageManagementAPI.Entities.Models
{
    public class Notification : BaseEntity<Notification>
    {
        public Guid ReceiverId { get; set; }

        public required string Description { get; set; }

        public bool IsSeen { get; set; }

        public required string NotificationType { get; set; }

        public User? User { get; set; }
    }




}