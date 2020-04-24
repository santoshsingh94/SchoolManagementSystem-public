using SchoolManagementSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models.Entities
{
    public class EmployeeSalary
    {
        public int EmployeeSalaryId { get; set; }
        public int UserId { get; set; }
        public int StaffId { get; set; }
        public float Amount { get; set; }
        public string SalaryMonth { get; set; }
        public string SalaryYear { get; set; }
        [DataType(DataType.Date)]
        public DateTime SalaryDate { get; set; }
        public string Comments { get; set; }

        public Staff Staff { get; set; }
        public User User { get; set; }
    }
}
