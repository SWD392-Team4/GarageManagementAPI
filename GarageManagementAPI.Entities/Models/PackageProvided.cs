namespace GarageManagementAPI.Entities.Models
{
    public class PackageProvided : BaseEntity<PackageProvided>
    {
        public Guid PackageHistoryId { get; set; }

        public Guid AppointmentId { get; set; }

        public required string Status { get; set; }

        public PackageHistory? PackageHistory { get; set; }

        public Appointment? Appointment { get; set; }
    }
}