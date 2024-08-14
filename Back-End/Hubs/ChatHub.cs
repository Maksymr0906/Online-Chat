using Microsoft.AspNetCore.SignalR;
using OnlineChat.Models.Dto.Message;

namespace OnlineChat.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(MessageDto message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
