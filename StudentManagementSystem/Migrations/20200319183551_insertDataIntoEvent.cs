using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagementSystem.Migrations
{
    public partial class insertDataIntoEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Description", "EventDate", "EventTitle", "Location", "UserId" },
                values: new object[] { 1, "This is technical Workshop", new DateTime(2020, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tech Workshop", "Delhi", 1 });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "AdmissionDate",
                value: new DateTime(2020, 3, 20, 0, 5, 49, 961, DateTimeKind.Local).AddTicks(9837));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "AdmissionDate",
                value: new DateTime(2020, 3, 1, 0, 6, 27, 389, DateTimeKind.Local).AddTicks(3488));
        }
    }
}
