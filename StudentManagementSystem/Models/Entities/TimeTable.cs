using SchoolManagementSystem.Models.Entities;
using SchoolManagementSystem.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models.Entities
{
    public class TimeTable
    {
        public int TimeTableId { get; set; }
        public string ApplicationUserId { get; set; }
        //public int SubjectId { get; set; }

        public int StaffId { get; set; }
        public int ClassSubjectId { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan StartTime { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan EndTime { get; set; }
        public string Day { get; set; }

        public bool IsActive { get; set; }
        
       // public Subject Subject { get; set; }
        public ClassSubject ClassSubject { get; set; }
        public Staff Staff { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
