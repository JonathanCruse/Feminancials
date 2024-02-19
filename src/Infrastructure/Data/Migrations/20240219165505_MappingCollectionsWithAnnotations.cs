using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Feminancials.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class MappingCollectionsWithAnnotations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollectiveFeminist_Collective_CollectivesId",
                table: "CollectiveFeminist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Collective",
                table: "Collective");

            migrationBuilder.RenameTable(
                name: "Collective",
                newName: "Collectives");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Collectives",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Collectives",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Collectives",
                table: "Collectives",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CollectiveFeminist_Collectives_CollectivesId",
                table: "CollectiveFeminist",
                column: "CollectivesId",
                principalTable: "Collectives",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollectiveFeminist_Collectives_CollectivesId",
                table: "CollectiveFeminist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Collectives",
                table: "Collectives");

            migrationBuilder.RenameTable(
                name: "Collectives",
                newName: "Collective");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Collective",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Collective",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(400)",
                oldMaxLength: 400,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Collective",
                table: "Collective",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CollectiveFeminist_Collective_CollectivesId",
                table: "CollectiveFeminist",
                column: "CollectivesId",
                principalTable: "Collective",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
