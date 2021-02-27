using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiveMessanger.Models
{
    public class User
    { 
        public int Id { get; set; }
        [MaxLength(30)]
        public string Username { get; set; }
        [MaxLength(100)]
        public string Password { get; set; }
        public enum Roles
        {
            Student,
            Teacher,
            Editor,
            Admin
        }
        [Required]
        [Column(TypeName = "character varying(20)")]
        public Roles Role { get; set; }
        public Profile Profile { get; set; }
        public DateTime Created { get; set; }
        public ICollection<Chat> Chats { get; set; }
    }
}
