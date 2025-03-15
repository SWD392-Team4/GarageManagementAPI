namespace GarageManagementAPI.Shared.DataTransferObjects.Appointment
{
    public record AppointmentDtoForCancellation
    {
        public string? CancelledReason { get; init; }
    }
}
