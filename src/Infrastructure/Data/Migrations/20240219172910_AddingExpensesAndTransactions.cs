using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Feminancials.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingExpensesAndTransactions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreditorId = table.Column<int>(type: "int", nullable: false),
                    DebtorId = table.Column<int>(type: "int", nullable: false),
                    CreditorId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_AspNetUsers_CreditorId1",
                        column: x => x.CreditorId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transactions_Collectives_DebtorId",
                        column: x => x.DebtorId,
                        principalTable: "Collectives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreditorId = table.Column<int>(type: "int", nullable: false),
                    DebtorId = table.Column<int>(type: "int", nullable: false),
                    CreditorId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DebtorId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    TransactionId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_AspNetUsers_CreditorId1",
                        column: x => x.CreditorId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Expenses_AspNetUsers_DebtorId1",
                        column: x => x.DebtorId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Expenses_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CreditorId1",
                table: "Expenses",
                column: "CreditorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_DebtorId1",
                table: "Expenses",
                column: "DebtorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_TransactionId",
                table: "Expenses",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CreditorId1",
                table: "Transactions",
                column: "CreditorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_DebtorId",
                table: "Transactions",
                column: "DebtorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
