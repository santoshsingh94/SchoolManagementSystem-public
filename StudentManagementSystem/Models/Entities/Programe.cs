using SchoolManagementSystem.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models.Entities
{
    public class Programe
    {
        public Programe()
        {
            this.Annuals = new List<Annual>();
            this.ProgrameSessions = new List<ProgrameSession>();
            //this.SessionProgrameSubjectSettings = new List<SessionProgrameSubjectSetting>();
            this.Students = new List<Student>();
            this.SubmissionFees = new List<SubmissionFee>();

        }
        [Key]
        public int ProgrameId { get; set; }
        public string ApplicationUserId { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Annual> Annuals { get; set; }
        public ICollection<ProgrameSession> ProgrameSessions { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<SubmissionFee> SubmissionFees { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
