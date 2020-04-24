using SchoolManagementSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models.Entities
{
    public class EmployeeEducation
    {
        public int EmployeeEducationId { get; set; }
        public int EmployeeResumeId { get; set; }
        public int UserId { get; set; }
        public string Institute { get; set; }
        public string University { get; set; }
        public string TitleOfDiploma { get; set; }
        public string Degree { get; set; }
        [DataType(DataType.Date)]
        public DateTime FromYear { get; set; }
        [DataType(DataType.Date)]
        public DateTime ToYear { get; set; }
        public string InstituteCity { get; set; }
        public string InstituteCountry { get; set; }

        public EmployeeResume EmployeeResume { get; set; }
        //public User User { get; set; }
    }
}
