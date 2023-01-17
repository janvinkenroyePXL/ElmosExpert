using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OutOfTheBox.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PrisonName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "prisons",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "prisons");
        }
    }
}
