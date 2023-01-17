using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OutOfTheBox.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RivalriesNoCompositePrimaryKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_rivalries",
                table: "rivalries");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "rivalries",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_rivalries",
                table: "rivalries",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_rivalries_PrisonerId",
                table: "rivalries",
                column: "PrisonerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_rivalries",
                table: "rivalries");

            migrationBuilder.DropIndex(
                name: "IX_rivalries_PrisonerId",
                table: "rivalries");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "rivalries");

            migrationBuilder.AddPrimaryKey(
                name: "PK_rivalries",
                table: "rivalries",
                columns: new[] { "PrisonerId", "RivalId" });
        }
    }
}
