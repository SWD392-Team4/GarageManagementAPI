using GarageManagementAPI.Service;
using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.CommunicationHub;
using GarageManagementAPI.Entities.Models;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using StackExchange.Redis;
using System.Security.Claims;
using GarageManagementAPI.Repository.Contracts;
namespace api.Services
{
    public class CommunicationHub : Hub, ICommunicationHub
    {
        private readonly IConnectionMultiplexer _redis;
        private static Dictionary<string, string> _userConnections = new Dictionary<string, string>();
        private readonly IRepositoryManager _repoManager;

        public CommunicationHub(IConnectionMultiplexer redis, IRepositoryManager repoManager)
        {
            _redis = redis;
            _repoManager = repoManager;
        }

        public override async Task OnConnectedAsync()
        {
            var userId = GetUserId();
            Console.WriteLine(userId);
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
                return new List<SignalRDto>(); 
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
            var db = _redis.GetDatabase();
            string notificationKey = GetNotificationKey(receiver);
            var notification = new SignalRDto
            {
                UserId = senderId,
                Message = notificationMessage,
                Timestamp = DateTime.Now
            };
            string jsonNotification = JsonConvert.SerializeObject(notification);
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
            string notificationKey = GetNotificationKey(userId);
            bool notificationsExist = await db.KeyExistsAsync(notificationKey);
            if (!notificationsExist)
        {
                return new List<SignalRDto>(); 
            }

            var notificationsJson = await db.ListRangeAsync(notificationKey, 0, 50);

            var notifications = notificationsJson
                            .Select(message => JsonConvert.DeserializeObject<SignalRDto>(message.ToString()))
                            .ToList();
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
                    if (chatMessage!.UserId.ToString().Trim() != senderId.ToString().Trim() && chatMessage.IsRead == false)
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
            Console.WriteLine($"Client {Context.ConnectionId} connected");
            if (_userConnections.ContainsKey(userId))
        {
                _userConnections.Remove(userId);
            }
            return base.OnDisconnectedAsync(exception);
        }

        public async Task<List<User>> GetChattedUsersWithDetails()
        {
            var chattedUserIds = await GetChattedUsers();
            var users = new List<User>();
            foreach (var userId in chattedUserIds)
            {
                if (Guid.TryParse(userId, out var userGuid))
                {
                    var user = await _repoManager.User.GetUserByIdAsync(userGuid, trackChanges: false);
                    if (user != null)
                    {
                        users.Add(user);
                    }
                }
            }

            return users;
        }

        private async Task<List<string>> GetChattedUsers()
        {
            var userId = GetUserId();
            var db = _redis.GetDatabase();
            var server = _redis.GetServer(_redis.GetEndPoints().First());
            var keys = server.Keys(pattern: $"*:{userId}").Concat(server.Keys(pattern: $"{userId}:*")).ToList();

            var chattedUsers = new List<string>();

            foreach (var key in keys)
            {
                var parts = key.ToString().Split(':');
                if (parts.Length == 2)
                {
                    var otherUserId = parts[0] == userId ? parts[1] : parts[0];
                    if (!chattedUsers.Contains(otherUserId))
                    {
                        chattedUsers.Add(otherUserId);
                    }
                }
            }

            return chattedUsers;
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


        private string? GetUserId()
        {
            var userId = Context.User?.FindFirstValue("UserId"); 
            Console.WriteLine($"UserId: {userId}");
            Console.WriteLine($"UserName" + Context.User?.FindFirstValue("UserName"));
            return userId;
        }

    }
}