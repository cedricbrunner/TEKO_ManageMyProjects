using Microsoft.EntityFrameworkCore.Migrations;

namespace ManageMyProjects.Migrations
{
    public partial class milestone_mit_project : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Milestone",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Milestone_ProjectId",
                table: "Milestone",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Milestone_Project_ProjectId",
                table: "Milestone",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Milestone_Project_ProjectId",
                table: "Milestone");

            migrationBuilder.DropIndex(
                name: "IX_Milestone_ProjectId",
                table: "Milestone");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Milestone");
        }
    }
}
