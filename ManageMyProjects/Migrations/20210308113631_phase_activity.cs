using Microsoft.EntityFrameworkCore.Migrations;

namespace ManageMyProjects.Migrations
{
    public partial class phase_activity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "PhasesActivity",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhasesActivity_ProjectId",
                table: "PhasesActivity",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_PhasesActivity_Project_ProjectId",
                table: "PhasesActivity",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhasesActivity_Project_ProjectId",
                table: "PhasesActivity");

            migrationBuilder.DropIndex(
                name: "IX_PhasesActivity_ProjectId",
                table: "PhasesActivity");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "PhasesActivity");
        }
    }
}
