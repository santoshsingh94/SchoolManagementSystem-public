using SchoolManagementSystem.Models.Entities;
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
        public int UserId { get; set; }


        public User User { get; set; }
        public ICollection<StudentPromote> StudentPromotes { get; set; }
    }
}
