using System;
using System.Threading.Tasks;
using FiveMessanger.Clients;
using FiveMessanger.Models;
using Microsoft.AspNetCore.SignalR;

namespace FiveMessanger.Hubs
{
    public class ChatHub : Hub<IChatClient>
    {
        public async Task SendMessage(Message message)
        {
            await Clients.All.ReceiveMessage(message);
        }
    }
}
