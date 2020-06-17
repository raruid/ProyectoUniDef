using Microsoft.EntityFrameworkCore.Migrations;

namespace UniDef.Migrations
{
    public partial class UsuarioOrganizador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_AbpUsers_UsuarioOrganizadorId",
                table: "Eventos");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_AbpUsers_UsuarioOrganizadorId",
                table: "Eventos",
                column: "UsuarioOrganizadorId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_AbpUsers_UsuarioOrganizadorId",
                table: "Eventos");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_AbpUsers_UsuarioOrganizadorId",
                table: "Eventos",
                column: "UsuarioOrganizadorId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
