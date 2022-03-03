using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B3Consultants.Migrations
{
    public partial class Init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Roles",
                newName: "RoleTitle");

            migrationBuilder.RenameColumn(
                name: "Level",
                table: "Experiences",
                newName: "ExperienceLevel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoleTitle",
                table: "Roles",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "ExperienceLevel",
                table: "Experiences",
                newName: "Level");
        }
    }
}
