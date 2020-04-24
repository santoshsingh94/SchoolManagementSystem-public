using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagementSystem.Migrations
{
    public partial class StaffEntityModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "TakingAnyMedication",
                table: "Staffs",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "DoYouHaveAnyDisability",
                table: "Staffs",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "AnyCriminalOffence",
                table: "Staffs",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 1,
                columns: new[] { "AnyCriminalOffence", "DoYouHaveAnyDisability", "TakingAnyMedication" },
                values: new object[] { false, false, false });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "AdmissionDate",
                value: new DateTime(2020, 2, 16, 21, 3, 58, 101, DateTimeKind.Local).AddTicks(2327));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TakingAnyMedication",
                table: "Staffs",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "DoYouHaveAnyDisability",
                table: "Staffs",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "AnyCriminalOffence",
                table: "Staffs",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 1,
                columns: new[] { "AnyCriminalOffence", "DoYouHaveAnyDisability", "TakingAnyMedication" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "AdmissionDate",
                value: new DateTime(2020, 2, 10, 1, 13, 19, 328, DateTimeKind.Local).AddTicks(6162));
        }
    }
}
