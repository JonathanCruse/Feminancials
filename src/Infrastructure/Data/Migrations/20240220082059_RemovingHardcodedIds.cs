using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Feminancials.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovingHardcodedIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_AspNetUsers_DebtorId1",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Transactions_TransactionId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_AspNetUsers_DebtorId1",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_DebtorId1",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_DebtorId1",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "DebtorId1",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "DebtorId1",
                table: "Expenses");

            migrationBuilder.AlterColumn<string>(
                name: "DebtorId",
                table: "Transactions",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TransactionId",
                table: "Expenses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "DebtorId",
                table: "Expenses",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_DebtorId",
                table: "Transactions",
                column: "DebtorId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_DebtorId",
                table: "Expenses",
                column: "DebtorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_AspNetUsers_DebtorId",
                table: "Expenses",
                column: "DebtorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Transactions_TransactionId",
                table: "Expenses",
                column: "TransactionId",
                principalTable: "Transactions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_AspNetUsers_DebtorId",
                table: "Transactions",
                column: "DebtorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_AspNetUsers_DebtorId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Transactions_TransactionId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_AspNetUsers_DebtorId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_DebtorId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_DebtorId",
                table: "Expenses");

            migrationBuilder.AlterColumn<int>(
                name: "DebtorId",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DebtorId1",
                table: "Transactions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TransactionId",
                table: "Expenses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DebtorId",
                table: "Expenses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DebtorId1",
                table: "Expenses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_DebtorId1",
                table: "Transactions",
                column: "DebtorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_DebtorId1",
                table: "Expenses",
                column: "DebtorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_AspNetUsers_DebtorId1",
                table: "Expenses",
                column: "DebtorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Transactions_TransactionId",
                table: "Expenses",
                column: "TransactionId",
                principalTable: "Transactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_AspNetUsers_DebtorId1",
                table: "Transactions",
                column: "DebtorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
