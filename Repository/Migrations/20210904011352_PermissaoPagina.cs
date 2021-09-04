using Microsoft.EntityFrameworkCore.Migrations;

namespace SellFlow.Migrations
{
    public partial class PermissaoPagina : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "permissaoid",
                table: "Usuario",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pagina",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
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
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    permissaoId = table.Column<int>(type: "int", nullable: false),
                    paginaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissaoPagina", x => new { x.permissaoId, x.paginaId });
                    table.ForeignKey(
                        name: "FK_PermissaoPagina_Pagina_paginaId",
                        column: x => x.paginaId,
                        principalTable: "Pagina",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissaoPagina_Permissao_permissaoId",
                        column: x => x.permissaoId,
                        principalTable: "Permissao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_permissaoid",
                table: "Usuario",
                column: "permissaoid");

            migrationBuilder.CreateIndex(
                name: "IX_PermissaoPagina_paginaId",
                table: "PermissaoPagina",
                column: "paginaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Permissao_permissaoid",
                table: "Usuario",
                column: "permissaoid",
                principalTable: "Permissao",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Permissao_permissaoid",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "PermissaoPagina");

            migrationBuilder.DropTable(
                name: "Pagina");

            migrationBuilder.DropTable(
                name: "Permissao");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_permissaoid",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "permissaoid",
                table: "Usuario");
        }
    }
}
