using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace FiveMessanger.Models
{
    public class Message
    {
        public int Id { get; set; }
        public User User { get; set; }
        [MaxLength(300)]
        public string? Content { get; set; }
        public Chat Chat { get; set; }
        public int ChatId { get; set; }
        public virtual ICollection<File> Files { get; set; }
        public DateTime Created { get; set; }
        public virtual ICollection<User> Readed { get; set; }

        public Message()
        {
            Files = new List<File>();
            Readed = new List<User>();
        }
    }
}
