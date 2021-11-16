using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class Produtoimagemanuncio_DeleteBehavior : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anuncio_Produto_produto",
                table: "Anuncio");

            migrationBuilder.DropForeignKey(
                name: "FK_Imagens_Produto_produto",
                table: "Imagens");

            migrationBuilder.AddForeignKey(
                name: "FK_Anuncio_Produto_produto",
                table: "Anuncio",
                column: "produto",
                principalTable: "Produto",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Imagens_Produto_produto",
                table: "Imagens",
                column: "produto",
                principalTable: "Produto",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anuncio_Produto_produto",
                table: "Anuncio");

            migrationBuilder.DropForeignKey(
                name: "FK_Imagens_Produto_produto",
                table: "Imagens");

            migrationBuilder.AddForeignKey(
                name: "FK_Anuncio_Produto_produto",
                table: "Anuncio",
                column: "produto",
                principalTable: "Produto",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Imagens_Produto_produto",
                table: "Imagens",
                column: "produto",
                principalTable: "Produto",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
