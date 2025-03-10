using GarageManagementAPI.Shared.DataTransferObjects.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagementAPI.Shared.DataTransferObjects.CommunicationHub
{
    public class SignalRDto
    {
        public UserDto SenderId { get; set; } = null!;
        public UserDto ReceiverId { get; set; } = null!;
        public string? Message { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsRead { get; set; } = false;
    }
}
