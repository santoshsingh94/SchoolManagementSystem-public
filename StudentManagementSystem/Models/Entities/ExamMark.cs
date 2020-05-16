using SchoolManagementSystem.Models.Entities;
using SchoolManagementSystem.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models.Entities
{
    public class ExamMark
    {
        public int ExamMarkId { get; set; }
        public int ExamId { get; set; }
        public int ClassSubjectId{ get; set; }
        public int StudentId { get; set; }
        public string ApplicationUserId { get; set; }
        public int TotalMarks { get; set; }
        public int ObtainMarks { get; set; }

        public ClassSubject ClassSubject { get; set; }
        public Exam Exam { get; set; }
        public Student Student { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
 