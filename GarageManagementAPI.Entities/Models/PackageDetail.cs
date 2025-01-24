namespace GarageManagementAPI.Entities.Models
{
    public class PackageDetail : BaseEntity<PackageDetail>
    {
        public Guid PackageId { get; set; }

        public Guid ServiceId { get; set; }

        public Package? Package { get; set; }

        public Service? Service { get; set; }
    }
}