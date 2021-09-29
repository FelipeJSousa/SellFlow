using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnuncioSitucao",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnuncioSitucao", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
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
                name: "Pagina",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    caminho = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagina", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Permissao",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissao", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PermissaoPagina",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    permissao = table.Column<long>(type: "bigint", nullable: false),
                    pagina = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissaoPagina", x => x.id);
                    table.ForeignKey(
                        name: "FK_PermissaoPagina_Pagina_pagina",
                        column: x => x.pagina,
                        principalTable: "Pagina",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PermissaoPagina_Permissao_permissao",
                        column: x => x.permissao,
                        principalTable: "Permissao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ativo = table.Column<bool>(type: "bit", nullable: false),
                    permissao = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.id);
                    table.ForeignKey(
                        name: "FK_Usuario_Permissao_permissao",
                        column: x => x.permissao,
                        principalTable: "Permissao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    sobrenome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cpnj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false),
                    Usuario = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.id);
                    table.ForeignKey(
                        name: "FK_Pessoa_Usuario_Usuario",
                        column: x => x.Usuario,
                        principalTable: "Usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    imagemDestaque = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ativo = table.Column<bool>(type: "bit", nullable: false),
                    usuario = table.Column<long>(type: "bigint", nullable: false),
                    categoria = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.id);
                    table.ForeignKey(
                        name: "FK_Produto_Categoria_categoria",
                        column: x => x.categoria,
                        principalTable: "Categoria",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Produto_Usuario_usuario",
                        column: x => x.usuario,
                        principalTable: "Usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    logradouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false),
                    pessoa = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.id);
                    table.ForeignKey(
                        name: "FK_Endereco_Pessoa_pessoa",
                        column: x => x.pessoa,
                        principalTable: "Pessoa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Anuncio",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    qtdeDisponivel = table.Column<int>(type: "int", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    dataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataEncerramento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false),
                    produto = table.Column<long>(type: "bigint", nullable: false),
                    anuncioSituacao = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anuncio", x => x.id);
                    table.ForeignKey(
                        name: "FK_Anuncio_AnuncioSitucao_anuncioSituacao",
                        column: x => x.anuncioSituacao,
                        principalTable: "AnuncioSitucao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Anuncio_Produto_produto",
                        column: x => x.produto,
                        principalTable: "Produto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Imagens",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    diretorio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false),
                    produto = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagens", x => x.id);
                    table.ForeignKey(
                        name: "FK_Imagens_Produto_produto",
                        column: x => x.produto,
                        principalTable: "Produto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anuncio_anuncioSituacao",
                table: "Anuncio",
                column: "anuncioSituacao",
                unique: true,
                filter: "[anuncioSituacao] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Anuncio_produto",
                table: "Anuncio",
                column: "produto");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_pessoa",
                table: "Endereco",
                column: "pessoa",
                unique: true,
                filter: "[pessoa] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Imagens_produto",
                table: "Imagens",
                column: "produto");

            migrationBuilder.CreateIndex(
                name: "IX_PermissaoPagina_pagina",
                table: "PermissaoPagina",
                column: "pagina");

            migrationBuilder.CreateIndex(
                name: "IX_PermissaoPagina_permissao",
                table: "PermissaoPagina",
                column: "permissao");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_Usuario",
                table: "Pessoa",
                column: "Usuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produto_categoria",
                table: "Produto",
                column: "categoria");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_usuario",
                table: "Produto",
                column: "usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_permissao",
                table: "Usuario",
                column: "permissao",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anuncio");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Imagens");

            migrationBuilder.DropTable(
                name: "PermissaoPagina");

            migrationBuilder.DropTable(
                name: "AnuncioSitucao");

            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Pagina");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Permissao");
        }
    }
}
