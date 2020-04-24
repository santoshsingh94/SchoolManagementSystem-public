using SchoolManagementSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models.Entities
{
    public class EventTbl
    {
        public int EventTblId { get; set; }
        public string EventTitle { get; set; }
        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; }
        public string Location { get; set; }
        public string Description { get; set; } 
        public int UserId { get; set; }

        public User User { get; set; }
    }
}
