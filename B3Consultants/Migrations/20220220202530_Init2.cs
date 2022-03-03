using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B3Consultants.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Consultants_AvailabilityId",
                table: "Consultants");

            migrationBuilder.DropIndex(
                name: "IX_Consultants_ExperienceId",
                table: "Consultants");

            migrationBuilder.CreateIndex(
                name: "IX_Consultants_AvailabilityId",
                table: "Consultants",
                column: "AvailabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultants_ExperienceId",
                table: "Consultants",
                column: "ExperienceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Consultants_AvailabilityId",
                table: "Consultants");

            migrationBuilder.DropIndex(
                name: "IX_Consultants_ExperienceId",
                table: "Consultants");

            migrationBuilder.CreateIndex(
                name: "IX_Consultants_AvailabilityId",
                table: "Consultants",
                column: "AvailabilityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consultants_ExperienceId",
                table: "Consultants",
                column: "ExperienceId",
                unique: true);
        }
    }
}
