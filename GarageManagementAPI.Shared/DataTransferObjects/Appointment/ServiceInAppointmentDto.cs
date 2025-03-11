namespace GarageManagementAPI.Shared.DataTransferObjects.Appointment
{
    public record ServiceInAppointmentDto
    {
        public Guid? ServiceId { get; set; }

        public ProductInAppointmentDto[]? Products { get; set; }
    }

}
