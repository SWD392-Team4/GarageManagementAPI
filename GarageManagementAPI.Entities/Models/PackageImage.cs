namespace GarageManagementAPI.Entities.Models
{
    public class PackageImage : BaseEntity<PackageImage>
    {
        public required Guid PackageId { get; set; }

        public required string Link { get; set; }

        public Package? Package { get; set; }
    }
}