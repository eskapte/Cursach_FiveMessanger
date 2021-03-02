using FiveMessanger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiveMessanger.Clients
{
    public interface IChatClient
    {
        Task ReceiveMessage(Message message);
    }
}
