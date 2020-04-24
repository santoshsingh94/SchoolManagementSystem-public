using SchoolManagementSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models.Entities
{
    public class EmployeeLeaving
    {
        public int EmployeeLeavingId { get; set; }
        public int UserId { get; set; }
        public int StaffId { get; set; }
        [DataType(DataType.Date)]
        public DateTime LeavingDate { get; set; }
        [DataType(DataType.Date)]
        public string LeavingReason { get; set; }
        public string LeavingComments { get; set; }
        public DateTime CreatedDate { get; set; }

        public User User { get; set; }
        public Staff Staff { get; set; }
    }
}
