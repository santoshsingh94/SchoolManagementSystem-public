using Microsoft.AspNetCore.Identity;
using SchoolManagementSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Subjects = new List<Subject>();
        }
        public string City { get; set; }
        public string Image { get; set; }
        public ICollection<Subject> Subjects { get; set; }

    }
}
