using System.Collections.Generic;

namespace FiveMessanger.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Icon { get; set; }
        public virtual ICollection<User> Participants { get; set; }
        public virtual ICollection<Message> Messages { get; set; }

        public Chat()
        {
            Participants = new List<User>();
            Messages = new List<Message>();
        }
    }
}
