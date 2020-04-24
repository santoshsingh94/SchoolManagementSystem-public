using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models.Entities
{
    public class StaffAttendance
    {
        public int StaffAttendanceId { get; set; }
        public int StaffId { get; set; }
        [DataType(DataType.Date)]
        public DateTime AttendanceDate { get; set; }
        [DataType(DataType.Time)]
        public Nullable<TimeSpan> ComingTime { get; set; }
        [DataType(DataType.Time)]
        public Nullable<TimeSpan> ClosingTime { get; set; }

        public Staff Staff { get; set; }
    }
}
