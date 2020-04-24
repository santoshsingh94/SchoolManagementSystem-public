using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SchoolManagementSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Models
{
    public class AppDbContext : DbContext
    {
        private readonly DbContextOptions<AppDbContext> _options;
        private readonly IConfiguration _config;

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration config) : base(options)
        {
            _options = options;
            _config = config;
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Programe> Programes { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<ProgrameSession> ProgrameSessions { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<StaffAttendance> StaffAttendances { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubmissionFee> SubmissionFees { get; set; }
        public DbSet<TimeTable> TimeTables { get; set; }
        public DbSet<Annual> Annuals { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamMark> ExamMarks { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<ClassTbl> ClassTbls { get; set; }
        public DbSet<StudentPromote> StudentPromotes { get; set; }
        public DbSet<ClassSubject> ClassSubjects { get; set; }
        public DbSet<EmployeeCertification> EmployeeCertifications { get; set; }
        public DbSet<EmployeeEducation> EmployeeEducations { get; set; }
        public DbSet<EmployeeLanguage> EmployeeLanguages { get; set; }
        public DbSet<EmployeeLeaving> EmployeeLeaving { get; set; }
        public DbSet<EmployeeResume> EmployeeResumes { get; set; }
        public DbSet<EmployeeSalary> EmployeeSalarys { get; set; }
        public DbSet<EmployeeSkill> EmployeeSkills { get; set; }                  
        public DbSet<EmployeeWorkExperience> EmployeeWorkExperiences { get; set; }
        public DbSet<EventTbl> Events { get; set; }
        public DbSet<SchoolLeaving> SchoolLeavings { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(p => p.User)
                .WithMany(b => b.Students)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ProgrameSession>()
                .HasOne(p => p.User)
                .WithMany(b => b.ProgrameSessions)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ProgrameSession>()
                .HasOne(p => p.Session)
                .WithMany(b => b.ProgrameSessions)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<SubmissionFee>()
                .HasOne(p => p.Student)
                .WithMany(b => b.SubmissionFees)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<SubmissionFee>()
                .HasOne(p => p.User)
                .WithMany(b => b.SubmissionFees)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<TimeTable>()
                .HasOne(p => p.User)
                .WithMany(b => b.TimeTables)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<TimeTable>()
               .HasOne(p => p.Staff)
               .WithMany(b => b.TimeTables)
               .OnDelete(DeleteBehavior.Restrict);
            //modelBuilder.Entity<TimeTable>()
            //   .HasOne(p => p.Subject)
            //   .WithMany(b => b.TimeTables)
            //   .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<StudentPromote>()
               .HasOne(p=>p.Student)
               .WithMany(b => b.StudentPromotes)
               .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Annual>()
               .HasOne(p => p.User)
               .WithMany(b => b.Annuals)
               .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Attendance>()
               .HasOne(p => p.Student)
               .WithMany(b => b.Attendances)
               .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ExamMark>()
               .HasOne(p => p.Exam)
               .WithMany(b => b.ExamMarks)
               .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ExamMark>()
               .HasOne(p => p.Student)
               .WithMany(b => b.ExamMarks)
               .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ExamMark>()
               .HasOne(p => p.User)
               .WithMany(b => b.ExamMarks)
               .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Staff>()
               .HasOne(p => p.Designation)
               .WithMany(b => b.Staffs)
               .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<EmployeeLeaving>()
               .HasOne(p => p.User)
               .WithMany(b => b.EmployeeLeavings)
               .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<EmployeeSalary>()
               .HasOne(p => p.User)
               .WithMany(b => b.EmployeeSalaries)
               .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<SchoolLeaving>()
               .HasOne(p => p.User)
               .WithMany(b => b.SchoolLeavings)
               .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<StudentPromote>()
               .HasOne(p => p.Section)
               .WithMany(b => b.StudentPromotes)
               .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Student>()
               .HasOne(p => p.ClassTbl)
               .WithMany(b => b.Students)
               .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Student>()
               .HasOne(p => p.Programe)
               .WithMany(b => b.Students)
               .OnDelete(DeleteBehavior.Restrict);

            //Addding Unique Key
            modelBuilder.Entity<Staff>()
            .HasIndex(u => u.Email)
            .IsUnique();
            modelBuilder.Entity<User>()
            .HasIndex(u => u.UserName)
            .IsUnique();
            modelBuilder.Entity<Student>()
            .HasIndex(u => u.Email)
            .IsUnique();



            //On EF core you cannot create Indexes using data annotations.But you can do it using the Fluent API.
            modelBuilder.Entity<UserType>().HasIndex(u => u.TypeName).IsUnique();



            modelBuilder.Entity<Student>().HasData(new
            {
                StudentId = 1,
                SessionId = 1,
                ProgrameId = 1,
                UserId = 1,
                Name = "Santosh Singh",
                FatherName = "C. B. Singh",
                DateOfBirth = Convert.ToDateTime("12-13-1994"),
                AdmissionDate=DateTime.Now,
                Gender = "Male",
                ContactNo = "8652544148",
                Email = "ausantoshsingh@gmail.com",
                Address = "Varanasi",
                AadharNo = "1234567890",
                Photo = "",
                IsEnrolled = true,
                ApplyDate = Convert.ToDateTime("04-08-2016"),
                IsShortlist = true,
                IsApply = true,
                PreviousSchool = "MIIT Varanasi",
                PreviousPercentage = 70.0f,
                ClassTblId =1 
            });
            modelBuilder.Entity<User>().HasData(new User()
            {
                UserId = 1,
                UserTypeId = 1,
                FullName = "Santosh Singh",
                UserName = "ausantoshsingh@gmail.com",
                Password = "sks@123",
                ContactNo = "8652544148",
                Email = "ausantoshsingh@gmail.com",
                Address = "Varanasi"
            });
            modelBuilder.Entity<Session>().HasData(new Session()
            {
                SessionId = 1,
                UserId = 1,
                Name = "July",
                StartDate = Convert.ToDateTime("04-08-2016"),
                EndDate = Convert.ToDateTime("04-08-2016")
            });
            modelBuilder.Entity<Annual>().HasData(new Annual()
            {
                AnnualId = 1,
                ProgrameId = 1,
                UserId = 1,
                Title = "July-May",
                Description = "This is the one year School",
                Fees = 18000,
                IsActive = true
            });
            modelBuilder.Entity<Programe>().HasData(new Programe()
            {
                ProgrameId = 1,
                UserId = 1,
                Name = "MCA",
                StartDate = Convert.ToDateTime("04-08-2016"),
                IsActive = true
            });
            modelBuilder.Entity<ProgrameSession>().HasData(new ProgrameSession()
            {
                ProgrameSessionId = 1,
                UserId = 1,
                SessionId = 1,
                ProgrameId = 1,
                Details = "abcdefgh",
                RegDate = Convert.ToDateTime("04-08-2016"),
                Description = "ijklmnop"
            });
            modelBuilder.Entity<Staff>().HasData(new Staff()
            {
                StaffId = 1,
                UserId = 1,
                Name = "Rahul Mishra",
                ContactNo = "1234567890",
                BasicSalary = 25000,
                Email = "rahulmishra@gmail.com",
                Address = "Allahabad",
                Qualification = "P.Hd",
                Gender = "male",
                HomePhone="8652544148",
                Description = "Completed PHd from MNNIT Allahabad",
                IsActive = true
            });
            modelBuilder.Entity<StaffAttendance>().HasData(new StaffAttendance()
            {
                StaffAttendanceId = 1,
                StaffId = 1,
                AttendanceDate = Convert.ToDateTime("04-08-2016"),
                ComingTime = TimeSpan.Parse("12:15:06"),
                ClosingTime = TimeSpan.Parse("1:15:06")
            });
            modelBuilder.Entity<Subject>().HasData(new Subject()
            {
                SubjectId = 1,
                UserId = 1,
                Name = "Computer Networks",
                RegDate = Convert.ToDateTime("04-08-2016"),
                Description = "Computer Networks is one the most important subject in Computer Science.",
                TotalMarks = 80
            });
            modelBuilder.Entity<SubmissionFee>().HasData(new SubmissionFee()
            {
                SubmissionFeeId = 1,
                UserId = 1,
                StudentId = 1,
                ClassTblId=1,
                ProgrameId = 1,
                Amount = 60000,
                SubmissionDate = Convert.ToDateTime("04-08-2016"),
                FeeMonth = "January",
                Description = "This is Jan month fee"
            });
            modelBuilder.Entity<TimeTable>().HasData(new TimeTable()
            {
                TimeTableId = 1,
                UserId = 1,
                StaffId=1,
                ClassSubjectId=1,
                StartTime = TimeSpan.Parse("12:15:06"),
                EndTime = TimeSpan.Parse("12:55:06"),
                Day = "Saturday",
                IsActive = true
            });
            
            modelBuilder.Entity<Attendance>().HasData(new Attendance()
            {
                AttendanceId = 1,
                SessionId = 1,
                StudentId = 1,
                ClassTblId=1,
                AttendanceDate = Convert.ToDateTime("04-08-2016"),
                AttendanceTime = TimeSpan.Parse("12:15:06")

            });
            modelBuilder.Entity<Designation>().HasData(new Designation()
            {
                DesignationId = 1,
                UserId = 1,
                Title = "Principal",
                IsActive = true
            });
            modelBuilder.Entity<Exam>().HasData(new Exam()
            {
                ExamId = 1,
                UserId = 1,
                Title = "Mid Term Exam",
                StartDate = Convert.ToDateTime("04-08-2016"),
                EndDate = Convert.ToDateTime("10-08-2016"),
                Description = ""
            });
            
            modelBuilder.Entity<ExamMark>().HasData(new ExamMark()
            {
                ExamMarkId = 1,
                ExamId = 1,
                StudentId = 1,
                ClassSubjectId=1,
                UserId = 1,
                TotalMarks = 1,
                ObtainMarks = 1
            });
            modelBuilder.Entity<UserType>().HasData(new UserType()
            {
                UserTypeId = 1,
                TypeName = "Admin",
                Description = "xyz"
            });
            modelBuilder.Entity<ClassTbl>().HasData(new ClassTbl()
            {
                ClassTblId = 1,
                Name = "High School",
                IsActive=true
            });
            modelBuilder.Entity<StudentPromote>().HasData(new StudentPromote()
            {
                StudentPromoteId=1,
                StudentId=1,
                ClassTblId=1,
                ProgrameSessionId=1,
                PromoteDate= Convert.ToDateTime("04-08-2016"),
                AnnualFee=10000
            });
            modelBuilder.Entity<ClassSubject>().HasData(new ClassSubject()
            {
                ClassSubjectId=1,
                ClassTblId = 1,
                SubjectId = 1,
                Name = "Math",
                IsActive=true
            });
            modelBuilder.Entity<Section>().HasData(new Section()
            {
                SectionId=1,
                UserId = 1,
                Name="A"
            });
            modelBuilder.Entity<EventTbl>().HasData(new EventTbl()
            {
                EventTblId = 1,
                EventTitle="Tech Workshop",
                EventDate= Convert.ToDateTime("04-08-2020"),
                Location = "Delhi",
                Description="This is technical Workshop",
                UserId=1
            });
        }
    }
}
