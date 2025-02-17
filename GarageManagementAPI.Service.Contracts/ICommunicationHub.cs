
using GarageManagementAPI.Shared.DataTransferObjects.CommunicationHub;

namespace GarageManagementAPI.Service.Contracts
{
    public interface ICommunicationHub
    {
        public Task OnConnectedAsync();

        public Task OnDisconnectedAsync(Exception? exception);

        public Task SendMessage(string receiverId, string message);

        public Task<List<SignalRDto>> GetChatHistory(string partnerId);

        public Task MarkMessageAsRead(string partnerId);
    }
}
