using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SchoolManagementSystem.Models.Entities;
using SchoolManagementSystem.Models.Master;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SchoolManagementSystem.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace StudentManagementSystem.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser> //DbContext
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
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Religion> Religions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
                .HasOne(p => p.User)
                .WithMany(b => b.Students)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ProgrameSession>()
                .HasOne(p => p.ApplicationUser)
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
            modelBuilder.Entity<StudentPromote>()
               .HasOne(p=>p.Student)
               .WithMany(b => b.StudentPromotes)
               .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Annual>()
               .HasOne(p => p.ApplicationUser)
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
               .HasOne(p => p.ApplicationUser)
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
            modelBuilder.Entity<Subject>()
           .HasIndex(u => u.Name)
           .IsUnique();



            //On EF core you cannot create Indexes using data annotations.But you can do it using the Fluent API.
            modelBuilder.Entity<UserType>().HasIndex(u => u.TypeName).IsUnique();



           

            //UserTypes
            modelBuilder.Entity<UserType>().HasData(new UserType()
            {
                UserTypeId = 1,
                TypeName = "Admin",
                Description = "Admins are allowed to handle all the modules."
            });
            modelBuilder.Entity<UserType>().HasData(new UserType()
            {
                UserTypeId = 2,
                TypeName = "Operator",
                Description = "Operators are allowed to handle all the modules with some restrictions."
            });
            modelBuilder.Entity<UserType>().HasData(new UserType()
            {
                UserTypeId = 3,
                TypeName = "Teacher",
                Description = "Teachers are allowed to handle Student and teacher information."
            });
            modelBuilder.Entity<UserType>().HasData(new UserType()
            {
                UserTypeId = 4,
                TypeName = "Student",
                Description = "Students can view their attendance."
            });
            modelBuilder.Entity<UserType>().HasData(new UserType()
            {
                UserTypeId = 5,
                TypeName = "Accountant",
                Description = "Accountants can handle all the transactions details."
            });
            modelBuilder.Entity<UserType>().HasData(new UserType()
            {
                UserTypeId = 6,
                TypeName = "Employee",
                Description = "Employee have low access than a teacher."
            });
            //Default User
            modelBuilder.Entity<User>().HasData(new User()
            {
                UserId = 1,
                UserTypeId = 1,
                FullName = "Admin",
                UserName = "admin@gmail.com",
                Password = "password",
                ContactNo = "8652544148",
                Email = "admin@gmail.com",
                Address = "New Delhi",                
            });
            //Gender
            modelBuilder.Entity<Gender>().HasData(new Gender()
            {
                GenderId = 1,
                GenderType = "Male"
            });
            modelBuilder.Entity<Gender>().HasData(new Gender()
            {
                GenderId = 2,
                GenderType = "Female"
            });
            modelBuilder.Entity<Gender>().HasData(new Gender()
            {
                GenderId = 3,
                GenderType = "Transgender"
            });
            //Nationalities
            modelBuilder.Entity<Nationality>().HasData(new Nationality() { 
                NationalityId=1,
                NationalityType="Indian"
            }); 
            modelBuilder.Entity<Nationality>().HasData(new Nationality() { 
                NationalityId=2,
                NationalityType="Others"
            });
            //Categories
            modelBuilder.Entity<Category>().HasData(new Category() { 
                CategoryId=1,
                CategoryType="General"
            });
            modelBuilder.Entity<Category>().HasData(new Category()
            {
                CategoryId = 2,
                CategoryType = "OBC"
            });
            modelBuilder.Entity<Category>().HasData(new Category()
            {
                CategoryId = 3,
                CategoryType = "SC"
            });
            modelBuilder.Entity<Category>().HasData(new Category()
            {
                CategoryId = 4,
                CategoryType = "ST"
            });
            //Religion
            modelBuilder.Entity<Religion>().HasData(new Religion { 
                ReligionId=1,
                ReligionType="Hindu"
            });
            modelBuilder.Entity<Religion>().HasData(new Religion
            {
                ReligionId = 2,
                ReligionType = "Muslim"
            });
            modelBuilder.Entity<Religion>().HasData(new Religion
            {
                ReligionId = 3,
                ReligionType = "Sikh"
            });
            modelBuilder.Entity<Religion>().HasData(new Religion
            {
                ReligionId = 4,
                ReligionType = "Christian"
            });
            modelBuilder.Entity<Religion>().HasData(new Religion
            {
                ReligionId = 5,
                ReligionType = "Jain"
            }); 
            modelBuilder.Entity<Religion>().HasData(new Religion
            {
                ReligionId = 6,
                ReligionType = "Buddhist"
            });
            modelBuilder.Entity<Religion>().HasData(new Religion
            {
                ReligionId = 7,
                ReligionType = "Other"
            });           
            //adding subject           
            modelBuilder.Entity<Subject>().HasData(new Subject()
            {
                SubjectId = 1,
                //UserId = 1,
                Name = "Hindi",
                RegDate = Convert.ToDateTime("01-01-2018"),
                Description = "",
                TotalMarks = 100
            });
            modelBuilder.Entity<Subject>().HasData(new Subject()
            {
                SubjectId = 2,
                //UserId = 1,
                Name = "English",
                RegDate = Convert.ToDateTime("01-01-2018"),
                Description = "",
                TotalMarks = 100
            });
            modelBuilder.Entity<Subject>().HasData(new Subject()
            {
                SubjectId = 3,
                //UserId = 1,
                Name = "Math",
                RegDate = Convert.ToDateTime("01-01-2018"),
                Description = "",
                TotalMarks = 100
            });
            modelBuilder.Entity<Subject>().HasData(new Subject()
            {
                SubjectId = 4,
                //UserId = 1,
                Name = "Science",
                RegDate = Convert.ToDateTime("01-01-2018"),
                Description = "",
                TotalMarks = 100
            });
            //Adding Designation
            modelBuilder.Entity<Designation>().HasData(new Designation()
            {
                DesignationId = 1,
                Title = "Principal",
                IsActive = true
            });
            modelBuilder.Entity<Designation>().HasData(new Designation()
            {
                DesignationId = 2,
                Title = "Voice Principal",
                IsActive = true
            });
            modelBuilder.Entity<Designation>().HasData(new Designation()
            {
                DesignationId = 3,
                Title="Teacher",
                IsActive = true
            });
            modelBuilder.Entity<Designation>().HasData(new Designation()
            {
                DesignationId = 4,
                Title = "Security Guard",
                IsActive = true
            });
            modelBuilder.Entity<Designation>().HasData(new Designation()
            {
                DesignationId = 5,
                Title = "Cleaner",
                IsActive = true
            });
            modelBuilder.Entity<Programe>().HasData(new Programe()
            {
                ProgrameId = 1,
                Name = "Arts",
                StartDate = Convert.ToDateTime("01-01-2018"),
                IsActive = true
            });
            modelBuilder.Entity<Programe>().HasData(new Programe()
            {
                ProgrameId = 2,
                Name = "Commerce",
                StartDate = Convert.ToDateTime("01-01-2018"),
                IsActive = true
            });
            modelBuilder.Entity<Programe>().HasData(new Programe()
            {
                ProgrameId = 3,
                Name = "Science",
                StartDate = Convert.ToDateTime("01-01-2018"),
                IsActive = true
            });
            modelBuilder.Entity<Programe>().HasData(new Programe()
            {
                ProgrameId = 4,
                Name = "Computer Science",
                StartDate = Convert.ToDateTime("01-01-2018"),
                IsActive = true
            });

            //Annual Fee/Promote Fee
            modelBuilder.Entity<Annual>().HasData(new Annual()
            {
                AnnualId = 1,
                Title = "For LKG To Fifth Standard",
                ProgrameId=1,
                Description = "Annual Fee Same",
                Fees=1000,
                IsActive = true
            });
            modelBuilder.Entity<Annual>().HasData(new Annual()
            {
                AnnualId = 2,
                Title = "For LKG To Fifth Standard",
                ProgrameId = 1,
                Description = "Annual Fee Same",
                Fees = 1500,
                IsActive = true
            });
            modelBuilder.Entity<Annual>().HasData(new Annual()
            {
                AnnualId = 3,
                Title = "For LKG To Fifth Standard",
                ProgrameId = 3,
                Description = "Annual Fee Same",
                Fees = 1800,
                IsActive = true
            });
            modelBuilder.Entity<Annual>().HasData(new Annual()
            {
                AnnualId = 4,
                Title = "For LKG To Fifth Standard",
                ProgrameId = 4,
                Description = "Annual Fee Same",
                Fees = 2000,
                IsActive = true
            });
            //Session
            modelBuilder.Entity<Session>().HasData(new Session()
            {
                SessionId = 1,
                Name = "2020-2021",
                StartDate = Convert.ToDateTime("01-07-2020"),
                EndDate = Convert.ToDateTime("03-06-2021")
            });
            //ProgrameSession
            modelBuilder.Entity<ProgrameSession>().HasData(new ProgrameSession()
            {
                ProgrameSessionId = 1,
                SessionId = 1,
                ProgrameId=1,
                Details = "(2020-2021-Arts)LGK to 5th",
                Description = "Annual Fee Same",
                RegDate = Convert.ToDateTime("01-01-2018")
            });
            //Adding class
            modelBuilder.Entity<ClassTbl>().HasData(new ClassTbl()
            {
                ClassTblId = 1,
                Name = "LKG",
                IsActive=true
            });
            
            modelBuilder.Entity<ClassTbl>().HasData(new ClassTbl()
            {
                ClassTblId = 2,
                Name = "UKG",
                IsActive = true
            });
            modelBuilder.Entity<ClassTbl>().HasData(new ClassTbl()
            {
                ClassTblId = 3,
                Name = "First Standard",
                IsActive = true
            });
            modelBuilder.Entity<ClassTbl>().HasData(new ClassTbl()
            {
                ClassTblId = 4,
                Name = "Second Standard",
                IsActive = true
            });
            modelBuilder.Entity<ClassTbl>().HasData(new ClassTbl()
            {
                ClassTblId = 5,
                Name = "Third Standard",
                IsActive = true
            });
            modelBuilder.Entity<ClassTbl>().HasData(new ClassTbl()
            {
                ClassTblId = 6,
                Name = "Fourth Standard",
                IsActive = true
            });
            modelBuilder.Entity<ClassTbl>().HasData(new ClassTbl()
            {
                ClassTblId = 7,
                Name = "Fifth Standard",
                IsActive = true
            });
            modelBuilder.Entity<ClassTbl>().HasData(new ClassTbl()
            {
                ClassTblId = 8,
                Name = "Sixth Standard",
                IsActive = true
            });
            modelBuilder.Entity<ClassTbl>().HasData(new ClassTbl()
            {
                ClassTblId = 9,
                Name = "Seventh Standard",
                IsActive = true
            });
            modelBuilder.Entity<ClassTbl>().HasData(new ClassTbl()
            {
                ClassTblId = 10,
                Name = "Eighth Standard",
                IsActive = true
            });
            //Adding ClassSubject
            modelBuilder.Entity<ClassSubject>().HasData(new ClassSubject()
            {
                ClassSubjectId = 1,
                ClassTblId=1,
                SubjectId = 1,
                Name = "Hindi-LKG",
                IsActive = true
            });
            //Adding Sections
            modelBuilder.Entity<Section>().HasData(new Section()
            {
                SectionId=1,
                Name="A"
            });
            modelBuilder.Entity<Section>().HasData(new Section()
            {
                SectionId = 2,
                Name = "B"
            });
            modelBuilder.Entity<Section>().HasData(new Section()
            {
                SectionId = 3,
                Name = "C"
            });

        }
    }
}
