using System.ComponentModel.DataAnnotations;

namespace FiveMessanger.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string? Icon { get; set; }
        public string? Number { get; set; }
        public string? Email { get; set; }
        [MaxLength(30)]
        public string? FirstName { get; set; }
        [MaxLength(30)]
        public string? SecondName { get; set; }
        [MaxLength(30)]
        public string? ThirdName { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
