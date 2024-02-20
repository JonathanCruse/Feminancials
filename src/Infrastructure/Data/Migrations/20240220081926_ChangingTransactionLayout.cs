using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Feminancials.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangingTransactionLayout : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_AspNetUsers_CreditorId1",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Transactions_TransactionId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_AspNetUsers_CreditorId1",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Collectives_DebtorId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_DebtorId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_CreditorId1",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "CreditorId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "CreditorId1",
                table: "Expenses");

            migrationBuilder.RenameColumn(
                name: "CreditorId1",
                table: "Transactions",
                newName: "DebtorId1");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_CreditorId1",
                table: "Transactions",
                newName: "IX_Transactions_DebtorId1");

            migrationBuilder.AlterColumn<int>(
                name: "TransactionId",
                table: "Expenses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CreditorId",
                table: "Transactions",
                column: "CreditorId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Collectives_CreditorId",
                table: "Transactions",
                column: "CreditorId",
                principalTable: "Collectives",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Transactions_TransactionId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_AspNetUsers_DebtorId1",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Collectives_CreditorId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_CreditorId",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "DebtorId1",
                table: "Transactions",
                newName: "CreditorId1");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_DebtorId1",
                table: "Transactions",
                newName: "IX_Transactions_CreditorId1");

            migrationBuilder.AlterColumn<int>(
                name: "TransactionId",
                table: "Expenses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CreditorId",
                table: "Expenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CreditorId1",
                table: "Expenses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_DebtorId",
                table: "Transactions",
                column: "DebtorId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CreditorId1",
                table: "Expenses",
                column: "CreditorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_AspNetUsers_CreditorId1",
                table: "Expenses",
                column: "CreditorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Transactions_TransactionId",
                table: "Expenses",
                column: "TransactionId",
                principalTable: "Transactions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_AspNetUsers_CreditorId1",
                table: "Transactions",
                column: "CreditorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Collectives_DebtorId",
                table: "Transactions",
                column: "DebtorId",
                principalTable: "Collectives",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
