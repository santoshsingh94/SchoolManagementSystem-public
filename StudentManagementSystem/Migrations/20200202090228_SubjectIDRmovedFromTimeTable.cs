using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagementSystem.Migrations
{
    public partial class SubjectIDRmovedFromTimeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeTables_Subjects_SubjectId",
                table: "TimeTables");

            migrationBuilder.DropIndex(
                name: "IX_TimeTables_SubjectId",
                table: "TimeTables");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "TimeTables");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "TimeTables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "TimeTables",
                keyColumn: "TimeTableId",
                keyValue: 1,
                column: "SubjectId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_TimeTables_SubjectId",
                table: "TimeTables",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeTables_Subjects_SubjectId",
                table: "TimeTables",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
