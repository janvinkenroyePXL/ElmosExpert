using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OutOfTheBox.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "prisons",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prisons", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cells",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    IsIsolationCell = table.Column<bool>(type: "bit", nullable: false),
                    PrisonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cells", x => x.id);
                    table.ForeignKey(
                        name: "FK_cells_prisons_PrisonId",
                        column: x => x.PrisonId,
                        principalTable: "prisons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "prisoners",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CellId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prisoners", x => x.id);
                    table.ForeignKey(
                        name: "FK_prisoners_cells_CellId",
                        column: x => x.CellId,
                        principalTable: "cells",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rivalries",
                columns: table => new
                {
                    PrisonerId = table.Column<int>(type: "int", nullable: false),
                    RivalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rivalries", x => new { x.PrisonerId, x.RivalId });
                    table.ForeignKey(
                        name: "FK_rivalries_prisoners_PrisonerId",
                        column: x => x.PrisonerId,
                        principalTable: "prisoners",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_rivalries_prisoners_RivalId",
                        column: x => x.RivalId,
                        principalTable: "prisoners",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "sentences",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsLifeSentence = table.Column<bool>(type: "bit", nullable: false),
                    StartOfSentence = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndOfSentence = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PrisonerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sentences", x => x.id);
                    table.ForeignKey(
                        name: "FK_sentences_prisoners_PrisonerId",
                        column: x => x.PrisonerId,
                        principalTable: "prisoners",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_cells_PrisonId",
                table: "cells",
                column: "PrisonId");

            migrationBuilder.CreateIndex(
                name: "IX_prisoners_CellId",
                table: "prisoners",
                column: "CellId");

            migrationBuilder.CreateIndex(
                name: "IX_rivalries_RivalId",
                table: "rivalries",
                column: "RivalId");

            migrationBuilder.CreateIndex(
                name: "IX_sentences_PrisonerId",
                table: "sentences",
                column: "PrisonerId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "rivalries");

            migrationBuilder.DropTable(
                name: "sentences");

            migrationBuilder.DropTable(
                name: "prisoners");

            migrationBuilder.DropTable(
                name: "cells");

            migrationBuilder.DropTable(
                name: "prisons");
        }
    }
}
