using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagementSystem.Migrations
{
    public partial class ForeignKeyStaffIdToDesignation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Staffs_DesignationId",
                table: "Staffs",
                column: "DesignationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Designations_DesignationId",
                table: "Staffs",
                column: "DesignationId",
                principalTable: "Designations",
                principalColumn: "DesignationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Designations_DesignationId",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_DesignationId",
                table: "Staffs");
        }
    }
}
