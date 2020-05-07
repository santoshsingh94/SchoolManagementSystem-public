using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagementSystem.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Annuals",
                keyColumn: "AnnualId",
                keyValue: 1,
                columns: new[] { "Description", "Fees", "Title" },
                values: new object[] { "Annual Fee Same", 1000.0, "For LKG To Fifth Standard" });

            migrationBuilder.InsertData(
                table: "Annuals",
                columns: new[] { "AnnualId", "Description", "Fees", "IsActive", "ProgrameId", "Title", "UserId" },
                values: new object[] { 2, "Annual Fee Same", 1500.0, true, 1, "For LKG To Fifth Standard", 1 });

            migrationBuilder.InsertData(
                table: "ClassSubjects",
                columns: new[] { "ClassSubjectId", "ClassTblId", "IsActive", "Name", "SubjectId" },
                values: new object[] { 1, 1, true, "Hindi-LKG", 1 });

            migrationBuilder.UpdateData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: 4,
                column: "Title",
                value: "Security Guard");

            migrationBuilder.InsertData(
                table: "Designations",
                columns: new[] { "DesignationId", "IsActive", "Title", "UserId" },
                values: new object[] { 5, true, "Cleaner", 1 });

            migrationBuilder.InsertData(
                table: "ProgrameSessions",
                columns: new[] { "ProgrameSessionId", "Description", "Details", "ProgrameId", "RegDate", "SessionId", "UserId" },
                values: new object[] { 1, "Annual Fee Same", "(2020-2021-Arts)LGK to 5th", 1, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 });

            migrationBuilder.UpdateData(
                table: "Programes",
                keyColumn: "ProgrameId",
                keyValue: 1,
                columns: new[] { "Name", "StartDate" },
                values: new object[] { "Arts", new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Programes",
                columns: new[] { "ProgrameId", "IsActive", "Name", "StartDate", "UserId" },
                values: new object[,]
                {
                    { 2, true, "Commerce", new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, true, "Science", new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, true, "Computer Science", new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "SessionId",
                keyValue: 1,
                columns: new[] { "EndDate", "Name", "StartDate" },
                values: new object[] { new DateTime(2021, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "2020-2021", new DateTime(2020, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Annuals",
                columns: new[] { "AnnualId", "Description", "Fees", "IsActive", "ProgrameId", "Title", "UserId" },
                values: new object[] { 3, "Annual Fee Same", 1800.0, true, 3, "For LKG To Fifth Standard", 1 });

            migrationBuilder.InsertData(
                table: "Annuals",
                columns: new[] { "AnnualId", "Description", "Fees", "IsActive", "ProgrameId", "Title", "UserId" },
                values: new object[] { 4, "Annual Fee Same", 2000.0, true, 4, "For LKG To Fifth Standard", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Annuals",
                keyColumn: "AnnualId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Annuals",
                keyColumn: "AnnualId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Annuals",
                keyColumn: "AnnualId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ClassSubjects",
                keyColumn: "ClassSubjectId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProgrameSessions",
                keyColumn: "ProgrameSessionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Programes",
                keyColumn: "ProgrameId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Programes",
                keyColumn: "ProgrameId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Programes",
                keyColumn: "ProgrameId",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Annuals",
                keyColumn: "AnnualId",
                keyValue: 1,
                columns: new[] { "Description", "Fees", "Title" },
                values: new object[] { "This is the one year School", 18000.0, "July-May" });

            migrationBuilder.UpdateData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: 4,
                column: "Title",
                value: "Cleaner");

            migrationBuilder.UpdateData(
                table: "Programes",
                keyColumn: "ProgrameId",
                keyValue: 1,
                columns: new[] { "Name", "StartDate" },
                values: new object[] { "MCA", new DateTime(2016, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "SessionId",
                keyValue: 1,
                columns: new[] { "EndDate", "Name", "StartDate" },
                values: new object[] { new DateTime(2016, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "July", new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
