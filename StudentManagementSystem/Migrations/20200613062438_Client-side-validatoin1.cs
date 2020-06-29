using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagementSystem.Migrations
{
    public partial class Clientsidevalidatoin1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "TimeTables",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "TimeTables",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 3,
                column: "GenderType",
                value: "Other");

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "SessionId",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_TimeTables_ApplicationUserId",
                table: "TimeTables",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeTables_AspNetUsers_ApplicationUserId",
                table: "TimeTables",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeTables_AspNetUsers_ApplicationUserId",
                table: "TimeTables");

            migrationBuilder.DropIndex(
                name: "IX_TimeTables_ApplicationUserId",
                table: "TimeTables");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "TimeTables");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "TimeTables",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 3,
                column: "GenderType",
                value: "Transgender");

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "SessionId",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
