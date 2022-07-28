using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabysitterFy.Domain.DTO
{
    public class BabysitterDTO
    {
        public int ID { get; set; }

        public string? UserName { get; set; }

        public string? Email { get; set; }
        public string? Token { get; set; }

        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public int Price { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? WorkTime { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Phone { get; set; }
        public string? Gender { get; set; }

    }
}
