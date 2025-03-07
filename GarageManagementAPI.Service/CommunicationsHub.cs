using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.CommunicationHub;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using StackExchange.Redis;
using System.Security.Claims;

namespace GarageManagementAPI.Service
{
    public class CommunicationsHub : Hub
    {
        private readonly IConnectionMultiplexer _redis;
        private static Dictionary<string, string> _userConnections = new Dictionary<string, string>();
        private readonly IRepositoryManager _repoManager;

        public CommunicationsHub(IConnectionMultiplexer redis, IRepositoryManager repoManager)
        {
            _redis = redis;
            _repoManager = repoManager;
        }
        public override async Task OnConnectedAsync()
        {
            var userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                Context.Abort();
                return;
            }

            var db = _redis.GetDatabase();
            await db.SetAddAsync($"connected_users:{userId}", Context.ConnectionId);

            Console.WriteLine($"[SignalR] User {userId} connected with ConnectionId {Context.ConnectionId}");

            await base.OnConnectedAsync();
        }

        public async Task SendMessage(string receiverId, string message)
        {
            var httpContext = Context.GetHttpContext();
            var token = httpContext.Request.Query["access_token"];

            Console.WriteLine($"Received Token: {token}");
            var senderId = GetUserId();
            if (string.IsNullOrEmpty(senderId))
            {
                throw new HubException("Unauthorized");
            }

            var chatMessage = new SignalRDto
            {
                SenderId = senderId,
                ReceiverId = receiverId,
                Message = message,
                Timestamp = DateTime.UtcNow
            };

            // 🔹 Lưu tin nhắn vào database
           // await _repoManager.ChatMessage.CreateMessageAsync(chatMessage);
           // await _repoManager.SaveAsync();

            // 🔹 Kiểm tra user nhận có online không
            var db = _redis.GetDatabase();
            var receiverConnections = await db.SetMembersAsync($"connected_users:{receiverId}");

            if (receiverConnections.Length > 0)
            {
                foreach (var connectionId in receiverConnections)
                {
                    await Clients.Client(connectionId).SendAsync("ReceiveMessage", chatMessage);
                }
            }
        }
        private string? GetUserId()
        {
            var userId = Context.User?.FindFirstValue("UserId");
            Console.WriteLine($"UserName" + Context.User?.FindFirstValue("UserName"));
            Console.WriteLine($"UserId" + Context.User?.FindFirstValue("UserId"));
            return userId;
        }
    }
}
