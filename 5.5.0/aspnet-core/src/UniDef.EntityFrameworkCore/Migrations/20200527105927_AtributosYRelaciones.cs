using Microsoft.EntityFrameworkCore.Migrations;

namespace UniDef.Migrations
{
    public partial class AtributosYRelaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UsuarioSeguidoId",
                table: "Seguidores",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UsuarioSeguidorId",
                table: "Seguidores",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UsuarioOrganizadorId",
                table: "Eventos",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "EventoId",
                table: "Asistentes",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "EventoId1",
                table: "Asistentes",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UsuarioAsistenteId",
                table: "Asistentes",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AbpUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "AbpUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Surname2",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seguidores_UsuarioSeguidoId",
                table: "Seguidores",
                column: "UsuarioSeguidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Seguidores_UsuarioSeguidorId",
                table: "Seguidores",
                column: "UsuarioSeguidorId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_UsuarioOrganizadorId",
                table: "Eventos",
                column: "UsuarioOrganizadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Asistentes_EventoId1",
                table: "Asistentes",
                column: "EventoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Asistentes_UsuarioAsistenteId",
                table: "Asistentes",
                column: "UsuarioAsistenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Asistentes_Eventos_EventoId1",
                table: "Asistentes",
                column: "EventoId1",
                principalTable: "Eventos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Asistentes_AbpUsers_UsuarioAsistenteId",
                table: "Asistentes",
                column: "UsuarioAsistenteId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_AbpUsers_UsuarioOrganizadorId",
                table: "Eventos",
                column: "UsuarioOrganizadorId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seguidores_AbpUsers_UsuarioSeguidoId",
                table: "Seguidores",
                column: "UsuarioSeguidoId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Seguidores_AbpUsers_UsuarioSeguidorId",
                table: "Seguidores",
                column: "UsuarioSeguidorId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asistentes_Eventos_EventoId1",
                table: "Asistentes");

            migrationBuilder.DropForeignKey(
                name: "FK_Asistentes_AbpUsers_UsuarioAsistenteId",
                table: "Asistentes");

            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_AbpUsers_UsuarioOrganizadorId",
                table: "Eventos");

            migrationBuilder.DropForeignKey(
                name: "FK_Seguidores_AbpUsers_UsuarioSeguidoId",
                table: "Seguidores");

            migrationBuilder.DropForeignKey(
                name: "FK_Seguidores_AbpUsers_UsuarioSeguidorId",
                table: "Seguidores");

            migrationBuilder.DropIndex(
                name: "IX_Seguidores_UsuarioSeguidoId",
                table: "Seguidores");

            migrationBuilder.DropIndex(
                name: "IX_Seguidores_UsuarioSeguidorId",
                table: "Seguidores");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_UsuarioOrganizadorId",
                table: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Asistentes_EventoId1",
                table: "Asistentes");

            migrationBuilder.DropIndex(
                name: "IX_Asistentes_UsuarioAsistenteId",
                table: "Asistentes");

            migrationBuilder.DropColumn(
                name: "UsuarioSeguidoId",
                table: "Seguidores");

            migrationBuilder.DropColumn(
                name: "UsuarioSeguidorId",
                table: "Seguidores");

            migrationBuilder.DropColumn(
                name: "UsuarioOrganizadorId",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "EventoId",
                table: "Asistentes");

            migrationBuilder.DropColumn(
                name: "EventoId1",
                table: "Asistentes");

            migrationBuilder.DropColumn(
                name: "UsuarioAsistenteId",
                table: "Asistentes");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "Surname2",
                table: "AbpUsers");
        }
    }
}
