using FiveMessanger.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiveMessanger.Controllers
{
    [EnableCors("reactPolicy")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly FiveMessangerContext _context;
        public ChatController(FiveMessangerContext context)
        {
            _context = context;
        }

        [HttpGet("/get_chats")]
        public async Task<IActionResult> GetChats([FromForm]string username)
        {
            User currentUser = await _context.Users.SingleOrDefaultAsync(u => u.Username == username);
            var chats = _context.Chats.Where(chat => chat.Participants.Contains(currentUser));
            return Ok(chats);
        }

        [HttpPost("/create_chat")]
        public async Task<IActionResult> CreateChat([FromForm]string username, [FromForm]string chatName)
        {
            bool isChatFind = await _context.Chats.AnyAsync(c => c.Name == chatName);
            if (isChatFind)
                return BadRequest(new { errorText = "Такой чат уже существует" });
            User creater = await _context.Users.SingleOrDefaultAsync(u => u.Username == username);
            if (creater == null)
                return BadRequest(new { errorText = "Пользователя не существует" });
            Chat newChat = new Chat { Name = chatName};
            newChat.Participants.Add(creater);
            await _context.Chats.AddAsync(newChat);
            await _context.SaveChangesAsync();
            return Ok(newChat);
        }
    }
}
