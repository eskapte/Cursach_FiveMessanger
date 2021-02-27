using System.Collections.Generic;

namespace FiveMessanger.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Icon { get; set; }
        public ICollection<User> Participants { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
