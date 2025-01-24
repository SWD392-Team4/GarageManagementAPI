namespace GarageManagementAPI.Entities.Models
{
    public class PackageUsageDetail : BaseEntity<PackageUsageDetail>
    {
        public Guid PackageUsageId { get; set; }

        public Guid AppointmentId { get; set; }

        public required string Status { get; set; }

        public PackageUsage? PackageUsage { get; set; }

        public Appointment? Appointment { get; set; }
    }
}