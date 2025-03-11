namespace GarageManagementAPI.Shared.DataTransferObjects.Appointment
{
    public record ProductInAppointmentDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }

}
