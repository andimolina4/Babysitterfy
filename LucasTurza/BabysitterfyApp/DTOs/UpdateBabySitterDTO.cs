using BabysitterfyApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BabysitterfyApp.Dtos
{
    public class UpdateBabySitterDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public int Price { get; set; }
        public string PhoneNumber { get; set; }
        public string? WorkTime { get; set; }
    }
}
