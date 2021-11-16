using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class Initial_Server : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_Usuario_Usuario",
                table: "Pessoa");

            migrationBuilder.RenameColumn(
                name: "Usuario",
                table: "Pessoa",
                newName: "usuario");

            migrationBuilder.RenameIndex(
                name: "IX_Pessoa_Usuario",
                table: "Pessoa",
                newName: "IX_Pessoa_usuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Usuario_usuario",
                table: "Pessoa",
                column: "usuario",
                principalTable: "Usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_Usuario_usuario",
                table: "Pessoa");

            migrationBuilder.RenameColumn(
                name: "usuario",
                table: "Pessoa",
                newName: "Usuario");

            migrationBuilder.RenameIndex(
                name: "IX_Pessoa_usuario",
                table: "Pessoa",
                newName: "IX_Pessoa_Usuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Usuario_Usuario",
                table: "Pessoa",
                column: "Usuario",
                principalTable: "Usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
