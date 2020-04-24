using SchoolManagementSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Models
{
    public interface IRepository
    {
        //General
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        //Student
        List<Student> GetAllStudentAsync();
        Student GetStudentAsync(int id);
        void UpdateStudent(Student oldStudent, Student newStudent);
        //User        
        List<User> GetAllUserAsync();        
        User GetUserAsync(int id);
        void UpdateUser(User oldUser, User newUser);
       


        //UserType       
        List<UserType> GetAllUserTypeAsync();
        UserType GetUserTypeAsync(int id);
        void UpdateUserType(UserType oldUserType, UserType newUserType);
        //Annual
        List<Annual> GetAllAnnualAsync();
        Annual GetAnnualAsync(int id);        
        void UpdateAnnual(Annual entity, Annual model);
       

        //Attendance
        List<Attendance> GetAllAttendanceAsync();
        
        Attendance GetAttendanceAsync(int id);
        void UpdateAttendance(Attendance entity, Attendance model);
        //Designation
        List<Designation> GetAllDesignationAsync();
        Designation GetDesignationAsync(int id);
        void UpdateDesignation(Designation entity, Designation model);
        //Exam        
        List<Exam> GetAllExamAsync();
        Exam GetExamAsync(int id);
        void UpdateExam(Exam entity, Exam model);
        //ExamMarks
        List<ExamMark> GetAllExamMarksAsync();
        ExamMark GetExamMarksAsync(int id);
        void UpdateExamMarks(ExamMark entity, ExamMark model);
        
        //Programe
        List<Programe> GetProgrameAsync();
        Programe GetProgrameAsync(int id);
        void UpdatePrograme(Programe entity, Programe model);

        //Session        
        List<Session> GetAllSessionAsync();        
        Session GetSessionAsync(int id);
        void UpdateSession(Session entity, Session model);
        

        //ProgrameSession
        List<ProgrameSession> GetAllProgrameSessionAsync();
       
        ProgrameSession GetProgrameSessionAsync(int id);
        void UpdateProgrameSession(ProgrameSession entity, ProgrameSession model);
        //StaffAttendance
        List<StaffAttendance> GetAllStaffAttendanceAsync();

        StaffAttendance GetStaffAttendanceAsync(int id);
        void UpdateStaffAttendance(StaffAttendance entity, StaffAttendance model);
        //Staff        
        List<Staff> GetAllStaffAsync();       
        Staff GetStaffAsync(int id); 
        void UpdateStaff(Staff entity, Staff model);
        

       
        //Subject
        List<Subject> GetAllSubjectAsync();
        Subject GetSubjectAsync(int id);
        void UpdateSubject(Subject entity, Subject model);
        //TimeTable
        List<TimeTable> GetAllTimeTableAsync();
        TimeTable GetTimeTableAsync(int id);
        void UpdateTimeTable(TimeTable entity, TimeTable model);
        //SubmissionFee
        List<SubmissionFee> GetAllSubmissionFeeAsync();
        SubmissionFee GetSubmissionFeeAsync(int id);        
        void UpdateSubmissionFee(SubmissionFee entity, SubmissionFee model);       
    }
}
