namespace GarageManagementAPI.Entities.Models
{
    public class EmployeeSchedule : BaseEntity<EmployeeSchedule>
    {
        public required Guid UserId { get; set; }

        public required Guid AppointmentDetailId { get; set; }

        public DateTimeOffset? StartTime { get; set; }

        public required DateTimeOffset EstimatedEndTime { get; set; }

        public DateTimeOffset? ActualEndTime { get; set; }

        public required string Status { get; set; }

        public User? User { get; set; }

        public AppointmentDetail? AppointmentDetail { get; set; }
    }
}
