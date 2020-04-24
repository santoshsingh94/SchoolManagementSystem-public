using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagementSystem.Migrations
{
    public partial class NewTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplyDate",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IsApply",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IsEnrolled",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IsShortlist",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "ProgrameId",
                table: "Students",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PreviousSchool",
                table: "Students",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "PreviousPercentage",
                table: "Students",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Students",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FatherName",
                table: "Students",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AdmissionDate",
                table: "Students",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Cast",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassTblId",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "GuardianName",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GuardianOccupation",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GuardianPhone",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Religion",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SectionId",
                table: "StudentPromotes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AnyCriminalOffence",
                table: "Staffs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CriminalOffenceDetails",
                table: "Staffs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DisabilityDetails",
                table: "Staffs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoYouHaveAnyDisability",
                table: "Staffs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Staffs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomePhone",
                table: "Staffs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MedicationDetails",
                table: "Staffs",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDate",
                table: "Staffs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TakingAnyMedication",
                table: "Staffs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EmployeeLeaving",
                columns: table => new
                {
                    EmployeeLeavingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    StaffId = table.Column<int>(nullable: false),
                    LeavingDate = table.Column<DateTime>(nullable: false),
                    LeavingReason = table.Column<string>(nullable: true),
                    LeavingComments = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeLeaving", x => x.EmployeeLeavingId);
                    table.ForeignKey(
                        name: "FK_EmployeeLeaving_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeLeaving_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeResumes",
                columns: table => new
                {
                    EmployeeResumeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Nationality = table.Column<string>(nullable: true),
                    EducationLevel = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: true),
                    LinkedInProfile = table.Column<string>(nullable: true),
                    FacebookProfile = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeResumes", x => x.EmployeeResumeId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSalarys",
                columns: table => new
                {
                    EmployeeSalaryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    StaffId = table.Column<int>(nullable: false),
                    Amount = table.Column<float>(nullable: false),
                    SalaryMonth = table.Column<string>(nullable: true),
                    SalaryYear = table.Column<string>(nullable: true),
                    SalaryDate = table.Column<DateTime>(nullable: false),
                    Comments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSalarys", x => x.EmployeeSalaryId);
                    table.ForeignKey(
                        name: "FK_EmployeeSalarys_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeSalarys_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventTitle = table.Column<string>(nullable: true),
                    EventDate = table.Column<DateTime>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchoolLeavings",
                columns: table => new
                {
                    SchoolLeavingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    ClassTblId = table.Column<int>(nullable: false),
                    LeavingDate = table.Column<DateTime>(nullable: false),
                    LeavingReason = table.Column<string>(nullable: true),
                    LeavingComments = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolLeavings", x => x.SchoolLeavingId);
                    table.ForeignKey(
                        name: "FK_SchoolLeavings_ClassTbls_ClassTblId",
                        column: x => x.ClassTblId,
                        principalTable: "ClassTbls",
                        principalColumn: "ClassTblId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolLeavings_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolLeavings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    SectionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.SectionId);
                    table.ForeignKey(
                        name: "FK_Sections_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeCertifications",
                columns: table => new
                {
                    EmployeeCertificationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CertificateName = table.Column<string>(nullable: true),
                    CertificationAuthority = table.Column<string>(nullable: true),
                    LevelCertification = table.Column<string>(nullable: true),
                    FromYear = table.Column<DateTime>(nullable: false),
                    EmployeeResumeId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeCertifications", x => x.EmployeeCertificationId);
                    table.ForeignKey(
                        name: "FK_EmployeeCertifications_EmployeeResumes_EmployeeResumeId",
                        column: x => x.EmployeeResumeId,
                        principalTable: "EmployeeResumes",
                        principalColumn: "EmployeeResumeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeCertifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeEducations",
                columns: table => new
                {
                    EmployeeEducationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeResumeId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Institute = table.Column<string>(nullable: true),
                    University = table.Column<string>(nullable: true),
                    TitleOfDiploma = table.Column<string>(nullable: true),
                    Degree = table.Column<string>(nullable: true),
                    FromYear = table.Column<DateTime>(nullable: false),
                    ToYear = table.Column<DateTime>(nullable: false),
                    InstituteCity = table.Column<string>(nullable: true),
                    InstituteCountry = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeEducations", x => x.EmployeeEducationId);
                    table.ForeignKey(
                        name: "FK_EmployeeEducations_EmployeeResumes_EmployeeResumeId",
                        column: x => x.EmployeeResumeId,
                        principalTable: "EmployeeResumes",
                        principalColumn: "EmployeeResumeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeLanguages",
                columns: table => new
                {
                    EmployeeLanguageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageName = table.Column<string>(nullable: true),
                    Proficiency = table.Column<string>(nullable: true),
                    EmployeeResumeId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeLanguages", x => x.EmployeeLanguageId);
                    table.ForeignKey(
                        name: "FK_EmployeeLanguages_EmployeeResumes_EmployeeResumeId",
                        column: x => x.EmployeeResumeId,
                        principalTable: "EmployeeResumes",
                        principalColumn: "EmployeeResumeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeLanguages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSkills",
                columns: table => new
                {
                    EmployeeSkillId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(nullable: true),
                    EmployeeResumeId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSkills", x => x.EmployeeSkillId);
                    table.ForeignKey(
                        name: "FK_EmployeeSkills_EmployeeResumes_EmployeeResumeId",
                        column: x => x.EmployeeResumeId,
                        principalTable: "EmployeeResumes",
                        principalColumn: "EmployeeResumeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeSkills_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeWorkExperiences",
                columns: table => new
                {
                    EmployeeWorkExperienceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    FromYear = table.Column<DateTime>(nullable: false),
                    ToYear = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    EmployeeResumeId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeWorkExperiences", x => x.EmployeeWorkExperienceId);
                    table.ForeignKey(
                        name: "FK_EmployeeWorkExperiences_EmployeeResumes_EmployeeResumeId",
                        column: x => x.EmployeeResumeId,
                        principalTable: "EmployeeResumes",
                        principalColumn: "EmployeeResumeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeWorkExperiences_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                columns: new[] { "AdmissionDate", "ClassTblId", "PreviousPercentage" },
                values: new object[] { new DateTime(2020, 2, 10, 1, 13, 19, 328, DateTimeKind.Local).AddTicks(6162), 1, 70f });

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassTblId",
                table: "Students",
                column: "ClassTblId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPromotes_SectionId",
                table: "StudentPromotes",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCertifications_EmployeeResumeId",
                table: "EmployeeCertifications",
                column: "EmployeeResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCertifications_UserId",
                table: "EmployeeCertifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEducations_EmployeeResumeId",
                table: "EmployeeEducations",
                column: "EmployeeResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLanguages_EmployeeResumeId",
                table: "EmployeeLanguages",
                column: "EmployeeResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLanguages_UserId",
                table: "EmployeeLanguages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLeaving_StaffId",
                table: "EmployeeLeaving",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLeaving_UserId",
                table: "EmployeeLeaving",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSalarys_StaffId",
                table: "EmployeeSalarys",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSalarys_UserId",
                table: "EmployeeSalarys",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkills_EmployeeResumeId",
                table: "EmployeeSkills",
                column: "EmployeeResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkills_UserId",
                table: "EmployeeSkills",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeWorkExperiences_EmployeeResumeId",
                table: "EmployeeWorkExperiences",
                column: "EmployeeResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeWorkExperiences_UserId",
                table: "EmployeeWorkExperiences",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_UserId",
                table: "Events",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolLeavings_ClassTblId",
                table: "SchoolLeavings",
                column: "ClassTblId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolLeavings_StudentId",
                table: "SchoolLeavings",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolLeavings_UserId",
                table: "SchoolLeavings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_UserId",
                table: "Sections",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentPromotes_Sections_SectionId",
                table: "StudentPromotes",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "SectionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_ClassTbls_ClassTblId",
                table: "Students",
                column: "ClassTblId",
                principalTable: "ClassTbls",
                principalColumn: "ClassTblId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentPromotes_Sections_SectionId",
                table: "StudentPromotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_ClassTbls_ClassTblId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "EmployeeCertifications");

            migrationBuilder.DropTable(
                name: "EmployeeEducations");

            migrationBuilder.DropTable(
                name: "EmployeeLanguages");

            migrationBuilder.DropTable(
                name: "EmployeeLeaving");

            migrationBuilder.DropTable(
                name: "EmployeeSalarys");

            migrationBuilder.DropTable(
                name: "EmployeeSkills");

            migrationBuilder.DropTable(
                name: "EmployeeWorkExperiences");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "SchoolLeavings");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "EmployeeResumes");

            migrationBuilder.DropIndex(
                name: "IX_Students_ClassTblId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_StudentPromotes_SectionId",
                table: "StudentPromotes");

            migrationBuilder.DropColumn(
                name: "AdmissionDate",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Cast",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ClassTblId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GuardianName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GuardianOccupation",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GuardianPhone",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Religion",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "StudentPromotes");

            migrationBuilder.DropColumn(
                name: "AnyCriminalOffence",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "CriminalOffenceDetails",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "DisabilityDetails",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "DoYouHaveAnyDisability",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "HomePhone",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "MedicationDetails",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "TakingAnyMedication",
                table: "Staffs");

            migrationBuilder.AlterColumn<int>(
                name: "ProgrameId",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "PreviousSchool",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<double>(
                name: "PreviousPercentage",
                table: "Students",
                type: "float",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "FatherName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<DateTime>(
                name: "ApplyDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsApply",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnrolled",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsShortlist",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                columns: new[] { "ApplyDate", "IsApply", "IsEnrolled", "IsShortlist", "PreviousPercentage" },
                values: new object[] { new DateTime(2016, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, 70.0 });
        }
    }
}
