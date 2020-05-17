using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagementSystem.Migrations
{
    public partial class AddedFKApplicationUserStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProgrameSessions",
                keyColumn: "ProgrameSessionId",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Students",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Students",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_ApplicationUserId",
                table: "Students",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_ApplicationUserId",
                table: "Students",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_ApplicationUserId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ApplicationUserId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Students",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "ProgrameSessions",
                columns: new[] { "ProgrameSessionId", "ApplicationUserId", "Description", "Details", "ProgrameId", "RegDate", "SessionId", "UserId" },
                values: new object[] { 1, null, "Annual Fee Same", "(2020-2021-Arts)LGK to 5th", 1, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null });
        }
    }
}
