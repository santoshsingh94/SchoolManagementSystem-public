using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models.Entities
{
    public class Designation
    {
        public int DesignationId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Staff> Staffs { get; set; }
        public virtual User User { get; set; }
    }
}
