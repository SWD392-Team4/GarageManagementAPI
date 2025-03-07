using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagementAPI.Shared.DataTransferObjects.CommunicationHub
{
    public class SignalRDto
    {
        public string? SenderId { get; set; }
        public string? ReceiverId { get; set; }
        public string? Message { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsRead { get; set; } = false;
    }
}
