using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabysitterFy.Data.Models
{
    public class Parent : AppUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public int NumberOfChildren { get; set; }

    }
}
