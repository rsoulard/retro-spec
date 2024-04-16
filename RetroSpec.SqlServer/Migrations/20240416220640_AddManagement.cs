using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RetroSpec.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class AddManagement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Management");

            migrationBuilder.AddColumn<Guid>(
                name: "TeamId",
                schema: "Retro",
                table: "Boards",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Organizations",
                schema: "Management",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                schema: "Management",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalSchema: "Management",
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Boards_TeamId",
                schema: "Retro",
                table: "Boards",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_OrganizationId",
                schema: "Management",
                table: "Teams",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Boards_Teams_TeamId",
                schema: "Retro",
                table: "Boards",
                column: "TeamId",
                principalSchema: "Management",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boards_Teams_TeamId",
                schema: "Retro",
                table: "Boards");

            migrationBuilder.DropTable(
                name: "Teams",
                schema: "Management");

            migrationBuilder.DropTable(
                name: "Organizations",
                schema: "Management");

            migrationBuilder.DropIndex(
                name: "IX_Boards_TeamId",
                schema: "Retro",
                table: "Boards");

            migrationBuilder.DropColumn(
                name: "TeamId",
                schema: "Retro",
                table: "Boards");
        }
    }
}
