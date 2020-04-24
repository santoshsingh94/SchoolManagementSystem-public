using SchoolManagementSystem.Models.Entities;
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
           //this.TimeTables = new List<TimeTable>();
        }
        [Required]
        public int SubjectId { get; set; }
        [Required]
        public int UserId { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime RegDate { get; set; }
        public string Description { get; set; }
        public int TotalMarks { get; set; }

        //public ICollection<TimeTable> TimeTables { get; set; }
        public ICollection<ClassSubject> ClassSubjects { get; set; }
        public User User { get; set; }
    }
}
