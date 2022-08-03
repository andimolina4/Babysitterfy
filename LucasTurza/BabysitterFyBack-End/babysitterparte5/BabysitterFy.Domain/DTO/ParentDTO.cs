using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabysitterFy.Domain.DTO
{
    public class ParentDTO
    {
        public int ID { get; set; }

        public string? UserName { get; set; }

        public string? Email { get; set; }
        public string? Token { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public int NumberOfChildren { get; set; }
        public string Address { get; set; }
        public string Province { get; set; }
    }
}
