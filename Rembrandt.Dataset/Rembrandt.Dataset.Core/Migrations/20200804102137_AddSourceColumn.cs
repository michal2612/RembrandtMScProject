using Microsoft.EntityFrameworkCore.Migrations;

namespace Rembrandt.Dataset.Core.Migrations
{
    public partial class AddSourceColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "ViennaObservations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Source",
                table: "ViennaObservations");
        }
    }
}
