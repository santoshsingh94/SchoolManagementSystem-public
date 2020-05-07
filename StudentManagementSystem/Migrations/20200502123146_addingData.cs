using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagementSystem.Migrations
{
    public partial class addingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ClassTbls",
                columns: new[] { "ClassTblId", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, true, "LKG" },
                    { 2, true, "UKG" },
                    { 3, true, "First Standard" },
                    { 4, true, "Second Standard" },
                    { 5, true, "Third Standard" },
                    { 6, true, "Fourth Standard" },
                    { 7, true, "Fifth Standard" },
                    { 8, true, "Sixth Standard" },
                    { 9, true, "Seventh Standard" },
                    { 10, true, "Eighth Standard" }
                });

            migrationBuilder.InsertData(
                table: "Designations",
                columns: new[] { "DesignationId", "IsActive", "Title", "UserId" },
                values: new object[,]
                {
                    { 4, true, "Cleaner", 1 },
                    { 3, true, "Teacher", 1 },
                    { 2, true, "Voice Principal", 1 },
                    { 1, true, "Principal", 1 }
                });

            migrationBuilder.InsertData(
                table: "Programes",
                columns: new[] { "ProgrameId", "IsActive", "Name", "StartDate", "UserId" },
                values: new object[] { 1, true, "MCA", new DateTime(2016, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "SectionId", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "A", 1 },
                    { 2, "B", 1 },
                    { 3, "C", 1 }
                });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "SessionId", "EndDate", "Name", "StartDate", "UserId" },
                values: new object[] { 1, new DateTime(2016, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "July", new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "SubjectId", "Description", "Name", "RegDate", "TotalMarks", "UserId" },
                values: new object[,]
                {
                    { 1, "", "Hindi", new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, 1 },
                    { 2, "", "English", new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, 1 },
                    { 3, "", "Math", new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, 1 },
                    { 4, "", "Science", new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, 1 }
                });

            migrationBuilder.InsertData(
                table: "Annuals",
                columns: new[] { "AnnualId", "Description", "Fees", "IsActive", "ProgrameId", "Title", "UserId" },
                values: new object[] { 1, "This is the one year School", 18000.0, true, 1, "July-May", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Annuals",
                keyColumn: "AnnualId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ClassTbls",
                keyColumn: "ClassTblId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ClassTbls",
                keyColumn: "ClassTblId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ClassTbls",
                keyColumn: "ClassTblId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ClassTbls",
                keyColumn: "ClassTblId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ClassTbls",
                keyColumn: "ClassTblId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ClassTbls",
                keyColumn: "ClassTblId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ClassTbls",
                keyColumn: "ClassTblId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ClassTbls",
                keyColumn: "ClassTblId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ClassTbls",
                keyColumn: "ClassTblId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ClassTbls",
                keyColumn: "ClassTblId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "SectionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "SectionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "SectionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "SessionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "SubjectId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "SubjectId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "SubjectId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "SubjectId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Programes",
                keyColumn: "ProgrameId",
                keyValue: 1);
        }
    }
}
