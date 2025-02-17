using GarageManagementAPI.Service.Contracts;
using GarageManagementAPI.Shared.DataTransferObjects.CommunicationHub;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using StackExchange.Redis;
using System.Collections.Concurrent;

namespace GarageManagementAPI.Service
{
    public class CommunicationHub : Hub, ICommunicationHub
    {
        private static readonly ConcurrentDictionary<string, string> _userConnections = new();
        private readonly IConnectionMultiplexer _redis;

        public CommunicationHub(IConnectionMultiplexer redis)
        {
            _redis = redis;
        }

        public override async Task OnConnectedAsync()
        {
            var userId = await GetOrCreateUserId();
            _userConnections.AddOrUpdate(userId, Context.ConnectionId, (_, _) => Context.ConnectionId);

            if (Context.User.Identity?.IsAuthenticated != true)
            {
                await Clients.Caller.SendAsync("ReceiveGuestId", userId);
            }

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var userId = await GetUserId();
            _userConnections.TryRemove(userId, out _);
            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string receiverId, string message)
        {
            var senderId = await GetUserId();
            var chatMessage = new SignalRDto
            {
                UserId = senderId,
                Message = message,
                Timestamp = DateTime.Now,
                IsRead = false
            };

            await SaveMessageToRedis(senderId, receiverId, chatMessage);
            await NotifyParticipants(senderId, receiverId, chatMessage);
        }

        public async Task<List<SignalRDto>> GetChatHistory(string partnerId)
        {
            var userId = await GetUserId();
            var chatRoomKey = GetChatRoomKey(userId, partnerId);

            var db = _redis.GetDatabase();
            var messages = await db.ListRangeAsync(chatRoomKey, 0, 50);

            return messages.Select(m =>
                JsonConvert.DeserializeObject<SignalRDto>(m.ToString())!
            ).ToList();
        }

        public async Task MarkMessageAsRead(string partnerId)
        {
            var userId = await GetUserId();
            var chatRoomKey = GetChatRoomKey(userId, partnerId);

            var db = _redis.GetDatabase();
            var messages = (await db.ListRangeAsync(chatRoomKey, 0, 50)).ToList();

            for (int i = 0; i < messages.Count; i++)
            {
                var msg = JsonConvert.DeserializeObject<SignalRDto>(messages[i].ToString()!);
                if (msg?.UserId == partnerId && !msg.IsRead)
                {
                    msg.IsRead = true;
                    await db.ListSetByIndexAsync(chatRoomKey, i, JsonConvert.SerializeObject(msg));
                    break;
                }
            }
        }

        private async Task<string> GetOrCreateUserId()
        {
            if (Context.User.Identity?.IsAuthenticated == true)
            {
                return Context.User.FindFirst("sub")?.Value!;
            }

            if (Context.Items.TryGetValue("GuestId", out var guestId))
            {
                return guestId?.ToString()!;
            }

            var newGuestId = Guid.NewGuid().ToString();
            Context.Items["GuestId"] = newGuestId;
            return newGuestId;
        }

        private async Task<string> GetUserId()
        {
            return Context.User.Identity?.IsAuthenticated == true
                ? Context.User.FindFirst("sub")?.Value!
                : Context.Items["GuestId"]?.ToString()!;
        }

        private async Task SaveMessageToRedis(string senderId, string receiverId, SignalRDto message)
        {
            var chatRoomKey = GetChatRoomKey(senderId, receiverId);
            var db = _redis.GetDatabase();

            await db.ListRightPushAsync(chatRoomKey, JsonConvert.SerializeObject(message));
            await db.KeyExpireAsync(chatRoomKey, TimeSpan.FromDays(30));
        }

        private async Task NotifyParticipants(string senderId, string receiverId, SignalRDto message)
        {
            var tasks = new List<Task>();

            if (_userConnections.TryGetValue(senderId, out var senderConnId))
            {
                tasks.Add(Clients.Client(senderConnId).SendAsync("ReceiveMessage", message));
            }

            if (_userConnections.TryGetValue(receiverId, out var receiverConnId))
            {
                tasks.Add(Clients.Client(receiverConnId).SendAsync("ReceiveMessage", message));
            }

            await Task.WhenAll(tasks);
        }

        private static string GetChatRoomKey(string user1, string user2)
        {
            var orderedIds = new[] { user1, user2 }.OrderBy(id => id).ToArray();
            return $"chat:{orderedIds[0]}:{orderedIds[1]}";
        }
    }
}