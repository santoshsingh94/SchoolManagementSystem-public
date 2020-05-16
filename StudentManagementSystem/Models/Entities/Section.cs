using SchoolManagementSystem.Models.Entities;
using SchoolManagementSystem.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models.Entities
{
    public class Section
    {
        public int SectionId { get; set; }
        public string Name { get; set; }
        public string ApplicationUserId { get; set; }


        public ApplicationUser ApplicationUser { get; set; }
        public ICollection<StudentPromote> StudentPromotes { get; set; }
    }
}
