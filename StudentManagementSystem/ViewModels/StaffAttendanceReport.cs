using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.ViewModels
{
    public class StaffAttendanceReport
    {
        public int StaffAttendanceId { get; set; }
        public string Designation { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime AttendanceDate { get; set; }
        [DataType(DataType.Time)]
        public Nullable<TimeSpan> ComingTime { get; set; }
        [DataType(DataType.Time)]
        public Nullable<TimeSpan> ClosingTime { get; set; }
        public TimeSpan DutyHour { get; set; }
    }
}
