using SchoolManagementSystem.Models.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Models.Entities
{
    public class EmployeeResume
    {
        public int EmployeeResumeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string EducationLevel { get; set; }
        public string Address { get; set; }
        public string  Contact { get; set; }
        public string Email { get; set; }
        public string Summary { get; set; }
        public string LinkedInProfile { get; set; }
        public string FacebookProfile { get; set; }

        public ICollection<EmployeeCertification> EmployeeCertifications { get; set; }
        public ICollection<EmployeeEducation> EmployeeEducations { get; set; }
        public ICollection<EmployeeLanguage> EmployeeLanguages { get; set; }
        public ICollection<EmployeeSkill> EmployeeSkills { get; set; }
        public ICollection<EmployeeWorkExperience> EmployeeWorkExperiences { get; set; }


    }
}