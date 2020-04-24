using SchoolManagementSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models.Entities
{
    public class Attendance
    {
        public int AttendanceId { get; set; }
        public int SessionId { get; set; }
        //[ForeignKey("ClassTbl")]
        public int ClassTblId { get; set; }

        public int StudentId { get; set; }
       
        [DataType(DataType.Date)]
        public DateTime AttendanceDate { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan AttendanceTime { get; set; }

        public Student Student { get; set; }
        public Session Session { get; set; }
        public ClassTbl ClassTbl { get; set; }


    }
}
