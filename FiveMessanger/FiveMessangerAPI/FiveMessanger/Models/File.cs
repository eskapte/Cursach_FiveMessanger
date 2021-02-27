using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiveMessanger.Models
{
    public class File
    {
        public int Id { get; set; }
        public string Ref { get; set; }
        public int MessageId { get; set; }
        public Message Message { get; set; }
    }
}
