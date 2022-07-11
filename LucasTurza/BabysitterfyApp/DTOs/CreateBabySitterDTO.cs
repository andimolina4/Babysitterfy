﻿using BabysitterfyApp.Models;

namespace BabysitterfyApp.Dtos
{
    public class CreateBabySitterDTO
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public int Price { get; set; }
        public DateTime WorkTimeStart { get; set; }
        public DateTime WorkTimeEnd { get; set; }
    }
}
