using Microsoft.EntityFrameworkCore.Migrations;

namespace Rembrandt.Dataset.Core.Migrations
{
    public partial class AddSource : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "Observations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Source",
                table: "Observations");
        }
    }
}
