using GarageManagementAPI.Shared.DataTransferObjects.User;

namespace GarageManagementAPI.Shared.DataTransferObjects.CommunicationHub
{
    public class SignalRDto
    {
        public UserDto SenderId { get; set; } = null!;
        public UserDto? ReceiverId { get; set; } = null!;
        public string? Message { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsRead { get; set; } = false;
    }
}
