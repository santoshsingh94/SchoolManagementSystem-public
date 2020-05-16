using SchoolManagementSystem.Models.Entities;
using SchoolManagementSystem.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models.Entities
{
    public class ProgrameSession
    {
        public ProgrameSession()
        {
            this.StudentPromotes = new List<StudentPromote>();
        }
        public int ProgrameSessionId { get; set; }
        public string ApplicationUserId { get; set; }
        public int SessionId { get; set; }
        public int ProgrameId { get; set; }
        public string Details { get; set; }
        [DataType(DataType.Date)]
        public DateTime RegDate { get; set; }
        public string Description { get; set; }

        public Programe Programe { get; set; }
        public Session Session { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        //public ICollection<ExamSetting> ExamSettings { get; set; }
        public ICollection<StudentPromote> StudentPromotes { get; set; }
    }
}
