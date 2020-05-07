using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models.Entities
{
    public class Gender
    {
        public int GenderId { get; set; }
        public string GenderType { get; set; }

        public ICollection<Student> Students { get; set; }
        public ICollection<Staff> Staffs { get; set; }
    }
}
