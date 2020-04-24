using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagementSystem.Migrations
{
    public partial class changedFolderModelToModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "AdmissionDate",
                value: new DateTime(2020, 2, 25, 23, 26, 3, 474, DateTimeKind.Local).AddTicks(563));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "AdmissionDate",
                value: new DateTime(2020, 2, 23, 20, 58, 19, 81, DateTimeKind.Local).AddTicks(4573));
        }
    }
}
