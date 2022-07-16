﻿using BabysitterfyApp.Models;

namespace BabysitterfyApp.Dtos
{
    public class CreateBabySitterDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string? Image { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public int Price { get; set; }
        public string PhoneNumber { get; set; }
        public string? WorkTime { get; set; }
    }
}
