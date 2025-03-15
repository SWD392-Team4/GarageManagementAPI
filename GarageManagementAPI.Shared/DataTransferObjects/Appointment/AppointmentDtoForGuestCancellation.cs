using GarageManagementAPI.Shared.Enums;

namespace GarageManagementAPI.Shared.DataTransferObjects.Appointment
{

    public record AppointmentDtoForGuestCancellation : AppointmentDtoForGuest
    {
        public string? CancelledReason { get; init; }
    }
}
