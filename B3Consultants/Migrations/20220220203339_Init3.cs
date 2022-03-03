using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B3Consultants.Migrations
{
    public partial class Init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultants_Roles_RoleId1",
                table: "Consultants");

            migrationBuilder.DropIndex(
                name: "IX_Consultants_RoleId1",
                table: "Consultants");

            migrationBuilder.DropColumn(
                name: "RoleId1",
                table: "Consultants");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Consultants",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Consultants_RoleId",
                table: "Consultants",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultants_Roles_RoleId",
                table: "Consultants",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultants_Roles_RoleId",
                table: "Consultants");

            migrationBuilder.DropIndex(
                name: "IX_Consultants_RoleId",
                table: "Consultants");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "Consultants",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "RoleId1",
                table: "Consultants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Consultants_RoleId1",
                table: "Consultants",
                column: "RoleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultants_Roles_RoleId1",
                table: "Consultants",
                column: "RoleId1",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
