using Microsoft.AspNetCore.Identity;
using SchoolManagementSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Subjects = new List<Subject>();
            this.Sessions = new List<Session>();
            this.Annuals = new List<Annual>();
            this.Staffs = new List<Staff>();
            this.Sections = new List<Section>();
            this.Expenses = new List<Expense>();
            this.ExamMarks = new List<ExamMark>();
            this.Programes = new List<Programe>();
            this.ProgrameSessions = new List<ProgrameSession>();
            this.Students = new List<Student>();
        }
        public string City { get; set; }
        public string Image { get; set; }
        public ICollection<Subject> Subjects { get; set; }
        public ICollection<Session> Sessions { get; set; }
        public ICollection<Annual> Annuals { get; set; }
        public ICollection<Staff> Staffs { get; set; }
        public ICollection<Section> Sections { get; set; }
        public ICollection<Expense> Expenses { get; set; }
        public ICollection<ExamMark> ExamMarks { get; set; }
        public ICollection<Programe> Programes { get; set; }
        public ICollection<ProgrameSession> ProgrameSessions { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<TimeTable> TimeTables { get; set; }

    }
}
