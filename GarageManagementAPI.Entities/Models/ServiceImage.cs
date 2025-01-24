namespace GarageManagementAPI.Entities.Models
{
    public class ServiceImage : BaseEntity<ServiceImage>
    {
        public required Guid ServiceId { get; set; }

        public required string Link { get; set; }

        public Service? Service { get; set; }
    }
}