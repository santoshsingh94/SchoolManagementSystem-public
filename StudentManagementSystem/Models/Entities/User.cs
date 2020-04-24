using SchoolManagementSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models.Entities
{
    public class User
    {
        public User()
        {
            this.Annuals = new List<Annual>();
            this.Designations = new List<Designation>();
            this.ExamMarks = new List<ExamMark>();
            this.Exams = new List<Exam>();
            this.ProgrameSessions = new List<ProgrameSession>();
            this.Programes = new List<Programe>();
            this.Sessions = new List<Session>();
            this.Staffs = new List<Staff>();
            this.Students = new List<Student>();
            this.Subjects = new List<Subject>();
            this.SubmissionFees = new List<SubmissionFee>();
            this.TimeTables = new List<TimeTable>();
            this.Sections = new List<Section>();
            this.EventTbls = new List<EventTbl>();
            this.Expenses = new List<Expense>();
        }


        public int UserId { get; set; }
        public int UserTypeId { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public ICollection<Annual> Annuals { get; set; }
        public ICollection<Designation> Designations { get; set; }
        public ICollection<ExamMark> ExamMarks { get; set; }
        public ICollection<Exam> Exams { get; set; }
        public ICollection<ProgrameSession> ProgrameSessions { get; set; }
        public ICollection<Programe> Programes { get; set; }
       public ICollection<Session> Sessions { get; set; }
        public ICollection<Staff> Staffs { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Subject> Subjects { get; set; }
        public ICollection<SubmissionFee> SubmissionFees { get; set; }
        public ICollection<TimeTable> TimeTables { get; set; }
        public ICollection<Section> Sections { get; set; }
        public ICollection<EmployeeSalary> EmployeeSalaries { get; set; }
        public ICollection<SchoolLeaving> SchoolLeavings { get; set; }
        public ICollection<EmployeeLeaving> EmployeeLeavings { get; set; }
        public ICollection<EmployeeLanguage> EmployeeLanguages { get; set; }
        public ICollection<EventTbl> EventTbls { get; set; }
        public ICollection<Expense> Expenses { get; set; }

        public UserType UserType { get; set; }

    }
}
