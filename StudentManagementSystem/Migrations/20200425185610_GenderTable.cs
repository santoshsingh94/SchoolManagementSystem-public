using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagementSystem.Migrations
{
    public partial class GenderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "GenderId",
                table: "Students",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "GenderId1",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "Staffs",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    GenderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GederType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.GenderId);
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "GenderId", "GederType" },
                values: new object[] { 1, "Male" });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "GenderId", "GederType" },
                values: new object[] { 2, "Female" });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "GenderId", "GederType" },
                values: new object[] { 3, "Transgender" });

            migrationBuilder.CreateIndex(
                name: "IX_Students_GenderId1",
                table: "Students",
                column: "GenderId1");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_GenderId",
                table: "Staffs",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Genders_GenderId",
                table: "Staffs",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "GenderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Genders_GenderId1",
                table: "Students",
                column: "GenderId1",
                principalTable: "Genders",
                principalColumn: "GenderId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Genders_GenderId",
                table: "Staffs");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Genders_GenderId1",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropIndex(
                name: "IX_Students_GenderId1",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_GenderId",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GenderId1",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Staffs");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
