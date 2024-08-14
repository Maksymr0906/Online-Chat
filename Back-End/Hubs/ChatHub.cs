using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using OnlineChat.Models.Dto.Message;
using OnlineChat.Services.Interface;

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
