
using GarageManagementAPI.Shared.DataTransferObjects.CommunicationHub;

namespace GarageManagementAPI.Service.Contracts
{
    public interface ICommunicationHub
    {
        public Task OnConnectedAsync();

        public Task OnDisconnectedAsync(Exception? exception);

        public Task NewMessage(string receiverId, string message);
        public Task SendNotification(string receiverId, string message);
        public Task<List<SignalRDto>> GetNotifications();
        public Task<List<SignalRDto>> GetChatHistory(string partnerId);

        public Task MarkMessageAsRead(string partnerId);
        public Task MarkNotificationAsRead();
    }
}
