using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Feminancials.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class MappingCollections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Collective",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(400)", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collective", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CollectiveFeminist",
                columns: table => new
                {
                    CollaboratorsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CollectivesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectiveFeminist", x => new { x.CollaboratorsId, x.CollectivesId });
                    table.ForeignKey(
                        name: "FK_CollectiveFeminist_AspNetUsers_CollaboratorsId",
                        column: x => x.CollaboratorsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollectiveFeminist_Collective_CollectivesId",
                        column: x => x.CollectivesId,
                        principalTable: "Collective",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollectiveFeminist_CollectivesId",
                table: "CollectiveFeminist",
                column: "CollectivesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollectiveFeminist");

            migrationBuilder.DropTable(
                name: "Collective");
        }
    }
}
