using Newtonsoft.Json;
using StackExchange.Redis;
using System.Security.Claims;
using Microsoft.AspNetCore.SignalR;
using GarageManagementAPI.Shared.DataTransferObjects.CommunicationHub;
using MimeKit;
using GarageManagementAPI.Entities.Models;

namespace api.Services
{
    public class CommunicationHub : Hub
    {
        private readonly IConnectionMultiplexer _redis;
        private static Dictionary<string, string> _userConnections = new Dictionary<string, string>();

        public CommunicationHub(IConnectionMultiplexer redis)
        {
            _redis = redis;
        }

        // Khi người dùng kết nối, lưu Connection ID của họ
        public override Task OnConnectedAsync()
        {
            var userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException("User is not authenticated.");
            }
            if (userId != null && Context != null && !_userConnections.ContainsKey(userId))
            {
                _userConnections.Add(userId, Context.ConnectionId);
            }

            return base.OnConnectedAsync();
        }
        public async Task NewMessage(string receiverId, string message)
        {
            var senderId = GetUserId();
            if (string.IsNullOrEmpty(senderId))
            {
                throw new UnauthorizedAccessException("User is not authenticated.");
            }
            string chatRoomKey;
            // Tạo đối tượng tin nhắn
            var chatMessage = new SignalRDto
            {
                UserId = senderId,
                Message = message,
                Timestamp = DateTime.Now
            };
            // Tạo chatRoomKey cho cuộc trò chuyện
            if (senderId != null)
            {
                chatRoomKey = GetChatRoomKey(senderId, receiverId);
                // Lấy database Redis
                var db = _redis.GetDatabase();

                // Kiểm tra loại dữ liệu của key
                var type = await db.KeyTypeAsync(chatRoomKey);

                // Nếu key không phải là List, xóa key cũ để tránh lỗi
                if (type != RedisType.List)
                {
                    await db.KeyDeleteAsync(chatRoomKey);
                }

                // Chuyển đối tượng thành chuỗi JSON
                string jsonMessage = JsonConvert.SerializeObject(chatMessage);

                // Lưu tin nhắn vào Redis (sử dụng List để lưu các tin nhắn)
                await db.ListRightPushAsync(chatRoomKey, jsonMessage);
            }

            if (senderId != null && _userConnections.ContainsKey(receiverId))
            {
                // Lấy Connection ID của người gửi 
                var senderConnectionId = _userConnections[senderId];
                // Gửi tin nhắn tới người gửi 
                await Clients.Client(senderConnectionId).SendAsync("receiveMessage", chatMessage);

            }
            if (senderId != null && _userConnections.ContainsKey(senderId))
            {
                // Lấy Connection ID của người nhận
                var receiverConnectionId = _userConnections[senderId];
                // Gửi tin nhắn tới người nhận 
                await Clients.Client(receiverConnectionId).SendAsync("receiveMessage", chatMessage);
            }

            //Gửi tin nhắn tới tất cả client của hai người nếu 2 người đnag online
            await Clients.User(senderId!.ToString()).SendAsync("messageReceived", chatMessage);
            await Clients.User(receiverId.ToString()).SendAsync("messageReceived", chatMessage);
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
            return chats!;
        }

        // Phương thức gửi thông báo cho người dùng
        public async Task SendNotification(string userId, string notificationMessage)
        {
            // Lấy Redis database
            var db = _redis.GetDatabase();
            // Tạo key cho thông báo của người dùng
            string notificationKey = GetNotificationKey(userId);
            // Tạo đối tượng thông báo
            var notification = new SignalRDto
            {
                UserId = userId,
                Message = notificationMessage,
                Timestamp = DateTime.Now
            };
            string jsonNotification = JsonConvert.SerializeObject(notification);
            // Lưu thông báo vào Redis
            await db.ListRightPushAsync(notificationKey, jsonNotification);
            if (_userConnections.ContainsKey(userId))
            {
                var connectionId = _userConnections[userId];
                await Clients.Client(connectionId).SendAsync("receiveNotification", notificationMessage);
            }
        }

        public async Task<List<SignalRDto>> GetNotifications(string userId)
        {
            var db = _redis.GetDatabase();
            // Lấy key của thông báo
            string notificationKey = GetNotificationKey(userId);
            // Kiểm tra xem có thông báo nào không
            bool notificationsExist = await db.KeyExistsAsync(notificationKey);
            if (!notificationsExist)
            {
                return new List<SignalRDto>();  // Trả về danh sách rỗng nếu không có thông báo
            }

            // Lấy tất cả thông báo từ Redis (tối đa 50 thông báo gần nhất)
            var notificationsJson = await db.ListRangeAsync(notificationKey, 0, 50);

            var notifications = notificationsJson
                            .Select(message => JsonConvert.DeserializeObject<SignalRDto>(message.ToString()))
                            .ToList();
            // Chuyển đổi thông báo từ Redis thành danh sách chuỗi
            return notifications!;
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var userId = GetUserId();
            if (_userConnections.ContainsKey(userId))
            {
                _userConnections.Remove(userId);
            }
            return base.OnDisconnectedAsync(exception);
        }

        // Hàm tạo key cho cuộc trò chuyện giữa hai người
        private string GetChatRoomKey(string user1Id, string user2Id)
        {
            return $"{(user1Id.CompareTo(user2Id) < 0 ? user1Id : user2Id)}:{(user1Id.CompareTo(user2Id) > 0 ? user1Id : user2Id)}";
        }
        private string GetNotificationKey(string userId)
        {
            return $"notifications:{userId}";
        }


        private string GetUserId()
        {
            Console.WriteLine("UserId" + Context.User.FindFirstValue("UserId"));
            return Context.User.FindFirstValue("UserId")!;
        }
    }
}
