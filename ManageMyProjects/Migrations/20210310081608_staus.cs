using Microsoft.EntityFrameworkCore.Migrations;

namespace ManageMyProjects.Migrations
{
    public partial class staus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Priorities_PriorityId",
                table: "Project");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Priorities",
                table: "Priorities");

            migrationBuilder.RenameTable(
                name: "Priorities",
                newName: "Priority");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Priority",
                table: "Priority",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Priority_PriorityId",
                table: "Project",
                column: "PriorityId",
                principalTable: "Priority",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Priority_PriorityId",
                table: "Project");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Priority",
                table: "Priority");

            migrationBuilder.RenameTable(
                name: "Priority",
                newName: "Priorities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Priorities",
                table: "Priorities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Priorities_PriorityId",
                table: "Project",
                column: "PriorityId",
                principalTable: "Priorities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
