using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RetroSpec.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Retro");

            migrationBuilder.CreateTable(
                name: "Boards",
                schema: "Retro",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Columns",
                schema: "Retro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    BoardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Columns", x => new { x.Id, x.BoardId });
                    table.ForeignKey(
                        name: "FK_Columns_Boards_BoardId",
                        column: x => x.BoardId,
                        principalSchema: "Retro",
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                schema: "Retro",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BoardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ColumnId = table.Column<int>(type: "int", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_Columns_ColumnId_BoardId",
                        columns: x => new { x.ColumnId, x.BoardId },
                        principalSchema: "Retro",
                        principalTable: "Columns",
                        principalColumns: new[] { "Id", "BoardId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_ColumnId_BoardId",
                schema: "Retro",
                table: "Cards",
                columns: new[] { "ColumnId", "BoardId" });

            migrationBuilder.CreateIndex(
                name: "IX_Columns_BoardId",
                schema: "Retro",
                table: "Columns",
                column: "BoardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards",
                schema: "Retro");

            migrationBuilder.DropTable(
                name: "Columns",
                schema: "Retro");

            migrationBuilder.DropTable(
                name: "Boards",
                schema: "Retro");
        }
    }
}
