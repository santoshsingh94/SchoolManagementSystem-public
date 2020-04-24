using SchoolManagementSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models.Entities
{
    public class ClassTbl
    {
        public int ClassTblId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        
        public ICollection<StudentPromote> StudentPromotes { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<ClassSubject> ClassSubjects { get; set; }
        public ICollection<SubmissionFee> SubmissionFees { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
        public ICollection<SchoolLeaving> SchoolLeavings { get; set; }
    }
}
