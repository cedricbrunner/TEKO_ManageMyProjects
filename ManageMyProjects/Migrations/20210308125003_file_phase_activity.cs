using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ManageMyProjects.Migrations
{
    public partial class file_phase_activity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileContent",
                table: "Phase");

            migrationBuilder.AddColumn<byte[]>(
                name: "FileContent",
                table: "PhasesActivity",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileContent",
                table: "PhasesActivity");

            migrationBuilder.AddColumn<byte[]>(
                name: "FileContent",
                table: "Phase",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
