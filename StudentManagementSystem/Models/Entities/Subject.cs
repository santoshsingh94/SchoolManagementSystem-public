using SchoolManagementSystem.Models.Entities;
using SchoolManagementSystem.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models.Entities
{
    public class Subject
    {
        public Subject()
        {
            this.ClassSubjects = new List<ClassSubject>();
        }
        public int SubjectId { get; set; }
        public string ApplicationUserId { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime RegDate { get; set; }
        public string Description { get; set; }
        public int TotalMarks { get; set; }
        public ICollection<ClassSubject> ClassSubjects { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
