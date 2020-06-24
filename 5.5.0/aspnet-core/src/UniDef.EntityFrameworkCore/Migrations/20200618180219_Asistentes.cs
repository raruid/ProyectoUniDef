using Microsoft.EntityFrameworkCore.Migrations;

namespace UniDef.Migrations
{
    public partial class Asistentes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asistentes_AbpUsers_UsuarioAsistenteId",
                table: "Asistentes");

            migrationBuilder.AddForeignKey(
                name: "FK_Asistentes_AbpUsers_UsuarioAsistenteId",
                table: "Asistentes",
                column: "UsuarioAsistenteId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asistentes_AbpUsers_UsuarioAsistenteId",
                table: "Asistentes");

            migrationBuilder.AddForeignKey(
                name: "FK_Asistentes_AbpUsers_UsuarioAsistenteId",
                table: "Asistentes",
                column: "UsuarioAsistenteId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
