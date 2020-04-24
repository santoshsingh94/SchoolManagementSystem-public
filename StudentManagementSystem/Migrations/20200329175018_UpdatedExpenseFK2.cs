using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagementSystem.Migrations
{
    public partial class UpdatedExpenseFK2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseTypes_Expenses_ExpenseId",
                table: "ExpenseTypes");

            migrationBuilder.DropIndex(
                name: "IX_ExpenseTypes_ExpenseId",
                table: "ExpenseTypes");

            migrationBuilder.DropColumn(
                name: "ExpenseId",
                table: "ExpenseTypes");

            migrationBuilder.DropColumn(
                name: "ExpensesTypeId",
                table: "Expenses");

            migrationBuilder.AddColumn<int>(
                name: "ExpenseTypeId",
                table: "Expenses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "AdmissionDate",
                value: new DateTime(2020, 3, 29, 23, 20, 16, 211, DateTimeKind.Local).AddTicks(2653));

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ExpenseTypeId",
                table: "Expenses",
                column: "ExpenseTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_ExpenseTypes_ExpenseTypeId",
                table: "Expenses",
                column: "ExpenseTypeId",
                principalTable: "ExpenseTypes",
                principalColumn: "ExpenseTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_ExpenseTypes_ExpenseTypeId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_ExpenseTypeId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "ExpenseTypeId",
                table: "Expenses");

            migrationBuilder.AddColumn<int>(
                name: "ExpenseId",
                table: "ExpenseTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExpensesTypeId",
                table: "Expenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "AdmissionDate",
                value: new DateTime(2020, 3, 29, 22, 57, 27, 802, DateTimeKind.Local).AddTicks(2097));

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseTypes_ExpenseId",
                table: "ExpenseTypes",
                column: "ExpenseId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseTypes_Expenses_ExpenseId",
                table: "ExpenseTypes",
                column: "ExpenseId",
                principalTable: "Expenses",
                principalColumn: "ExpenseId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
