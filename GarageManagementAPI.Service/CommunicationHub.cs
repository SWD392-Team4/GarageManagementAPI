using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.CommunicationHub;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using StackExchange.Redis;
using System.Security.Claims;


namespace api.Services
{
    public class CommunicationHub : Hub, ICommunicationHub
    {
        private readonly IConnectionMultiplexer _redis;
        private static Dictionary<string, string> _userConnections = new Dictionary<string, string>();

        public CommunicationHub(IConnectionMultiplexer redis)
        {
            _redis = redis;
        }

        // Khi người dùng kết nối, lưu Connection ID của họ
        public override async Task OnConnectedAsync()
        {
            var userId = GetUserId();

            if (string.IsNullOrEmpty(userId))
            {
                Context.Abort();
                throw new HubException("Unauthorized: JWT is missing or expired.");
            }

            _userConnections[userId] = Context.ConnectionId;

            await base.OnConnectedAsync();
        }


        public async Task NewMessage(string receiverId, string message)
        {
            var senderId = GetUserId();

            string chatRoomKey = GetChatRoomKey(senderId, receiverId);

            // Lấy database Redis
            var db = _redis.GetDatabase();
            var type = await db.KeyTypeAsync(chatRoomKey);

            // Nếu key tồn tại nhưng không phải List, xóa để tránh lỗi
            if (type != RedisType.None && type != RedisType.List)
            {
                await db.KeyDeleteAsync(chatRoomKey);
            }

            // Tạo đối tượng tin nhắn
            var chatMessage = new SignalRDto
            {
                UserId = senderId,
                Message = message,
                Timestamp = DateTime.Now
            };

            // Lưu tin nhắn vào Redis
            string jsonMessage = JsonConvert.SerializeObject(chatMessage);
            await db.ListRightPushAsync(chatRoomKey, jsonMessage);
            // Gửi tin nhắn nếu user đang online
            if (_userConnections.ContainsKey(receiverId))
            {
                var receiverConnectionId = _userConnections[receiverId];
                await Clients.Client(receiverConnectionId).SendAsync("receiveMessage", chatMessage);
            }
            if (_userConnections.ContainsKey(senderId))
            {
                var senderConnectionId = _userConnections[senderId];
                await Clients.Client(senderConnectionId).SendAsync("receiveMessage", chatMessage);
            }

            // Gửi tin nhắn tới tất cả thiết bị của user (nếu họ có nhiều kết nối)
            /*await Clients.User(senderId).SendAsync("messageReceived", chatMessage);
            await Clients.User(receiverId).SendAsync("messageReceived", chatMessage);*/
        }

        public async Task<List<SignalRDto>> GetChatHistory(string receiverId)
        {
            var senderId = GetUserId();

            string chatRoomKey = GetChatRoomKey(senderId, receiverId);
            var db = _redis.GetDatabase();
            var messages = await db.ListRangeAsync(chatRoomKey, 0, 50);

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
        public async Task SendNotification(string receiver, string notificationMessage)
        {
            var senderId = GetUserId();
            // Lấy Redis database
            var db = _redis.GetDatabase();
            // Tạo key cho thông báo của người dùng
            string notificationKey = GetNotificationKey(receiver);
            // Tạo đối tượng thông báo
            var notification = new SignalRDto
            {
                UserId = senderId,
                Message = notificationMessage,
                Timestamp = DateTime.Now
            };
            string jsonNotification = JsonConvert.SerializeObject(notification);
            // Lưu thông báo vào Redis
            await db.ListRightPushAsync(notificationKey, jsonNotification);
            if (_userConnections.ContainsKey(receiver))
            {
                var connectionId = _userConnections[receiver];
                await Clients.Client(connectionId).SendAsync("receiveNotification", notification);
            }
            await Clients.User(receiver!.ToString()).SendAsync("receiveNotification", notification);
        }

        public async Task<List<SignalRDto>> GetNotifications()
        {
            var userId = GetUserId();
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

        public async Task MarkNotificationAsRead()
        {
            var userId = GetUserId();
            var db = _redis.GetDatabase();

            string notificationKey = GetNotificationKey(userId);

            var notificationsJson = await db.ListRangeAsync(notificationKey, 0, -1);

            foreach (var noti in notificationsJson)
            {
                var notification = JsonConvert.DeserializeObject<dynamic>(noti.ToString());
                if (notification!.IsRead == false)
                {
                    notification.IsRead = true;

                    await db.ListSetByIndexAsync(notificationKey, notificationsJson.ToList().IndexOf(noti), JsonConvert.SerializeObject(notification));
                    break;
                }
            }
        }

        public async Task MarkMessageAsRead(string receiverId)
        {
            var senderId = GetUserId();
            if (string.IsNullOrEmpty(senderId) || string.IsNullOrEmpty(receiverId))
            {
                throw new ArgumentException("Invalid sender or receiver ID.");
            }

            string chatRoomKey = GetChatRoomKey(senderId, receiverId);
            var db = _redis.GetDatabase();

            var chatHistoryJson = await db.ListRangeAsync(chatRoomKey, 0, -1);
            if (chatHistoryJson == null || chatHistoryJson.Length == 0)
            {
                return;
            }

            var updatedMessages = new List<string>();

            foreach (var msg in chatHistoryJson)
            {
                try
                {
                    var chatMessage = JsonConvert.DeserializeObject<dynamic>(msg.ToString());
                    if (chatMessage.UserId.ToString().Trim() != senderId.ToString().Trim() && chatMessage.IsRead == false)
                    {
                        chatMessage.isRead = true;
                    }

                    updatedMessages.Add(JsonConvert.SerializeObject(chatMessage));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing message: {ex.Message}");
                }
            }

            await db.KeyDeleteAsync(chatRoomKey);
            await db.ListRightPushAsync(chatRoomKey, updatedMessages.Select(msg => (RedisValue)msg).ToArray());
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
            var userId = Context.User.FindFirstValue("UserId")!;
            return userId;
        }
    }
}
