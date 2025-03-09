using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.CommunicationHub;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
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

            // 🧹 Xóa tất cả ConnectionId cũ để tránh lỗi "Invalid connection id"
            await db.KeyDeleteAsync($"connected_users:{userId}");

            // ✅ Lưu ConnectionId mới nhất vào Redis
            await db.SetAddAsync($"connected_users:{userId}", Context.ConnectionId);
            await db.KeyExpireAsync($"connected_users:{userId}", TimeSpan.FromHours(1)); // Set TTL để tránh lưu ConnectionId quá lâu


            await base.OnConnectedAsync();
        }


        public async Task SendMessage(string receiverId, string message)
        {
            var httpContext = Context.GetHttpContext();
            var token = httpContext.Request.Query["access_token"];
            string chatRoomKey;
            var db = _redis.GetDatabase();
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
            // Tạo chatRoomKey cho cuộc trò chuyện
            if (receiverId != null)
            {
                chatRoomKey = GetChatRoomKey(receiverId, senderId);

                // Kiểm tra loại dữ liệu của key
                var type = await db.KeyTypeAsync(chatRoomKey);

                if (type != RedisType.None && type != RedisType.List)
                {
                    await db.KeyDeleteAsync(chatRoomKey);
                }


                // Chuyển đối tượng thành chuỗi JSON
                string jsonMessage = JsonConvert.SerializeObject(chatMessage);

                // Lưu tin nhắn vào Redis (sử dụng List để lưu các tin nhắn)
                await db.ListRightPushAsync(chatRoomKey, jsonMessage);
                await db.KeyExpireAsync(chatRoomKey, TimeSpan.FromDays(30));
            }

            var receiverConnections = await db.SetMembersAsync($"connected_users:{receiverId}");
            Console.WriteLine("receiverConnections.Length: " + receiverConnections.Length);
            foreach (var connectionId in receiverConnections)
            {
                try
                {
                    // 🟢 Kiểm tra connectionId có còn trong Redis không
                    bool isValid = await db.SetContainsAsync($"connected_users:{receiverId}", connectionId);
                    if (!isValid)
                    {
                        Console.WriteLine($"❌ Invalid ConnectionId: {connectionId}. Removing from Redis.");
                        await db.SetRemoveAsync($"connected_users:{receiverId}", connectionId);
                        continue;
                    }
                    Console.WriteLine($"ConnectionId: {connectionId}");
                    // 🟢 Gửi tin nhắn nếu connectionId hợp lệ
                    await Clients.Client(connectionId).SendAsync("ReceiveMessage", message);
                    Console.WriteLine($"📩 Sent message to {connectionId}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"🚨 Failed to send message to {connectionId}: {ex.Message}");
                    await db.SetRemoveAsync($"connected_users:{receiverId}", connectionId);
                }
            }
        }
        public async Task<List<SignalRDto>> GetChatHistory(string receiverId)
        {
            var senderId = GetUserId();
            if (string.IsNullOrEmpty(senderId))
            {
                throw new UnauthorizedAccessException("User is not authenticated.");
            }

            string chatRoomKey = GetChatRoomKey(senderId, receiverId);
            var db = _redis.GetDatabase();

            bool chatRoomExists = await db.KeyExistsAsync(chatRoomKey);
            if (!chatRoomExists)
            {
                return new List<SignalRDto>();  // Trả về danh sách rỗng nếu không có tin nhắn
            }

            var chatHistoryJson = await db.ListRangeAsync(chatRoomKey, 0, 50);
            // Chuyển đổi từng tin nhắn từ dạng string sang đối tượng SignalRDto
            var chats = chatHistoryJson
                .Select(message => JsonConvert.DeserializeObject<SignalRDto>(message.ToString()))
                .ToList();
            return chats;
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var userId = GetUserId();
            if (!string.IsNullOrEmpty(userId))
            {
                var db = _redis.GetDatabase();
                await db.SetRemoveAsync($"connected_users:{userId}", Context.ConnectionId);
            }

            await base.OnDisconnectedAsync(exception);
        }

        public async Task Ping()
        {
            await Clients.Caller.SendAsync("Pong");
        }
        private string? GetUserId()
        {
            var userId = Context.User?.FindFirstValue("UserId");
            return userId;
        }

        private string GetChatRoomKey(string user1Id, string user2Id)
        {
            return $"{(user1Id.CompareTo(user2Id) < 0 ? user1Id : user2Id)}:{(user1Id.CompareTo(user2Id) > 0 ? user1Id : user2Id)}";
        }
    }
}
