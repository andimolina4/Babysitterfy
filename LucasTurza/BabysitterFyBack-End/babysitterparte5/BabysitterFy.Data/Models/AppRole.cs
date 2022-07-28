using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BabysitterFy.Data.Models
{
    public class AppRole : IdentityRole<int>
    {
        public IEnumerable<AppUserRole> UserRoles { get; set; }
    }
}
