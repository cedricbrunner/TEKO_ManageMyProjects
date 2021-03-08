using Microsoft.EntityFrameworkCore.Migrations;

namespace ManageMyProjects.Migrations
{
    public partial class last_changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Milestone",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
