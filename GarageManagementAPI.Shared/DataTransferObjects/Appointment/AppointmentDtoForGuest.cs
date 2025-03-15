namespace GarageManagementAPI.Shared.DataTransferObjects.Appointment
{
    public record AppointmentDtoForGuest
    {
        public string? VerifyCode { get; init; }

        public string? CustomerEmail { get; init; }

        public string? CustomerPhoneNumber { get; init; }

        public DateTimeOffset? EstimatedTime { get; init; }
    }
}
