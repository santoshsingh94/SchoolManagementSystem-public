using SchoolManagementSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models.Entities
{
    public class SchoolLeaving
    {
        public int SchoolLeavingId { get; set; }
        public int UserId { get; set; }
        public int StudentId { get; set; }
        public int ClassTblId { get; set; }
        [DataType(DataType.Date)]
        public DateTime LeavingDate { get; set; }
        public string LeavingReason { get; set; }
        public string LeavingComments { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        public User User { get; set; }
        public Student Student { get; set; }
        public ClassTbl ClassTbl { get; set; }
    }
}
