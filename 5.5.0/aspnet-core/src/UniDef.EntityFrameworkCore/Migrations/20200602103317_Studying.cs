using Microsoft.EntityFrameworkCore.Migrations;

namespace UniDef.Migrations
{
    public partial class Studying : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudyingAt",
                table: "AbpUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudyingAt",
                table: "AbpUsers");
        }
    }
}
