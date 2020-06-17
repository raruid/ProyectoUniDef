using Microsoft.EntityFrameworkCore.Migrations;

namespace UniDef.Migrations
{
    public partial class removeUsuarioOrganizador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_AbpUsers_UsuarioOrganizadorId",
                table: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_UsuarioOrganizadorId",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "UsuarioOrganizadorId",
                table: "Eventos");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Eventos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_UserId",
                table: "Eventos",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_AbpUsers_UserId",
                table: "Eventos",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_AbpUsers_UserId",
                table: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_UserId",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Eventos");

            migrationBuilder.AddColumn<long>(
                name: "UsuarioOrganizadorId",
                table: "Eventos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_UsuarioOrganizadorId",
                table: "Eventos",
                column: "UsuarioOrganizadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_AbpUsers_UsuarioOrganizadorId",
                table: "Eventos",
                column: "UsuarioOrganizadorId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
