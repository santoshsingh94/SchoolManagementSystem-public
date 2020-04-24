using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagementSystem.Migrations
{
    public partial class UpdateEventTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "EventTblId",
                table: "Events",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Events",
                column: "EventTblId");

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventTblId", "Description", "EventDate", "EventTitle", "Location", "UserId" },
                values: new object[] { 1, "This is technical Workshop", new DateTime(2020, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tech Workshop", "Delhi", 1 });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "AdmissionDate",
                value: new DateTime(2020, 3, 20, 0, 11, 26, 111, DateTimeKind.Local).AddTicks(6041));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventTblId",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "EventTblId",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Events",
                column: "EventId");

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
    }
}
