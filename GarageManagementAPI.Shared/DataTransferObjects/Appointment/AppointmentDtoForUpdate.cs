namespace GarageManagementAPI.Shared.DataTransferObjects.Appointment
{
    public record class AppointmentDtoForUpdate : AppointmentDtoForManipulation
    {

    }

    public record class AppointmentDtoForConfirmation
    {
        public string? CanceledReason { get; set; } = "None";
    }
}
