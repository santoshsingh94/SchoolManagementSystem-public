using SchoolManagementSystem.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models.Entities
{
    public class Designation
    {
        public int DesignationId { get; set; }
        public string ApplicationUserId { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Staff> Staffs { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
