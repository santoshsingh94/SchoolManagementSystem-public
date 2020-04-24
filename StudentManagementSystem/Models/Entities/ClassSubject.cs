using SchoolManagementSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models.Entities
{
    public class ClassSubject
    {
        public int ClassSubjectId { get; set; }
        public int ClassTblId { get; set; }
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public ClassTbl ClassTbl { get; set; }
        public Subject Subject { get; set; }
        public ICollection<ExamMark> ExamMarks { get; set; }
        public ICollection<TimeTable> TimeTables { get; set; }

    }
}
