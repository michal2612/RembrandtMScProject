using Microsoft.EntityFrameworkCore.Migrations;

namespace user_microservice.Migrations
{
    public partial class RolesIDaddedtoTestClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "TestClass",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestClass_RoleId",
                table: "TestClass",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestClass_Roles_RoleId",
                table: "TestClass",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestClass_Roles_RoleId",
                table: "TestClass");

            migrationBuilder.DropIndex(
                name: "IX_TestClass_RoleId",
                table: "TestClass");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "TestClass");
        }
    }
}
