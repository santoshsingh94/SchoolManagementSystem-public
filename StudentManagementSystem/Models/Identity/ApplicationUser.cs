using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string City { get; set; }
        public string Image { get; set; }
    }
}
