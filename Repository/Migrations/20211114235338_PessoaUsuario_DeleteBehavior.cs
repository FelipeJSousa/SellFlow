using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class PessoaUsuario_DeleteBehavior : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Pessoa_pessoa",
                table: "Endereco");

            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_Usuario_usuario",
                table: "Pessoa");

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Pessoa_pessoa",
                table: "Endereco",
                column: "pessoa",
                principalTable: "Pessoa",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Usuario_usuario",
                table: "Pessoa",
                column: "usuario",
                principalTable: "Usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Pessoa_pessoa",
                table: "Endereco");

            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_Usuario_usuario",
                table: "Pessoa");

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Pessoa_pessoa",
                table: "Endereco",
                column: "pessoa",
                principalTable: "Pessoa",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Usuario_usuario",
                table: "Pessoa",
                column: "usuario",
                principalTable: "Usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
