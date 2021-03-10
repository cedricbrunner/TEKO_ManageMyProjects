using Microsoft.EntityFrameworkCore.Migrations;

namespace ManageMyProjects.Migrations
{
    public partial class Budget : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PhaseActivityBudget",
                table: "PhasesActivity",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhaseActivityBudget",
                table: "PhasesActivity");
        }
    }
}
