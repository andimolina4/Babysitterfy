using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabysitterFy.Domain.DTO
{
    public class BabysitterRegisterDTO
    {
        [Required]
        public string Username { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, MinLength(8)]
        public string Password { get; set; }

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
