using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class PermissaPagina_deletebehavior : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermissaoPagina_Pagina_pagina",
                table: "PermissaoPagina");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissaoPagina_Permissao_permissao",
                table: "PermissaoPagina");

            migrationBuilder.AddForeignKey(
                name: "FK_PermissaoPagina_Pagina_pagina",
                table: "PermissaoPagina",
                column: "pagina",
                principalTable: "Pagina",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissaoPagina_Permissao_permissao",
                table: "PermissaoPagina",
                column: "permissao",
                principalTable: "Permissao",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermissaoPagina_Pagina_pagina",
                table: "PermissaoPagina");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissaoPagina_Permissao_permissao",
                table: "PermissaoPagina");

            migrationBuilder.AddForeignKey(
                name: "FK_PermissaoPagina_Pagina_pagina",
                table: "PermissaoPagina",
                column: "pagina",
                principalTable: "Pagina",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissaoPagina_Permissao_permissao",
                table: "PermissaoPagina",
                column: "permissao",
                principalTable: "Permissao",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
