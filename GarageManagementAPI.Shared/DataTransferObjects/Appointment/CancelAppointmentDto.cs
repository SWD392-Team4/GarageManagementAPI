namespace GarageManagementAPI.Shared.DataTransferObjects.Appointment
{
    public record CancelAppointmentDto
    {
        public string? VerifyCode { get; init; }

        public string? CustomerEmail { get; init; }

        public string? CustomerPhoneNumber { get; init; }

        public DateTimeOffset? EstimatedTime { get; init; }
    }
}
