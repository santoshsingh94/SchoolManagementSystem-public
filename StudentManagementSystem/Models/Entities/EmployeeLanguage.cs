using SchoolManagementSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models.Entities
{
    public class EmployeeLanguage
    {
        public int EmployeeLanguageId { get; set; }
        public string LanguageName { get; set; }
        public string Proficiency { get; set; }
        public int EmployeeResumeId { get; set; }
        public int UserId { get; set; }

        public EmployeeResume EmployeeResume { get; set; }
        public User User { get; set; }
    }
}
