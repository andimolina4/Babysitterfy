﻿using System;
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
        public string PhoneNumber { get; set; }
        public int NumberOfChildren { get; set; }
        public string Address { get; set; }
        public string Province { get; set; }
        public int GetAge()
        {
            var age = DateTime.Today.Year - DateOfBirth.Year;

            if (DateOfBirth.Date > DateTime.Today.AddYears(-age)) age--;

            return age;
        }
    }
}
