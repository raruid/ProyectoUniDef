using Microsoft.EntityFrameworkCore.Migrations;

namespace UniDef.Migrations
{
    public partial class AboutMe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score",
                table: "AbpUsers");

            migrationBuilder.AddColumn<string>(
                name: "AboutMe",
                table: "AbpUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutMe",
                table: "AbpUsers");

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "AbpUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
