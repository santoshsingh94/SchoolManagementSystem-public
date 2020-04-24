using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models.Entities
{
    public class Exam
    {
        public Exam()
        {
            this.ExamMarks = new List<ExamMark>();
        }

        public int ExamId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public ICollection<ExamMark> ExamMarks { get; set; }
       public User User { get; set; }
    }
}
