using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagementSystem.Migrations
{
    public partial class ApplicationUserIntoAnnual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Subjects_Name",
                table: "Subjects");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Subjects",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: 3,
                column: "Title",
                value: "Teacher");

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "SessionId",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_Name",
                table: "Subjects",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Subjects_Name",
                table: "Subjects");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Subjects",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: 3,
                column: "Title",
                value: null);

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "SessionId",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_Name",
                table: "Subjects",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");
        }
    }
}
