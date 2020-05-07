using SchoolManagementSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models.Master
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryType { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Staff> Staffs { get; set; }
    }
}
