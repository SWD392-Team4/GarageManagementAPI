namespace GarageManagementAPI.Shared.DataTransferObjects.Appointment
{
    public record class AppointmentDtoForConfirmation
    {
        public DateTimeOffset? EstimatedAppointmentTime { get; set; }
    }
}
