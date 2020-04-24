using SchoolManagementSystem.Models.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Models.Entities
{
    public class EmployeeWorkExperience
    {
        public int EmployeeWorkExperienceId { get; set; }
        public string Company { get; set; }
        public string Title { get; set; }
        public string City { get; set; }        
        public string Country { get; set; }
        [DataType(DataType.Date)]
        public DateTime FromYear { get; set; }
        [DataType(DataType.Date)]
        public DateTime ToYear { get; set; }

        public string Description { get; set; }
        public int EmployeeResumeId { get; set; }
        public int UserId { get; set; }

        public EmployeeResume EmployeeResume { get; set; }
        public User User { get; set; }


    }
}