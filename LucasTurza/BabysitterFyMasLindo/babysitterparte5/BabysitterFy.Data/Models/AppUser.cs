﻿
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabysitterFy.Data.Models
{
    public class AppUser : IdentityUser<int>
    {
        public IEnumerable<AppUserRole> UserRoles { get; set; }
    }
}
