using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagementSystem.Migrations
{
    public partial class Initial5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassTbls",
                columns: table => new
                {
                    ClassTblId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassTbls", x => x.ClassTblId);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    UserTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.UserTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserTypeId = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    ContactNo = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_UserTypes_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "UserTypes",
                        principalColumn: "UserTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Designations",
                columns: table => new
                {
                    DesignationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designations", x => x.DesignationId);
                    table.ForeignKey(
                        name: "FK_Designations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    ExamId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.ExamId);
                    table.ForeignKey(
                        name: "FK_Exams_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Programes",
                columns: table => new
                {
                    ProgrameId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programes", x => x.ProgrameId);
                    table.ForeignKey(
                        name: "FK_Programes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    SessionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.SessionId);
                    table.ForeignKey(
                        name: "FK_Sessions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    StaffId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DesignationId = table.Column<int>(nullable: false),
                    ContactNo = table.Column<string>(nullable: true),
                    BasicSalary = table.Column<double>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Qualification = table.Column<string>(nullable: true),
                    photo = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.StaffId);
                    table.ForeignKey(
                        name: "FK_Staffs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    RegDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    TotalMarks = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectId);
                    table.ForeignKey(
                        name: "FK_Subjects_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Annuals",
                columns: table => new
                {
                    AnnualId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ProgrameId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Fees = table.Column<double>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Annuals", x => x.AnnualId);
                    table.ForeignKey(
                        name: "FK_Annuals_Programes_ProgrameId",
                        column: x => x.ProgrameId,
                        principalTable: "Programes",
                        principalColumn: "ProgrameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Annuals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProgrameSessions",
                columns: table => new
                {
                    ProgrameSessionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    SessionId = table.Column<int>(nullable: false),
                    ProgrameId = table.Column<int>(nullable: false),
                    Details = table.Column<string>(nullable: true),
                    RegDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrameSessions", x => x.ProgrameSessionId);
                    table.ForeignKey(
                        name: "FK_ProgrameSessions_Programes_ProgrameId",
                        column: x => x.ProgrameId,
                        principalTable: "Programes",
                        principalColumn: "ProgrameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgrameSessions_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "SessionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProgrameSessions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionId = table.Column<int>(nullable: false),
                    ProgrameId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    FatherName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    ContactNo = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    AadharNo = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    IsEnrolled = table.Column<bool>(nullable: false),
                    ApplyDate = table.Column<DateTime>(nullable: false),
                    IsShortlist = table.Column<bool>(nullable: false),
                    IsApply = table.Column<bool>(nullable: false),
                    PreviousSchool = table.Column<string>(nullable: true),
                    PreviousPercentage = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_Programes_ProgrameId",
                        column: x => x.ProgrameId,
                        principalTable: "Programes",
                        principalColumn: "ProgrameId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "SessionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StaffAttendances",
                columns: table => new
                {
                    StaffAttendanceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<int>(nullable: false),
                    AttendanceDate = table.Column<DateTime>(nullable: false),
                    ComingTime = table.Column<TimeSpan>(nullable: true),
                    ClosingTime = table.Column<TimeSpan>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffAttendances", x => x.StaffAttendanceId);
                    table.ForeignKey(
                        name: "FK_StaffAttendances_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassSubjects",
                columns: table => new
                {
                    ClassSubjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassTblId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassSubjects", x => x.ClassSubjectId);
                    table.ForeignKey(
                        name: "FK_ClassSubjects_ClassTbls_ClassTblId",
                        column: x => x.ClassTblId,
                        principalTable: "ClassTbls",
                        principalColumn: "ClassTblId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    AttendanceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionId = table.Column<int>(nullable: false),
                    ClassTblId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    AttendanceDate = table.Column<DateTime>(nullable: false),
                    AttendanceTime = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.AttendanceId);
                    table.ForeignKey(
                        name: "FK_Attendances_ClassTbls_ClassTblId",
                        column: x => x.ClassTblId,
                        principalTable: "ClassTbls",
                        principalColumn: "ClassTblId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attendances_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "SessionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attendances_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentPromotes",
                columns: table => new
                {
                    StudentPromoteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(nullable: false),
                    ClassTblId = table.Column<int>(nullable: false),
                    ProgrameSessionId = table.Column<int>(nullable: false),
                    PromoteDate = table.Column<DateTime>(nullable: false),
                    AnnualFee = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: true),
                    IsSubmit = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentPromotes", x => x.StudentPromoteId);
                    table.ForeignKey(
                        name: "FK_StudentPromotes_ClassTbls_ClassTblId",
                        column: x => x.ClassTblId,
                        principalTable: "ClassTbls",
                        principalColumn: "ClassTblId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentPromotes_ProgrameSessions_ProgrameSessionId",
                        column: x => x.ProgrameSessionId,
                        principalTable: "ProgrameSessions",
                        principalColumn: "ProgrameSessionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentPromotes_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubmissionFees",
                columns: table => new
                {
                    SubmissionFeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ClassTblId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    ProgrameId = table.Column<int>(nullable: false),
                    SubmissionDate = table.Column<DateTime>(nullable: false),
                    FeeMonth = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubmissionFees", x => x.SubmissionFeeId);
                    table.ForeignKey(
                        name: "FK_SubmissionFees_ClassTbls_ClassTblId",
                        column: x => x.ClassTblId,
                        principalTable: "ClassTbls",
                        principalColumn: "ClassTblId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubmissionFees_Programes_ProgrameId",
                        column: x => x.ProgrameId,
                        principalTable: "Programes",
                        principalColumn: "ProgrameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubmissionFees_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubmissionFees_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExamMarks",
                columns: table => new
                {
                    ExamMarkId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamId = table.Column<int>(nullable: false),
                    ClassSubjectId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    TotalMarks = table.Column<int>(nullable: false),
                    ObtainMarks = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamMarks", x => x.ExamMarkId);
                    table.ForeignKey(
                        name: "FK_ExamMarks_ClassSubjects_ClassSubjectId",
                        column: x => x.ClassSubjectId,
                        principalTable: "ClassSubjects",
                        principalColumn: "ClassSubjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamMarks_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "ExamId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExamMarks_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExamMarks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TimeTables",
                columns: table => new
                {
                    TimeTableId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false),
                    StaffId = table.Column<int>(nullable: false),
                    ClassSubjectId = table.Column<int>(nullable: false),
                    StartTime = table.Column<TimeSpan>(nullable: false),
                    EndTime = table.Column<TimeSpan>(nullable: false),
                    Day = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeTables", x => x.TimeTableId);
                    table.ForeignKey(
                        name: "FK_TimeTables_ClassSubjects_ClassSubjectId",
                        column: x => x.ClassSubjectId,
                        principalTable: "ClassSubjects",
                        principalColumn: "ClassSubjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeTables_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TimeTables_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TimeTables_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ClassTbls",
                columns: new[] { "ClassTblId", "IsActive", "Name" },
                values: new object[] { 1, true, "High School" });

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "UserTypeId", "Description", "TypeName" },
                values: new object[] { 1, "xyz", "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "ContactNo", "Email", "FullName", "Password", "UserName", "UserTypeId" },
                values: new object[] { 1, "Varanasi", "8652544148", "ausantoshsingh@gmail.com", "Santosh Singh", "sks@123", "ausantoshsingh@gmail.com", 1 });

            migrationBuilder.InsertData(
                table: "Designations",
                columns: new[] { "DesignationId", "IsActive", "Title", "UserId" },
                values: new object[] { 1, true, "Principal", 1 });

            migrationBuilder.InsertData(
                table: "Exams",
                columns: new[] { "ExamId", "Description", "EndDate", "StartDate", "Title", "UserId" },
                values: new object[] { 1, "", new DateTime(2016, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mid Term Exam", 1 });

            migrationBuilder.InsertData(
                table: "Programes",
                columns: new[] { "ProgrameId", "IsActive", "Name", "StartDate", "UserId" },
                values: new object[] { 1, true, "MCA", new DateTime(2016, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "SessionId", "EndDate", "Name", "StartDate", "UserId" },
                values: new object[] { 1, new DateTime(2016, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "July", new DateTime(2016, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "StaffId", "Address", "BasicSalary", "ContactNo", "Description", "DesignationId", "Email", "IsActive", "Name", "Qualification", "UserId", "photo" },
                values: new object[] { 1, "Allahabad", 25000.0, "1234567890", "Completed PHd from MNNIT Allahabad", 0, "rahulmishra@gmail.com", true, "Rahul Mishra", "P.Hd", 1, null });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "SubjectId", "Description", "Name", "RegDate", "TotalMarks", "UserId" },
                values: new object[] { 1, "Computer Networks is one the most important subject in Computer Science.", "Computer Networks", new DateTime(2016, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 80, 1 });

            migrationBuilder.InsertData(
                table: "Annuals",
                columns: new[] { "AnnualId", "Description", "Fees", "IsActive", "ProgrameId", "Title", "UserId" },
                values: new object[] { 1, "This is the one year School", 18000.0, true, 1, "July-May", 1 });

            migrationBuilder.InsertData(
                table: "ClassSubjects",
                columns: new[] { "ClassSubjectId", "ClassTblId", "IsActive", "Name", "SubjectId" },
                values: new object[] { 1, 1, true, "Math", 1 });

            migrationBuilder.InsertData(
                table: "ProgrameSessions",
                columns: new[] { "ProgrameSessionId", "Description", "Details", "ProgrameId", "RegDate", "SessionId", "UserId" },
                values: new object[] { 1, "ijklmnop", "abcdefgh", 1, new DateTime(2016, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 });

            migrationBuilder.InsertData(
                table: "StaffAttendances",
                columns: new[] { "StaffAttendanceId", "AttendanceDate", "ClosingTime", "ComingTime", "StaffId" },
                values: new object[] { 1, new DateTime(2016, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 15, 6, 0), new TimeSpan(0, 12, 15, 6, 0), 1 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "AadharNo", "Address", "ApplyDate", "ContactNo", "DateOfBirth", "Email", "FatherName", "Gender", "IsApply", "IsEnrolled", "IsShortlist", "Name", "Photo", "PreviousPercentage", "PreviousSchool", "ProgrameId", "SessionId", "UserId" },
                values: new object[] { 1, "1234567890", "Varanasi", new DateTime(2016, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "8652544148", new DateTime(1994, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "ausantoshsingh@gmail.com", "C. B. Singh", "Male", true, true, true, "Santosh Singh", "", 70.0, "MIIT Varanasi", 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Attendances",
                columns: new[] { "AttendanceId", "AttendanceDate", "AttendanceTime", "ClassTblId", "SessionId", "StudentId" },
                values: new object[] { 1, new DateTime(2016, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 15, 6, 0), 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "ExamMarks",
                columns: new[] { "ExamMarkId", "ClassSubjectId", "ExamId", "ObtainMarks", "StudentId", "TotalMarks", "UserId" },
                values: new object[] { 1, 1, 1, 1, 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "StudentPromotes",
                columns: new[] { "StudentPromoteId", "AnnualFee", "ClassTblId", "IsActive", "IsSubmit", "ProgrameSessionId", "PromoteDate", "StudentId" },
                values: new object[] { 1, 10000, 1, null, null, 1, new DateTime(2016, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "SubmissionFees",
                columns: new[] { "SubmissionFeeId", "Amount", "ClassTblId", "Description", "FeeMonth", "ProgrameId", "StudentId", "SubmissionDate", "UserId" },
                values: new object[] { 1, 60000.0, 1, "This is Jan month fee", "January", 1, 1, new DateTime(2016, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "TimeTables",
                columns: new[] { "TimeTableId", "ClassSubjectId", "Day", "EndTime", "IsActive", "StaffId", "StartTime", "SubjectId", "UserId" },
                values: new object[] { 1, 1, "Saturday", new TimeSpan(0, 12, 55, 6, 0), true, 1, new TimeSpan(0, 12, 15, 6, 0), 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Annuals_ProgrameId",
                table: "Annuals",
                column: "ProgrameId");

            migrationBuilder.CreateIndex(
                name: "IX_Annuals_UserId",
                table: "Annuals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_ClassTblId",
                table: "Attendances",
                column: "ClassTblId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_SessionId",
                table: "Attendances",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_StudentId",
                table: "Attendances",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubjects_ClassTblId",
                table: "ClassSubjects",
                column: "ClassTblId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubjects_SubjectId",
                table: "ClassSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Designations_UserId",
                table: "Designations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamMarks_ClassSubjectId",
                table: "ExamMarks",
                column: "ClassSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamMarks_ExamId",
                table: "ExamMarks",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamMarks_StudentId",
                table: "ExamMarks",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamMarks_UserId",
                table: "ExamMarks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_UserId",
                table: "Exams",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Programes_UserId",
                table: "Programes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgrameSessions_ProgrameId",
                table: "ProgrameSessions",
                column: "ProgrameId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgrameSessions_SessionId",
                table: "ProgrameSessions",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgrameSessions_UserId",
                table: "ProgrameSessions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_UserId",
                table: "Sessions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffAttendances_StaffId",
                table: "StaffAttendances",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_UserId",
                table: "Staffs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPromotes_ClassTblId",
                table: "StudentPromotes",
                column: "ClassTblId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPromotes_ProgrameSessionId",
                table: "StudentPromotes",
                column: "ProgrameSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPromotes_StudentId",
                table: "StudentPromotes",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ProgrameId",
                table: "Students",
                column: "ProgrameId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_SessionId",
                table: "Students",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_UserId",
                table: "Subjects",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmissionFees_ClassTblId",
                table: "SubmissionFees",
                column: "ClassTblId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmissionFees_ProgrameId",
                table: "SubmissionFees",
                column: "ProgrameId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmissionFees_StudentId",
                table: "SubmissionFees",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmissionFees_UserId",
                table: "SubmissionFees",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTables_ClassSubjectId",
                table: "TimeTables",
                column: "ClassSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTables_StaffId",
                table: "TimeTables",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTables_SubjectId",
                table: "TimeTables",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTables_UserId",
                table: "TimeTables",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTypeId",
                table: "Users",
                column: "UserTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTypes_TypeName",
                table: "UserTypes",
                column: "TypeName",
                unique: true,
                filter: "[TypeName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Annuals");

            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "Designations");

            migrationBuilder.DropTable(
                name: "ExamMarks");

            migrationBuilder.DropTable(
                name: "StaffAttendances");

            migrationBuilder.DropTable(
                name: "StudentPromotes");

            migrationBuilder.DropTable(
                name: "SubmissionFees");

            migrationBuilder.DropTable(
                name: "TimeTables");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "ProgrameSessions");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "ClassSubjects");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Programes");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "ClassTbls");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserTypes");
        }
    }
}
