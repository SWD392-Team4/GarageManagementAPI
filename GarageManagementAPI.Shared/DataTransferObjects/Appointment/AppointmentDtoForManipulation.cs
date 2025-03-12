namespace GarageManagementAPI.Shared.DataTransferObjects.Appointment
{
    public record AppointmentDtoForManipulation
    {
        public Guid? CarModelId { get; set; }

        public int? Mileage { get; set; }

        public string? CustomerName { get; set; }

        public string? CustomerPhoneNumber { get; set; }

        public string? CustomerEmail { get; set; }

        public DateTimeOffset EstimatedAppointmentTime { get; set; }

        public DateTimeOffset? EstimatedEndTime { get; set; }

        public string? CarLicensePlateNumber { get; set; }
    }
}
