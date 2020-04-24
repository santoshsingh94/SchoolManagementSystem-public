using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagementSystem.Migrations
{
    public partial class RemoveStudentIFormFilePhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Students",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                columns: new[] { "AdmissionDate", "Photo" },
                values: new object[] { new DateTime(2020, 2, 23, 20, 58, 19, 81, DateTimeKind.Local).AddTicks(4573), "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Students");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "AdmissionDate",
                value: new DateTime(2020, 2, 23, 20, 48, 59, 994, DateTimeKind.Local).AddTicks(3487));
        }
    }
}
