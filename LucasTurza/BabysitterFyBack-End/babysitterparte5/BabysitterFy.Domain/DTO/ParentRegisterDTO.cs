using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabysitterFy.Domain.DTO
{
    public class ParentRegisterDTO
    {
        public string Username { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, MinLength(8)]
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public int NumberOfChildren { get; set; }
    }
}
