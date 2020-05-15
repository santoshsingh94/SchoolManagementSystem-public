using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Models.Entities;
using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Models
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public bool SaveChanges()
        {
            var tr = _context.SaveChanges();
            return (tr) > 0;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        //public void Update<T>(T record) where T:class
        //{
        //    _context.Set<T>().Attach(record);
        //    //_context.Entry(record).State = EntityState.Modified;

        //}
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public List<Student> GetAllStudentAsync()
        {
            var query = _context.Students.ToList();
            return query;
        }

        public List<User> GetAllUserAsync()
        {
            var query = _context.Users.ToList();
            return query;
        }
      public List<UserType> GetAllUserTypeAsync()
        {
            var query = _context.UserTypes.ToList();
            return query;
        }

        public Student GetStudentAsync(int id)
        {
            Student query = _context.Students.Find(id);
            return query;
        }

        public User GetUserAsync(int id)
        {
            User query = _context.Users.Find(id);
            return query;
        }

        public UserType GetUserTypeAsync(int id)
        {
            UserType query = _context.UserTypes.Find(id);
            return query;
        }

        

        public void UpdateStudent(Student oldStudent, Student newStudent)
        {
            oldStudent.Name = newStudent.Name;
            oldStudent.Email = newStudent.Email;
        }

        public void UpdateUser(User oldUser, User newUser)
        {
            oldUser.FullName = newUser.FullName;
            oldUser.UserName = newUser.UserName;
            oldUser.Password = newUser.Password;
            oldUser.ContactNo = newUser.ContactNo;
            oldUser.Email = newUser.Email;
            oldUser.Address = newUser.Address;
        }

        public void UpdateUserType(UserType oldUserType, UserType newUserType)
        {
            oldUserType.TypeName = newUserType.TypeName;
            oldUserType.Description = newUserType.Description;
        }
        //Annual
        public List<Annual> GetAllAnnualAsync()
        {
            return _context.Annuals.ToList();
        }

        public Annual GetAnnualAsync(int id)
        {
            return _context.Annuals.FirstOrDefault(a=>a.AnnualId==id);
        }

        public void UpdateAnnual(Annual entity, Annual model)
        {
            entity.UserId = model.UserId;
            entity.ProgrameId = model.ProgrameId;
            entity.Title = model.Title;
            entity.Description = model.Description;
            entity.Fees = model.Fees;
            entity.IsActive = model.IsActive;
        }
        //Attendance
        public List<Attendance> GetAllAttendanceAsync()
        {
            return _context.Attendances.ToList();
        }

        public Attendance GetAttendanceAsync(int id)
        {
            return _context.Attendances.FirstOrDefault(a => a.AttendanceId == id);
        }

        public void UpdateAttendance(Attendance entity, Attendance model)
        {
            entity.SessionId = model.SessionId;
            entity.StudentId = model.StudentId;
            entity.AttendanceDate = model.AttendanceDate;
            entity.AttendanceTime = model.AttendanceTime;
        }
        //Designation
        public List<Designation> GetAllDesignationAsync()
        {
            return _context.Designations.ToList();
        }
        public Designation GetDesignationAsync(int id)
        {
            return _context.Designations.FirstOrDefault(d => d.DesignationId == id);
        }
        public void UpdateDesignation(Designation entity, Designation model)
        {
            entity.UserId = model.UserId;
            entity.Title = model.Title;
            entity.IsActive = model.IsActive;
        }
        //Exam
        public List<Exam> GetAllExamAsync()
        {
            return _context.Exams.ToList();
        }

        public Exam GetExamAsync(int id)
        {
            return _context.Exams.FirstOrDefault(e => e.ExamId == id);
        }

        public void UpdateExam(Exam entity, Exam model)
        {
            entity.UserId = model.ExamId;
            entity.Title = model.Title;
            entity.StartDate = model.StartDate;
            entity.EndDate = model.EndDate;
            entity.Description = model.Description;
        }
        //ExamMarks
        public List<ExamMark> GetAllExamMarksAsync()
        {
            return _context.ExamMarks.ToList();
        }

        public ExamMark GetExamMarksAsync(int id)
        {
            return _context.ExamMarks.FirstOrDefault(e => e.ExamId == id);
        }

        public void UpdateExamMarks(ExamMark entity, ExamMark model)
        {            
            entity.ExamId = model.ExamId;
            entity.ClassSubjectId = model.ClassSubjectId;
            entity.StudentId = model.StudentId;
            entity.UserId = model.UserId;
            entity.TotalMarks = model.TotalMarks;
            entity.ObtainMarks = model.ObtainMarks;
        }

       
        public List<Programe> GetProgrameAsync()
        {
            return _context.Programes.ToList();
        }

        public Programe GetProgrameAsync(int id)
        {
            return _context.Programes.FirstOrDefault(e => e.ProgrameId == id);
        }

        public void UpdatePrograme(Programe entity, Programe model)
        {
            entity.UserId = model.UserId;
            entity.Name = model.Name;
            entity.StartDate = model.StartDate;
            entity.IsActive = model.IsActive;
        }

        public List<Session> GetAllSessionAsync()
        {
            return _context.Sessions.ToList();
        }

        public Session GetSessionAsync(int id)
        {
            return _context.Sessions.FirstOrDefault(e => e.SessionId == id);
        }

        public void UpdateSession(Session entity, Session model)
        {
            entity.UserId = model.UserId;
            entity.Name = model.Name;
            entity.StartDate = model.StartDate;
            entity.EndDate = model.EndDate;
        }

        public List<ProgrameSession> GetAllProgrameSessionAsync()
        {
            return _context.ProgrameSessions.ToList();
        }

        public ProgrameSession GetProgrameSessionAsync(int id)
        {
            return _context.ProgrameSessions.FirstOrDefault(p => p.ProgrameSessionId == id);
        }

        public void UpdateProgrameSession(ProgrameSession entity, ProgrameSession model)
        {
            entity.UserId = model.UserId;
            entity.SessionId = model.SessionId;
            entity.ProgrameId = model.ProgrameId;
            entity.Details = model.Details;
            entity.RegDate = model.RegDate;
            entity.Description = model.Description;
        }       

        public List<StaffAttendance> GetAllStaffAttendanceAsync()
        {
            return _context.StaffAttendances.ToList();
        }

        public StaffAttendance GetStaffAttendanceAsync(int id)
        {
            return _context.StaffAttendances.FirstOrDefault(s => s.StaffAttendanceId == id);
        }

        public void UpdateStaffAttendance(StaffAttendance entity, StaffAttendance model)
        {
            entity.StaffId = model.StaffId;
            entity.AttendanceDate = model.AttendanceDate;
            entity.ComingTime = model.ComingTime;
            entity.ClosingTime = model.ClosingTime;
        }

        public List<Staff> GetAllStaffAsync()
        {
            return _context.Staffs.ToList();
        }

        public Staff GetStaffAsync(int id)
        {
            return _context.Staffs.FirstOrDefault(s => s.StaffId == id);
        }

        public void UpdateStaff(Staff entity, Staff model)
        {
            entity.UserId = model.UserId;
            entity.Name = model.Name;
            entity.DesignationId = model.DesignationId;
            entity.ContactNo = model.ContactNo;
            entity.BasicSalary = model.BasicSalary;
            entity.Email = model.Email;
            entity.Address = model.Address;
            entity.Qualification = model.Qualification;
            entity.photo = model.photo;
            entity.Description = model.Description;
            entity.IsActive = model.IsActive;
        }
        public List<Subject> GetAllSubjectAsync()
        {
            return _context.Subjects.ToList();
        }

        public Subject GetSubjectAsync(int id)
        {
            return _context.Subjects.FirstOrDefault(s => s.SubjectId == id);
        }

        public void UpdateSubject(Subject entity, Subject model)
        {
            //entity.UserId = model.UserId;
            entity.Name = model.Name;
            entity.RegDate = model.RegDate;
            entity.Description = model.Description;
            entity.TotalMarks = model.TotalMarks;
        }

        public List<TimeTable> GetAllTimeTableAsync()
        {
            return _context.TimeTables.ToList();
        }

        public TimeTable GetTimeTableAsync(int id)
        {
            return _context.TimeTables.FirstOrDefault(t => t.TimeTableId == id);
        }

        public void UpdateTimeTable(TimeTable entity, TimeTable model)
        {
            entity.UserId = model.UserId;
            entity.StartTime= model.StartTime;
            entity.EndTime = model.EndTime;
            entity.Day = model.Day;
            entity.IsActive = model.IsActive;
        }

        public List<SubmissionFee> GetAllSubmissionFeeAsync()
        {
            return _context.SubmissionFees.ToList();
        }

        public SubmissionFee GetSubmissionFeeAsync(int id)
        {
            return _context.SubmissionFees.FirstOrDefault(s => s.SubmissionFeeId == id);
        }

        public void UpdateSubmissionFee(SubmissionFee entity, SubmissionFee model)
        {
            entity.UserId = model.UserId;
            entity.StudentId = model.StudentId;
            entity.Amount = model.Amount;
            entity.ProgrameId = model.ProgrameId;
            entity.SubmissionDate = model.SubmissionDate;
            entity.FeeMonth = model.FeeMonth;
            entity.Description = model.Description;
        }
    }
}
