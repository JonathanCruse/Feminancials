using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Feminancials.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class CorrectingReferencesOnTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_AspNetUsers_DebtorId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Collectives_CreditorId",
                table: "Transactions");

            migrationBuilder.AlterColumn<int>(
                name: "DebtorId",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreditorId",
                table: "Transactions",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_AspNetUsers_CreditorId",
                table: "Transactions",
                column: "CreditorId",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_AspNetUsers_CreditorId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Collectives_DebtorId",
                table: "Transactions");

            migrationBuilder.AlterColumn<string>(
                name: "DebtorId",
                table: "Transactions",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CreditorId",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_AspNetUsers_DebtorId",
                table: "Transactions",
                column: "DebtorId",
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
    }
}
