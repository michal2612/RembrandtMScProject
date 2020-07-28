using Microsoft.EntityFrameworkCore.Migrations;

namespace Rembrandt.Users.Core.Migrations
{
    public partial class DetailsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "DetailsId",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Salt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_DetailsId",
                table: "Users",
                column: "DetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Details_DetailsId",
                table: "Users",
                column: "DetailsId",
                principalTable: "Details",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Details_DetailsId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropIndex(
                name: "IX_Users_DetailsId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DetailsId",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
