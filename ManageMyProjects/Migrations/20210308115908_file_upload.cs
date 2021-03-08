using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ManageMyProjects.Migrations
{
    public partial class file_upload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "FileContent",
                table: "Phase",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileContent",
                table: "Phase");
        }
    }
}
