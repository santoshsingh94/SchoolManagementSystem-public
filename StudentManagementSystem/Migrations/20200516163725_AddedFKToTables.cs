using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagementSystem.Migrations
{
    public partial class AddedFKToTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Designations_Users_UserId",
                table: "Designations");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Users_UserId",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Users_UserId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Programes_Users_UserId",
                table: "Programes");

            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Users_UserId",
                table: "Sections");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Users_UserId",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Users_UserId",
                table: "Staffs");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Staffs",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Staffs",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Sessions",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Sessions",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Sections",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Sections",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ProgrameSessions",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "ProgrameSessions",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Programes",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Programes",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Expenses",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Expenses",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Exams",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Exams",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ExamMarks",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "ExamMarks",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Designations",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Designations",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Annuals",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Annuals",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ApllicationUserId",
                table: "Annuals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Annuals",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Annuals",
                keyColumn: "AnnualId",
                keyValue: 1,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Annuals",
                keyColumn: "AnnualId",
                keyValue: 2,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Annuals",
                keyColumn: "AnnualId",
                keyValue: 3,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Annuals",
                keyColumn: "AnnualId",
                keyValue: 4,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: 1,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: 2,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: 3,
                columns: new[] { "Title", "UserId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: 4,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: 5,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProgrameSessions",
                keyColumn: "ProgrameSessionId",
                keyValue: 1,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Programes",
                keyColumn: "ProgrameId",
                keyValue: 1,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Programes",
                keyColumn: "ProgrameId",
                keyValue: 2,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Programes",
                keyColumn: "ProgrameId",
                keyValue: 3,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Programes",
                keyColumn: "ProgrameId",
                keyValue: 4,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "SectionId",
                keyValue: 1,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "SectionId",
                keyValue: 2,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "SectionId",
                keyValue: 3,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "SessionId",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate", "UserId" },
                values: new object[] { new DateTime(2021, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_ApplicationUserId",
                table: "Staffs",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_ApplicationUserId",
                table: "Sessions",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_ApplicationUserId",
                table: "Sections",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgrameSessions_ApplicationUserId",
                table: "ProgrameSessions",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Programes_ApplicationUserId",
                table: "Programes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ApplicationUserId",
                table: "Expenses",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_ApplicationUserId",
                table: "Exams",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamMarks_ApplicationUserId",
                table: "ExamMarks",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Designations_ApplicationUserId",
                table: "Designations",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Annuals_ApplicationUserId",
                table: "Annuals",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Annuals_AspNetUsers_ApplicationUserId",
                table: "Annuals",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Designations_AspNetUsers_ApplicationUserId",
                table: "Designations",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Designations_Users_UserId",
                table: "Designations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamMarks_AspNetUsers_ApplicationUserId",
                table: "ExamMarks",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_AspNetUsers_ApplicationUserId",
                table: "Exams",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Users_UserId",
                table: "Exams",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_AspNetUsers_ApplicationUserId",
                table: "Expenses",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Users_UserId",
                table: "Expenses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Programes_AspNetUsers_ApplicationUserId",
                table: "Programes",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Programes_Users_UserId",
                table: "Programes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgrameSessions_AspNetUsers_ApplicationUserId",
                table: "ProgrameSessions",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_AspNetUsers_ApplicationUserId",
                table: "Sections",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Users_UserId",
                table: "Sections",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_AspNetUsers_ApplicationUserId",
                table: "Sessions",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Users_UserId",
                table: "Sessions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_AspNetUsers_ApplicationUserId",
                table: "Staffs",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Users_UserId",
                table: "Staffs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Annuals_AspNetUsers_ApplicationUserId",
                table: "Annuals");

            migrationBuilder.DropForeignKey(
                name: "FK_Designations_AspNetUsers_ApplicationUserId",
                table: "Designations");

            migrationBuilder.DropForeignKey(
                name: "FK_Designations_Users_UserId",
                table: "Designations");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamMarks_AspNetUsers_ApplicationUserId",
                table: "ExamMarks");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_AspNetUsers_ApplicationUserId",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Users_UserId",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_AspNetUsers_ApplicationUserId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Users_UserId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Programes_AspNetUsers_ApplicationUserId",
                table: "Programes");

            migrationBuilder.DropForeignKey(
                name: "FK_Programes_Users_UserId",
                table: "Programes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgrameSessions_AspNetUsers_ApplicationUserId",
                table: "ProgrameSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Sections_AspNetUsers_ApplicationUserId",
                table: "Sections");

            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Users_UserId",
                table: "Sections");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_AspNetUsers_ApplicationUserId",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Users_UserId",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_AspNetUsers_ApplicationUserId",
                table: "Staffs");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Users_UserId",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_ApplicationUserId",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_ApplicationUserId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sections_ApplicationUserId",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_ProgrameSessions_ApplicationUserId",
                table: "ProgrameSessions");

            migrationBuilder.DropIndex(
                name: "IX_Programes_ApplicationUserId",
                table: "Programes");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_ApplicationUserId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Exams_ApplicationUserId",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_ExamMarks_ApplicationUserId",
                table: "ExamMarks");

            migrationBuilder.DropIndex(
                name: "IX_Designations_ApplicationUserId",
                table: "Designations");

            migrationBuilder.DropIndex(
                name: "IX_Annuals_ApplicationUserId",
                table: "Annuals");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "ProgrameSessions");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Programes");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "ExamMarks");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Designations");

            migrationBuilder.DropColumn(
                name: "ApllicationUserId",
                table: "Annuals");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Annuals");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Staffs",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Sessions",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Sections",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ProgrameSessions",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Programes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Expenses",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Exams",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ExamMarks",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Designations",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Annuals",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Annuals",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Annuals",
                keyColumn: "AnnualId",
                keyValue: 1,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Annuals",
                keyColumn: "AnnualId",
                keyValue: 2,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Annuals",
                keyColumn: "AnnualId",
                keyValue: 3,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Annuals",
                keyColumn: "AnnualId",
                keyValue: 4,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: 1,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: 2,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: 3,
                columns: new[] { "Title", "UserId" },
                values: new object[] { "Teacher", 1 });

            migrationBuilder.UpdateData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: 4,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Designations",
                keyColumn: "DesignationId",
                keyValue: 5,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProgrameSessions",
                keyColumn: "ProgrameSessionId",
                keyValue: 1,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Programes",
                keyColumn: "ProgrameId",
                keyValue: 1,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Programes",
                keyColumn: "ProgrameId",
                keyValue: 2,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Programes",
                keyColumn: "ProgrameId",
                keyValue: 3,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Programes",
                keyColumn: "ProgrameId",
                keyValue: 4,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "SectionId",
                keyValue: 1,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "SectionId",
                keyValue: 2,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "SectionId",
                keyValue: 3,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "SessionId",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate", "UserId" },
                values: new object[] { new DateTime(2021, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_Designations_Users_UserId",
                table: "Designations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Users_UserId",
                table: "Exams",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Users_UserId",
                table: "Expenses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Programes_Users_UserId",
                table: "Programes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Users_UserId",
                table: "Sections",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Users_UserId",
                table: "Sessions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Users_UserId",
                table: "Staffs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
