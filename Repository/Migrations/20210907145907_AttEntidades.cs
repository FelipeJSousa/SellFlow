using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SellFlow.Migrations
{
    public partial class AttEntidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "categoriaid",
                table: "Produto",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Anuncio",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    qtdeDisponivel = table.Column<int>(type: "int", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    dataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataEncerramento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false),
                    Produtoid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anuncio", x => x.id);
                    table.ForeignKey(
                        name: "FK_Anuncio_Produto_Produtoid",
                        column: x => x.Produtoid,
                        principalTable: "Produto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    imagemDiretorio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    logradouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PessoaEndereco",
                columns: table => new
                {
                    pessoaId = table.Column<int>(type: "int", nullable: false),
                    enderecoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaEndereco", x => new { x.pessoaId, x.enderecoId });
                    table.ForeignKey(
                        name: "FK_PessoaEndereco_Endereco_enderecoId",
                        column: x => x.enderecoId,
                        principalTable: "Endereco",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PessoaEndereco_Pessoa_pessoaId",
                        column: x => x.pessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produto_categoriaid",
                table: "Produto",
                column: "categoriaid");

            migrationBuilder.CreateIndex(
                name: "IX_Anuncio_Produtoid",
                table: "Anuncio",
                column: "Produtoid");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaEndereco_enderecoId",
                table: "PessoaEndereco",
                column: "enderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Categoria_categoriaid",
                table: "Produto",
                column: "categoriaid",
                principalTable: "Categoria",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Categoria_categoriaid",
                table: "Produto");

            migrationBuilder.DropTable(
                name: "Anuncio");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "PessoaEndereco");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Produto_categoriaid",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "categoriaid",
                table: "Produto");
        }
    }
}
