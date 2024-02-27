using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Feminancial.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedCollectives : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "MonthlyIncome",
                table: "AspNetUsers",
                type: "real",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Collectives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collectives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeministCollectives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollectiveId = table.Column<int>(type: "int", nullable: false),
                    FeministId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CurrentBalance = table.Column<float>(type: "real", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeministCollectives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeministCollectives_AspNetUsers_FeministId",
                        column: x => x.FeministId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FeministCollectives_Collectives_CollectiveId",
                        column: x => x.CollectiveId,
                        principalTable: "Collectives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeministCollectives_CollectiveId",
                table: "FeministCollectives",
                column: "CollectiveId");

            migrationBuilder.CreateIndex(
                name: "IX_FeministCollectives_FeministId",
                table: "FeministCollectives",
                column: "FeministId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeministCollectives");

            migrationBuilder.DropTable(
                name: "Collectives");

            migrationBuilder.DropColumn(
                name: "MonthlyIncome",
                table: "AspNetUsers");
        }
    }
}
