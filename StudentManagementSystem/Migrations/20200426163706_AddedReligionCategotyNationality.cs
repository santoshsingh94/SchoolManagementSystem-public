using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagementSystem.Migrations
{
    public partial class AddedReligionCategotyNationality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Religion",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NationalityId",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReligionId",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Staffs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NationalityId",
                table: "Staffs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReligionId",
                table: "Staffs",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Nationalities",
                columns: table => new
                {
                    NationalityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalityType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationalities", x => x.NationalityId);
                });

            migrationBuilder.CreateTable(
                name: "Religions",
                columns: table => new
                {
                    ReligionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReligionType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Religions", x => x.ReligionId);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryType" },
                values: new object[,]
                {
                    { 1, "General" },
                    { 2, "OBC" },
                    { 3, "SC" },
                    { 4, "ST" }
                });

            migrationBuilder.InsertData(
                table: "Nationalities",
                columns: new[] { "NationalityId", "NationalityType" },
                values: new object[,]
                {
                    { 1, "Indian" },
                    { 2, "Others" }
                });

            migrationBuilder.InsertData(
                table: "Religions",
                columns: new[] { "ReligionId", "ReligionType" },
                values: new object[,]
                {
                    { 1, "Hindu" },
                    { 2, "Muslim" },
                    { 3, "Sikh" },
                    { 4, "Christian" },
                    { 5, "Jain" },
                    { 6, "Buddhist" },
                    { 7, "Other" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_CategoryId",
                table: "Students",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_NationalityId",
                table: "Students",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ReligionId",
                table: "Students",
                column: "ReligionId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_CategoryId",
                table: "Staffs",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_NationalityId",
                table: "Staffs",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_ReligionId",
                table: "Staffs",
                column: "ReligionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Categories_CategoryId",
                table: "Staffs",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Nationalities_NationalityId",
                table: "Staffs",
                column: "NationalityId",
                principalTable: "Nationalities",
                principalColumn: "NationalityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Religions_ReligionId",
                table: "Staffs",
                column: "ReligionId",
                principalTable: "Religions",
                principalColumn: "ReligionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Categories_CategoryId",
                table: "Students",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Nationalities_NationalityId",
                table: "Students",
                column: "NationalityId",
                principalTable: "Nationalities",
                principalColumn: "NationalityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Religions_ReligionId",
                table: "Students",
                column: "ReligionId",
                principalTable: "Religions",
                principalColumn: "ReligionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Categories_CategoryId",
                table: "Staffs");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Nationalities_NationalityId",
                table: "Staffs");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Religions_ReligionId",
                table: "Staffs");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Categories_CategoryId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Nationalities_NationalityId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Religions_ReligionId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Nationalities");

            migrationBuilder.DropTable(
                name: "Religions");

            migrationBuilder.DropIndex(
                name: "IX_Students_CategoryId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_NationalityId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ReligionId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_CategoryId",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_NationalityId",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_ReligionId",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "NationalityId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ReligionId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "NationalityId",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "ReligionId",
                table: "Staffs");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Religion",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
